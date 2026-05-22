using System.Diagnostics;
using System.Text.RegularExpressions;
using PortKiller.Models;

namespace PortKiller.Services;

public static class PortService
{
    // Matches lines like:  TCP    0.0.0.0:80    0.0.0.0:0    LISTENING    1234
    private static readonly Regex TcpLineRegex = new(
        @"^\s*(TCP|UDP)\s+[\d\.\[\]\*]+:(\d+)\s+[\d\.\[\]\*:]+\s+(\w+)?\s+(\d+)",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static List<PortEntry> GetListeningPorts()
    {
        var result = new List<PortEntry>();

        var output = RunNetstat();
        if (string.IsNullOrWhiteSpace(output))
            return result;

        foreach (var line in output.Split('\n'))
        {
            var match = TcpLineRegex.Match(line);
            if (!match.Success) continue;

            var protocol = match.Groups[1].Value.ToUpper();
            var port = int.Parse(match.Groups[2].Value);
            var state = match.Groups[3].Value; // empty for UDP
            var pid = int.Parse(match.Groups[4].Value);

            // For TCP, only show LISTENING; UDP has no state
            if (protocol == "TCP" && !state.Equals("LISTENING", StringComparison.OrdinalIgnoreCase))
                continue;

            var processName = GetProcessName(pid);

            result.Add(new PortEntry(port, protocol, pid, processName, state));
        }

        // Deduplicate by port+pid, sort by port
        return result
            .DistinctBy(e => (e.Port, e.Pid))
            .OrderBy(e => e.Port)
            .ToList();
    }

    public static bool KillProcess(int pid)
    {
        try
        {
            var process = Process.GetProcessById(pid);
            process.Kill(entireProcessTree: true);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static string RunNetstat()
    {
        try
        {
            var psi = new ProcessStartInfo
            {
                FileName = "netstat",
                Arguments = "-ano",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var proc = Process.Start(psi)!;
            var output = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();
            return output;
        }
        catch
        {
            return string.Empty;
        }
    }

    private static string GetProcessName(int pid)
    {
        try
        {
            return Process.GetProcessById(pid).ProcessName;
        }
        catch
        {
            return "Unknown";
        }
    }
}
