using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace SQLConnCheck
{
    public partial class MainForm : Form
    {
        private string? _selectedFilePath;

        public MainForm()
        {
            InitializeComponent();
            StyleDataGrid();
        }

        // ─── Styling ───────────────────────────────────────────────────────────

        private void StyleDataGrid()
        {
            dgvResults.EnableHeadersVisualStyles = true;
            dgvResults.RowTemplate.Height = 24;
        }

        // ─── Manual Test ───────────────────────────────────────────────────────

        private async void btnTestManual_Click(object sender, EventArgs e)
        {
            string connStr = txtConnectionString.Text.Trim();
            if (string.IsNullOrWhiteSpace(connStr))
            {
                SetManualStatus("Please paste a connection string first.", Color.DarkRed, isError: true);
                return;
            }

            SetManualStatus("Testing…", SystemColors.GrayText, isError: false);
            btnTestManual.Enabled = false;

            var (success, errorMsg) = await TestConnectionAsync(connStr);

            if (success)
            {
                SetManualStatus("SUCCESS — Connection opened successfully.", Color.DarkGreen, isError: false);
                PopulateGridSingleRow("(Manual)", success, errorMsg);
            }
            else
            {
                SetManualStatus($"FAILED — {errorMsg}", Color.DarkRed, isError: true);
                PopulateGridSingleRow("(Manual)", success, errorMsg);
            }

            btnTestManual.Enabled = true;
        }

        private void SetManualStatus(string text, Color color, bool _)
        {
            lblManualStatus.ForeColor = color;
            lblManualStatus.Text = text;
        }

        private void PopulateGridSingleRow(string name, bool success, string? error)
        {
            dgvResults.Rows.Clear();
            lblSummary.Text = "";
            AddResultRow(name, success, error);
            lblSummary.Text = success
                ? "Result: 1 connection tested — 1 succeeded, 0 failed."
                : "Result: 1 connection tested — 0 succeeded, 1 failed.";
        }

        // ─── File Browse ───────────────────────────────────────────────────────

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title = "Select appsettings.json",
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _selectedFilePath = dlg.FileName;
                lblFilePath.Text = _selectedFilePath;
                lblFilePath.ForeColor = SystemColors.WindowText;
                btnTestFile.Enabled = true;
                dgvResults.Rows.Clear();
                lblSummary.Text = "";
                lblManualStatus.Text = "";
            }
        }

        // ─── File / Batch Test ─────────────────────────────────────────────────

        private async void btnTestFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedFilePath) || !File.Exists(_selectedFilePath))
            {
                MessageBox.Show("File not found. Please browse again.", "File Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Dictionary<string, string>? connectionStrings;
            try
            {
                connectionStrings = ParseConnectionStrings(_selectedFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to parse the JSON file:\n{ex.Message}", "Parse Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (connectionStrings == null || connectionStrings.Count == 0)
            {
                MessageBox.Show(
                    "No \"ConnectionStrings\" section found (or it is empty) in the selected file.",
                    "No Connections",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Prepare UI
            dgvResults.Rows.Clear();
            lblSummary.Text = $"Testing {connectionStrings.Count} connection(s)…";
            btnTestFile.Enabled = false;
            btnBrowse.Enabled = false;
            btnTestManual.Enabled = false;
            lblManualStatus.Text = "";

            int successCount = 0;
            int failCount = 0;

            foreach (var kvp in connectionStrings)
            {
                var (success, errorMsg) = await TestConnectionAsync(kvp.Value);
                AddResultRow(kvp.Key, success, errorMsg);

                if (success) successCount++;
                else failCount++;

                // Update summary live
                lblSummary.Text = $"Tested {successCount + failCount} / {connectionStrings.Count} — " +
                                  $"{successCount} succeeded, {failCount} failed.";
            }

            // Final summary with colour
            int total = successCount + failCount;
            lblSummary.ForeColor = failCount == 0 ? Color.DarkGreen : Color.DarkRed;
            lblSummary.Text = $"Done — {total} tested, {successCount} succeeded, {failCount} failed.";

            btnTestFile.Enabled = true;
            btnBrowse.Enabled = true;
            btnTestManual.Enabled = true;
        }

        // ─── Query Execution ───────────────────────────────────────────────────

        private async void btnExecuteQuery_Click(object sender, EventArgs e)
        {
            string connStr = txtConnectionString.Text.Trim();
            if (string.IsNullOrWhiteSpace(connStr))
            {
                txtQueryResult.ForeColor = Color.DarkRed;
                txtQueryResult.Text = "Error: paste a connection string first.";
                return;
            }

            string query = txtQuery.Text.Trim();
            if (string.IsNullOrWhiteSpace(query))
            {
                txtQueryResult.ForeColor = Color.DarkRed;
                txtQueryResult.Text = "Error: enter a SQL query.";
                return;
            }

            txtQueryResult.ForeColor = SystemColors.GrayText;
            txtQueryResult.Text = "Executing…";
            btnExecuteQuery.Enabled = false;

            var (result, error) = await ExecuteQueryAsync(connStr, query);

            if (error != null)
            {
                txtQueryResult.ForeColor = Color.DarkRed;
                txtQueryResult.Text = $"Error: {error}";
            }
            else
            {
                txtQueryResult.ForeColor = SystemColors.WindowText;
                txtQueryResult.Text = result;
            }

            btnExecuteQuery.Enabled = true;
        }

        private static Task<(string? Result, string? Error)> ExecuteQueryAsync(string connectionString, string query)
        {
            return Task.Run(() =>
            {
                try
                {
                    using var conn = new SqlConnection(connectionString);
                    conn.Open();
                    using var cmd = new SqlCommand(query, conn);
                    using var reader = cmd.ExecuteReader();

                    var sb = new System.Text.StringBuilder();

                    // Column headers
                    int fieldCount = reader.FieldCount;
                    if (fieldCount > 0)
                    {
                        var headers = new string[fieldCount];
                        for (int i = 0; i < fieldCount; i++)
                            headers[i] = reader.GetName(i);
                        sb.AppendLine(string.Join("  |  ", headers));
                        sb.AppendLine(new string('-', Math.Min(string.Join("  |  ", headers).Length, 100)));
                    }

                    int rowCount = 0;
                    while (reader.Read())
                    {
                        var values = new string[fieldCount];
                        for (int i = 0; i < fieldCount; i++)
                            values[i] = reader.IsDBNull(i) ? "NULL" : reader.GetValue(i)?.ToString() ?? "";
                        sb.AppendLine(string.Join("  |  ", values));
                        rowCount++;
                    }

                    sb.Append(rowCount == 0 ? "(0 rows returned)" : $"({rowCount} row(s) returned)");
                    return (sb.ToString(), (string?)null);
                }
                catch (Exception ex)
                {
                    return ((string?)null, ex.Message);
                }
            });
        }

        // ─── Core Helpers ──────────────────────────────────────────────────────

        /// <summary>
        /// Opens (and immediately closes) a SQL connection. Returns success flag + error message.
        /// Runs on a background thread so the UI never freezes.
        /// </summary>
        private static Task<(bool Success, string? ErrorMessage)> TestConnectionAsync(string connectionString)
        {
            return Task.Run(() =>
            {
                try
                {
                    using var conn = new SqlConnection(connectionString);
                    conn.Open();
                    return (true, (string?)null);
                }
                catch (Exception ex)
                {
                    return (false, ex.Message);
                }
            });
        }

        /// <summary>
        /// Reads an appsettings.json file and extracts the "ConnectionStrings" section.
        /// </summary>
        private static Dictionary<string, string>? ParseConnectionStrings(string filePath)
        {
            string json = File.ReadAllText(filePath);
            using var doc = JsonDocument.Parse(json);

            if (!doc.RootElement.TryGetProperty("ConnectionStrings", out JsonElement csElement))
                return null;

            var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var prop in csElement.EnumerateObject())
            {
                string? value = prop.Value.GetString();
                if (!string.IsNullOrWhiteSpace(value))
                    result[prop.Name] = value;
            }
            return result;
        }

        /// <summary>
        /// Appends a row to the results grid with colour coding.
        /// </summary>
        private void AddResultRow(string name, bool success, string? error)
        {
            int idx = dgvResults.Rows.Add(
                name,
                success ? "✔  Success" : "✘  Failed",
                error ?? string.Empty
            );

            DataGridViewRow row = dgvResults.Rows[idx];
            DataGridViewCell statusCell = row.Cells[1];

            if (success)
            {
                statusCell.Style.ForeColor = Color.DarkGreen;
            }
            else
            {
                statusCell.Style.ForeColor = Color.DarkRed;
                row.Cells[2].Style.ForeColor = Color.DarkRed;
            }
        }
    }
}
