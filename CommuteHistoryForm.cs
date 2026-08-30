using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace EcoCommuteTracker
{
    public partial class CommuteHistoryForm : Form
    {
        public CommuteHistoryForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(CommuteHistoryForm_Load);
        }

        private void CommuteHistoryForm_Load(object sender, EventArgs e)
        {
            
            dtpFrom.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;

            LoadHistory();
        }

        private void LoadHistory()
        {
            try
            {
                using (SqlConnection con = DatabaseHelper.GetConnection())
                {
                    con.Open();

                    
                    string query = @"
                SELECT 
                    SavingsID AS [ID],
                    TransportMode AS [Transport Mode], 
                    DistanceKm AS [Distance (km)], 
                    CO2SavedKg AS [CO2 Saved (kg)], 
                    ISNULL(LogDate, GETDATE()) AS [Date]
                FROM CarbonSavings
                WHERE UserID = @UserID 
                  AND (LogDate >= @FromDate AND LogDate <= @ToDate OR LogDate IS NULL)
                ORDER BY LogDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", LoginForm.LoggedInUserId);
                        cmd.Parameters.AddWithValue("@FromDate", dtpFrom.Value.Date);
                        cmd.Parameters.AddWithValue("@ToDate", dtpTo.Value.Date.AddDays(1).AddTicks(-1));

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvHistory.AutoGenerateColumns = true;
                        dgvHistory.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadHistory();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            if (dgvHistory.SelectedRows.Count > 0)
            {
                int selectedSavingsId = Convert.ToInt32(dgvHistory.SelectedRows[0].Cells["ID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this commute record?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteRecord(selectedSavingsId);
                }
            }
            else
            {
                MessageBox.Show("Please select a full row to delete.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteRecord(int savingsId)
        {
            try
            {
                using (SqlConnection con = DatabaseHelper.GetConnection())
                {
                    con.Open();
                    string query = "DELETE FROM CarbonSavings WHERE SavingsID = @SavingsID AND UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@SavingsID", savingsId);
                        cmd.Parameters.AddWithValue("@UserID", LoginForm.LoggedInUserId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Commute record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHistory(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvHistory.Rows.Count == 0)
            {
                MessageBox.Show("No commute data available to export!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV File (*.csv)|*.csv";
            saveFileDialog.FileName = "EcoCommute_History_Report.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    
                    for (int i = 0; i < dgvHistory.Columns.Count; i++)
                    {
                        sb.Append(dgvHistory.Columns[i].HeaderText);
                        if (i < dgvHistory.Columns.Count - 1)
                            sb.Append(",");
                    }
                    sb.AppendLine();

                    
                    foreach (DataGridViewRow row in dgvHistory.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < dgvHistory.Columns.Count; i++)
                            {
                                string cellValue = row.Cells[i].Value?.ToString() ?? "";
                                sb.Append($"\"{cellValue}\""); 

                                if (i < dgvHistory.Columns.Count - 1)
                                    sb.Append(",");
                            }
                            sb.AppendLine();
                        }
                    }

                    
                    File.WriteAllText(saveFileDialog.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show("Report exported successfully to CSV!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}