namespace PortKiller.Models;

public record PortEntry(
    int Port,
    string Protocol,
    int Pid,
    string ProcessName,
    string State
);
