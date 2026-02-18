namespace SQLConnCheck
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpManual = new GroupBox();
            lblManualInstruction = new Label();
            txtConnectionString = new TextBox();
            btnTestManual = new Button();
            lblManualStatus = new Label();
            grpFile = new GroupBox();
            lblFileInstruction = new Label();
            btnBrowse = new Button();
            lblFilePath = new Label();
            btnTestFile = new Button();
            grpQuery = new GroupBox();
            lblQueryInstruction = new Label();
            txtQuery = new TextBox();
            btnExecuteQuery = new Button();
            txtQueryResult = new TextBox();
            grpResults = new GroupBox();
            dgvResults = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colError = new DataGridViewTextBoxColumn();
            lblSummary = new Label();
            grpManual.SuspendLayout();
            grpFile.SuspendLayout();
            grpQuery.SuspendLayout();
            grpResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            //
            // grpManual
            //
            grpManual.Controls.Add(lblManualInstruction);
            grpManual.Controls.Add(txtConnectionString);
            grpManual.Controls.Add(btnTestManual);
            grpManual.Controls.Add(lblManualStatus);
            grpManual.Dock = DockStyle.Top;
            grpManual.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpManual.Location = new Point(12, 12);
            grpManual.Name = "grpManual";
            grpManual.Padding = new Padding(10, 6, 10, 10);
            grpManual.Size = new Size(760, 180);
            grpManual.TabIndex = 0;
            grpManual.TabStop = false;
            grpManual.Text = "Manual Connection String Test";
            //
            // lblManualInstruction
            //
            lblManualInstruction.AutoSize = true;
            lblManualInstruction.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblManualInstruction.ForeColor = Color.DimGray;
            lblManualInstruction.Location = new Point(13, 28);
            lblManualInstruction.Name = "lblManualInstruction";
            lblManualInstruction.Size = new Size(330, 15);
            lblManualInstruction.TabIndex = 3;
            lblManualInstruction.Text = "Paste your MS SQL Server connection string below and click Test:";
            //
            // txtConnectionString
            //
            txtConnectionString.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtConnectionString.Font = new Font("Consolas", 9F);
            txtConnectionString.Location = new Point(13, 48);
            txtConnectionString.Multiline = true;
            txtConnectionString.Name = "txtConnectionString";
            txtConnectionString.PlaceholderText = "e.g. Data Source=.\\SQLEXPRESS;Initial Catalog=MyDB;User ID=sa;Password=secret;";
            txtConnectionString.ScrollBars = ScrollBars.Vertical;
            txtConnectionString.Size = new Size(620, 80);
            txtConnectionString.TabIndex = 0;
            //
            // btnTestManual
            //
            btnTestManual.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTestManual.FlatStyle = FlatStyle.System;
            btnTestManual.Location = new Point(645, 48);
            btnTestManual.Name = "btnTestManual";
            btnTestManual.Size = new Size(102, 80);
            btnTestManual.TabIndex = 1;
            btnTestManual.Text = "Test\r\nConnection";
            btnTestManual.UseVisualStyleBackColor = true;
            btnTestManual.Click += btnTestManual_Click;
            //
            // lblManualStatus
            //
            lblManualStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblManualStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblManualStatus.Location = new Point(13, 140);
            lblManualStatus.Name = "lblManualStatus";
            lblManualStatus.Size = new Size(734, 26);
            lblManualStatus.TabIndex = 2;
            lblManualStatus.Text = "";
            //
            // grpFile
            //
            grpFile.Controls.Add(lblFileInstruction);
            grpFile.Controls.Add(btnBrowse);
            grpFile.Controls.Add(lblFilePath);
            grpFile.Controls.Add(btnTestFile);
            grpFile.Dock = DockStyle.Top;
            grpFile.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpFile.Location = new Point(12, 204);
            grpFile.Name = "grpFile";
            grpFile.Padding = new Padding(10, 6, 10, 10);
            grpFile.Size = new Size(760, 90);
            grpFile.TabIndex = 1;
            grpFile.TabStop = false;
            grpFile.Text = "Test from appsettings.json";
            //
            // lblFileInstruction
            //
            lblFileInstruction.AutoSize = true;
            lblFileInstruction.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblFileInstruction.ForeColor = Color.DimGray;
            lblFileInstruction.Location = new Point(13, 28);
            lblFileInstruction.Name = "lblFileInstruction";
            lblFileInstruction.Size = new Size(356, 15);
            lblFileInstruction.TabIndex = 3;
            lblFileInstruction.Text = "Select an appsettings.json file to test all ConnectionStrings in it:";
            //
            // btnBrowse
            //
            btnBrowse.FlatStyle = FlatStyle.System;
            btnBrowse.Location = new Point(13, 50);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(175, 28);
            btnBrowse.TabIndex = 0;
            btnBrowse.Text = "Browse appsettings.json";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            //
            // lblFilePath
            //
            lblFilePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblFilePath.Font = new Font("Consolas", 8.5F, FontStyle.Regular);
            lblFilePath.ForeColor = Color.DimGray;
            lblFilePath.Location = new Point(198, 54);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(444, 20);
            lblFilePath.TabIndex = 1;
            lblFilePath.Text = "No file selected";
            //
            // btnTestFile
            //
            btnTestFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTestFile.Enabled = false;
            btnTestFile.FlatStyle = FlatStyle.System;
            btnTestFile.Location = new Point(648, 50);
            btnTestFile.Name = "btnTestFile";
            btnTestFile.Size = new Size(99, 28);
            btnTestFile.TabIndex = 2;
            btnTestFile.Text = "Test All";
            btnTestFile.UseVisualStyleBackColor = true;
            btnTestFile.Click += btnTestFile_Click;
            //
            // grpQuery
            //
            grpQuery.Controls.Add(lblQueryInstruction);
            grpQuery.Controls.Add(txtQuery);
            grpQuery.Controls.Add(btnExecuteQuery);
            grpQuery.Controls.Add(txtQueryResult);
            grpQuery.Dock = DockStyle.Bottom;
            grpQuery.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpQuery.Location = new Point(12, 282);
            grpQuery.Name = "grpQuery";
            grpQuery.Padding = new Padding(10, 6, 10, 10);
            grpQuery.Size = new Size(760, 130);
            grpQuery.TabIndex = 3;
            grpQuery.TabStop = false;
            grpQuery.Text = "Execute Query";
            //
            // lblQueryInstruction
            //
            lblQueryInstruction.AutoSize = true;
            lblQueryInstruction.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblQueryInstruction.ForeColor = Color.DimGray;
            lblQueryInstruction.Location = new Point(13, 26);
            lblQueryInstruction.Name = "lblQueryInstruction";
            lblQueryInstruction.TabIndex = 3;
            lblQueryInstruction.Text = "SQL query to run against the connection string above:";
            //
            // txtQuery
            //
            txtQuery.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtQuery.Font = new Font("Consolas", 9F);
            txtQuery.Location = new Point(13, 46);
            txtQuery.Name = "txtQuery";
            txtQuery.Size = new Size(620, 23);
            txtQuery.TabIndex = 0;
            txtQuery.Text = "SELECT 1;";
            //
            // btnExecuteQuery
            //
            btnExecuteQuery.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExecuteQuery.FlatStyle = FlatStyle.System;
            btnExecuteQuery.Location = new Point(645, 46);
            btnExecuteQuery.Name = "btnExecuteQuery";
            btnExecuteQuery.Size = new Size(102, 23);
            btnExecuteQuery.TabIndex = 1;
            btnExecuteQuery.Text = "Execute";
            btnExecuteQuery.UseVisualStyleBackColor = true;
            btnExecuteQuery.Click += btnExecuteQuery_Click;
            //
            // txtQueryResult
            //
            txtQueryResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtQueryResult.BackColor = SystemColors.Window;
            txtQueryResult.Font = new Font("Consolas", 8.5F);
            txtQueryResult.Location = new Point(13, 78);
            txtQueryResult.Multiline = true;
            txtQueryResult.Name = "txtQueryResult";
            txtQueryResult.ReadOnly = true;
            txtQueryResult.ScrollBars = ScrollBars.Vertical;
            txtQueryResult.Size = new Size(734, 40);
            txtQueryResult.TabIndex = 2;
            //
            // grpResults
            //
            grpResults.Controls.Add(dgvResults);
            grpResults.Controls.Add(lblSummary);
            grpResults.Dock = DockStyle.Fill;
            grpResults.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpResults.Name = "grpResults";
            grpResults.Padding = new Padding(10, 6, 10, 10);
            grpResults.Size = new Size(760, 282);
            grpResults.TabIndex = 2;
            grpResults.TabStop = false;
            grpResults.Text = "Results";
            //
            // dgvResults
            //
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.BackgroundColor = Color.White;
            dgvResults.BorderStyle = BorderStyle.None;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Columns.AddRange(new DataGridViewColumn[] { colName, colStatus, colError });
            dgvResults.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgvResults.GridColor = Color.FromArgb(220, 220, 220);
            dgvResults.Location = new Point(13, 28);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersWidth = 24;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.Size = new Size(734, 220);
            dgvResults.TabIndex = 0;
            //
            // colName
            //
            colName.FillWeight = 25;
            colName.HeaderText = "Name";
            colName.MinimumWidth = 100;
            colName.Name = "colName";
            colName.ReadOnly = true;
            //
            // colStatus
            //
            colStatus.FillWeight = 15;
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 80;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            //
            // colError
            //
            colError.FillWeight = 60;
            colError.HeaderText = "Error / Details";
            colError.MinimumWidth = 200;
            colError.Name = "colError";
            colError.ReadOnly = true;
            //
            // lblSummary
            //
            lblSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSummary.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblSummary.ForeColor = Color.DimGray;
            lblSummary.Location = new Point(13, 254);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(734, 18);
            lblSummary.TabIndex = 1;
            lblSummary.Text = "";
            //
            // MainForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 731);
            Controls.Add(grpResults);
            Controls.Add(grpFile);
            Controls.Add(grpManual);
            Controls.Add(grpQuery);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(800, 770);
            Name = "MainForm";
            Padding = new Padding(12, 12, 12, 12);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SQLConnCheck — MS SQL Connection String Tester";
            grpManual.ResumeLayout(false);
            grpManual.PerformLayout();
            grpFile.ResumeLayout(false);
            grpFile.PerformLayout();
            grpQuery.ResumeLayout(false);
            grpQuery.PerformLayout();
            grpResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpManual;
        private Label lblManualInstruction;
        private TextBox txtConnectionString;
        private Button btnTestManual;
        private Label lblManualStatus;
        private GroupBox grpFile;
        private Label lblFileInstruction;
        private Button btnBrowse;
        private Label lblFilePath;
        private Button btnTestFile;
        private GroupBox grpQuery;
        private Label lblQueryInstruction;
        private TextBox txtQuery;
        private Button btnExecuteQuery;
        private TextBox txtQueryResult;
        private GroupBox grpResults;
        private DataGridView dgvResults;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colError;
        private Label lblSummary;
    }
}
