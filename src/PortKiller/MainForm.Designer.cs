namespace PortKiller;

partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblTitle      = new Label();
        txtSearch     = new TextBox();
        btnRefresh    = new Button();
        btnKill       = new Button();
        gridPorts     = new DataGridView();
        lblStatus     = new Label();
        pnlToolbar    = new Panel();
        pnlStatus     = new Panel();

        ((System.ComponentModel.ISupportInitialize)gridPorts).BeginInit();
        pnlToolbar.SuspendLayout();
        pnlStatus.SuspendLayout();
        SuspendLayout();

        // ---------------------------------------------------------------
        // lblTitle
        // ---------------------------------------------------------------
        lblTitle.AutoSize  = true;
        lblTitle.Font      = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(255, 80, 80);
        lblTitle.Location  = new Point(12, 10);
        lblTitle.Name      = "lblTitle";
        lblTitle.Text      = "⚡ PORT KILLER";

        // ---------------------------------------------------------------
        // txtSearch
        // ---------------------------------------------------------------
        txtSearch.BackColor       = Color.FromArgb(30, 30, 40);
        txtSearch.BorderStyle     = BorderStyle.FixedSingle;
        txtSearch.Font            = new Font("Segoe UI", 9.5F);
        txtSearch.ForeColor       = Color.FromArgb(220, 220, 230);
        txtSearch.Location        = new Point(12, 46);
        txtSearch.Name            = "txtSearch";
        txtSearch.PlaceholderText = "Filter by port or process name…";
        txtSearch.Size            = new Size(280, 24);
        txtSearch.TabIndex        = 0;
        txtSearch.TextChanged    += txtSearch_TextChanged;

        // ---------------------------------------------------------------
        // btnRefresh
        // ---------------------------------------------------------------
        btnRefresh.BackColor              = Color.FromArgb(35, 95, 185);
        btnRefresh.FlatStyle              = FlatStyle.Flat;
        btnRefresh.FlatAppearance.BorderSize = 0;
        btnRefresh.Font                   = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnRefresh.ForeColor              = Color.White;
        btnRefresh.Location               = new Point(302, 44);
        btnRefresh.Name                   = "btnRefresh";
        btnRefresh.Size                   = new Size(100, 28);
        btnRefresh.TabIndex               = 1;
        btnRefresh.Text                   = "↻  Refresh";
        btnRefresh.UseVisualStyleBackColor = false;
        btnRefresh.Cursor                 = Cursors.Hand;
        btnRefresh.Click                 += btnRefresh_Click;

        // ---------------------------------------------------------------
        // btnKill
        // ---------------------------------------------------------------
        btnKill.BackColor              = Color.FromArgb(190, 38, 38);
        btnKill.Enabled                = false;
        btnKill.FlatStyle              = FlatStyle.Flat;
        btnKill.FlatAppearance.BorderSize = 0;
        btnKill.Font                   = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnKill.ForeColor              = Color.White;
        btnKill.Location               = new Point(412, 44);
        btnKill.Name                   = "btnKill";
        btnKill.Size                   = new Size(110, 28);
        btnKill.TabIndex               = 2;
        btnKill.Text                   = "✕  Kill Process";
        btnKill.UseVisualStyleBackColor = false;
        btnKill.Cursor                 = Cursors.Hand;
        btnKill.Click                 += btnKill_Click;

        // ---------------------------------------------------------------
        // pnlToolbar  (holds title + search + buttons)
        // ---------------------------------------------------------------
        pnlToolbar.BackColor = Color.FromArgb(22, 22, 30);
        pnlToolbar.Controls.AddRange(new Control[] { lblTitle, txtSearch, btnRefresh, btnKill });
        pnlToolbar.Dock      = DockStyle.Top;
        pnlToolbar.Height    = 82;
        pnlToolbar.Name      = "pnlToolbar";

        // ---------------------------------------------------------------
        // gridPorts
        // ---------------------------------------------------------------
        gridPorts.AllowUserToAddRows            = false;
        gridPorts.AllowUserToDeleteRows         = false;
        gridPorts.AutoSizeColumnsMode           = DataGridViewAutoSizeColumnsMode.Fill;
        gridPorts.BackgroundColor               = Color.FromArgb(20, 20, 28);
        gridPorts.BorderStyle                   = BorderStyle.None;
        gridPorts.CellBorderStyle               = DataGridViewCellBorderStyle.SingleHorizontal;
        gridPorts.ColumnHeadersBorderStyle      = DataGridViewHeaderBorderStyle.None;
        gridPorts.ColumnHeadersHeight           = 30;
        gridPorts.ColumnHeadersHeightSizeMode   = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        gridPorts.EnableHeadersVisualStyles     = false;
        gridPorts.GridColor                     = Color.FromArgb(38, 38, 52);
        gridPorts.MultiSelect                   = false;
        gridPorts.Name                          = "gridPorts";
        gridPorts.ReadOnly                      = true;
        gridPorts.RowHeadersVisible             = false;
        gridPorts.RowTemplate.Height            = 28;
        gridPorts.SelectionMode                 = DataGridViewSelectionMode.FullRowSelect;
        gridPorts.Dock                          = DockStyle.Fill;
        gridPorts.Font                          = new Font("Consolas", 9F);

        gridPorts.DefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor         = Color.FromArgb(20, 20, 28),
            ForeColor         = Color.FromArgb(210, 210, 225),
            SelectionBackColor = Color.FromArgb(55, 55, 85),
            SelectionForeColor = Color.White,
            Padding           = new Padding(4, 2, 4, 2)
        };

        gridPorts.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor         = Color.FromArgb(28, 28, 40),
            ForeColor         = Color.FromArgb(140, 140, 175),
            SelectionBackColor = Color.FromArgb(28, 28, 40),
            Font              = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            Padding           = new Padding(4, 4, 4, 4)
        };

        gridPorts.SelectionChanged += gridPorts_SelectionChanged;

        // ---------------------------------------------------------------
        // lblStatus
        // ---------------------------------------------------------------
        lblStatus.Dock        = DockStyle.Fill;
        lblStatus.Font        = new Font("Segoe UI", 8.5F);
        lblStatus.ForeColor   = Color.FromArgb(110, 110, 145);
        lblStatus.Name        = "lblStatus";
        lblStatus.Padding     = new Padding(8, 0, 0, 0);
        lblStatus.Text        = "Ready";
        lblStatus.TextAlign   = ContentAlignment.MiddleLeft;

        // ---------------------------------------------------------------
        // pnlStatus
        // ---------------------------------------------------------------
        pnlStatus.BackColor = Color.FromArgb(18, 18, 26);
        pnlStatus.Controls.Add(lblStatus);
        pnlStatus.Dock      = DockStyle.Bottom;
        pnlStatus.Height    = 26;
        pnlStatus.Name      = "pnlStatus";

        // ---------------------------------------------------------------
        // MainForm
        // ---------------------------------------------------------------
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode       = AutoScaleMode.Font;
        BackColor           = Color.FromArgb(20, 20, 28);
        ClientSize          = new Size(820, 540);
        Controls.AddRange(new Control[] { gridPorts, pnlToolbar, pnlStatus });
        Font                = new Font("Segoe UI", 9F);
        ForeColor           = Color.FromArgb(220, 220, 230);
        MinimumSize         = new Size(600, 400);
        Name                = "MainForm";
        StartPosition       = FormStartPosition.CenterScreen;
        Text                = "Port Killer";

        ((System.ComponentModel.ISupportInitialize)gridPorts).EndInit();
        pnlToolbar.ResumeLayout(false);
        pnlToolbar.PerformLayout();
        pnlStatus.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    // Control declarations
    private Label           lblTitle;
    private TextBox         txtSearch;
    private Button          btnRefresh;
    private Button          btnKill;
    private DataGridView    gridPorts;
    private Label           lblStatus;
    private Panel           pnlToolbar;
    private Panel           pnlStatus;
}
