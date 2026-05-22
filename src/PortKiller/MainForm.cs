using PortKiller.Models;
using PortKiller.Services;

namespace PortKiller;

public partial class MainForm : Form
{
    // --- Data ---
    private List<PortEntry> _allPorts = [];
    private readonly BindingSource _bindingSource = new();

    public MainForm()
    {
        InitializeComponent();

        // Window icon
        var iconPath = Path.Combine(AppContext.BaseDirectory, "Resources", "icon.ico");
        if (File.Exists(iconPath))
            Icon = new Icon(iconPath);

        SetupGridColumns();
        LoadPorts();
    }

    // ---------------------------------------------------------------
    // Grid column setup (data-binding names must match PortEntry props)
    // ---------------------------------------------------------------

    private void SetupGridColumns()
    {
        gridPorts.Columns.Clear();

        AddColumn("Port",        "Port",     80,  DataGridViewContentAlignment.MiddleCenter);
        AddColumn("Protocol",    "Protocol", 70,  DataGridViewContentAlignment.MiddleCenter);
        AddColumn("ProcessName", "Process",  200, DataGridViewContentAlignment.MiddleLeft);
        AddColumn("Pid",         "PID",      80,  DataGridViewContentAlignment.MiddleCenter);
        AddColumn("State",       "State",    100, DataGridViewContentAlignment.MiddleCenter);

        gridPorts.CellFormatting += (_, e) =>
        {
            if (e.RowIndex < 0) return;
            if (gridPorts.Columns[e.ColumnIndex].Name == "Port")
                e.CellStyle!.ForeColor = Color.FromArgb(255, 110, 110);
            if (gridPorts.Columns[e.ColumnIndex].Name == "ProcessName")
                e.CellStyle!.ForeColor = Color.FromArgb(130, 210, 255);
        };

        gridPorts.DataSource = _bindingSource;
    }

    private void AddColumn(string name, string header, int fillWeight,
        DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft)
    {
        gridPorts.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name              = name,
            DataPropertyName  = name,
            HeaderText        = header,
            FillWeight        = fillWeight,
            DefaultCellStyle  = { Alignment = align },
            SortMode          = DataGridViewColumnSortMode.Automatic
        });
    }

    // ---------------------------------------------------------------
    // Load / filter
    // ---------------------------------------------------------------

    private void LoadPorts()
    {
        lblStatus.Text        = "Scanning ports…";
        gridPorts.Enabled     = false;
        btnKill.Enabled       = false;

        Task.Run(() =>
        {
            var ports = PortService.GetListeningPorts();
            BeginInvoke(() =>
            {
                _allPorts         = ports;
                ApplyFilter();
                gridPorts.Enabled = true;
                lblStatus.Text    = $"{_allPorts.Count} listening port(s) found.";
            });
        });
    }

    private void ApplyFilter()
    {
        var term = txtSearch.Text.Trim();

        var filtered = string.IsNullOrEmpty(term)
            ? _allPorts
            : _allPorts.Where(p =>
                p.Port.ToString().Contains(term) ||
                p.ProcessName.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                p.Protocol.Contains(term,    StringComparison.OrdinalIgnoreCase))
              .ToList();

        _bindingSource.DataSource = filtered;

        if (!string.IsNullOrEmpty(term))
            lblStatus.Text = $"Showing {filtered.Count} of {_allPorts.Count} port(s).";
    }

    // ---------------------------------------------------------------
    // Event handlers (wired in Designer)
    // ---------------------------------------------------------------

    private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();

    private void btnRefresh_Click(object sender, EventArgs e) => LoadPorts();

    private void gridPorts_SelectionChanged(object sender, EventArgs e)
        => btnKill.Enabled = gridPorts.SelectedRows.Count > 0;

    private void btnKill_Click(object sender, EventArgs e)
    {
        if (gridPorts.SelectedRows.Count == 0) return;
        if (gridPorts.SelectedRows[0].DataBoundItem is not PortEntry entry) return;

        var confirm = MessageBox.Show(
            $"Kill \"{entry.ProcessName}\" (PID {entry.Pid}) on port {entry.Port}?",
            "Confirm Kill",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (confirm != DialogResult.Yes) return;

        var ok = PortService.KillProcess(entry.Pid);
        lblStatus.Text = ok
            ? $"✓  Killed {entry.ProcessName} (PID {entry.Pid}) on port {entry.Port}."
            : $"✗  Could not kill PID {entry.Pid}. Try running as Administrator.";

        LoadPorts();
    }
}
