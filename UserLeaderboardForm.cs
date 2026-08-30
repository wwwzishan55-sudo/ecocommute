using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EcoCommuteTracker
{
    public partial class UserLeaderboardForm : Form
    {
        public UserLeaderboardForm()
        {
            InitializeComponent();
        }

        private void UserLeaderboardForm_Load(object sender, EventArgs e)
        {
            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            try
            {
                using (SqlConnection con = DatabaseHelper.GetConnection())
                {
                    con.Open();
                    
                    string query = @"
                        SELECT 
                            U.FullName AS [User Name],
                            U.Department AS [Department],
                            ISNULL(SUM(C.CO2SavedKg), 0) AS [Total CO2 Saved (kg)]
                        FROM Users U
                        LEFT JOIN CarbonSavings C ON U.UserID = C.UserID
                        GROUP BY U.UserID, U.FullName, U.Department
                        ORDER BY [Total CO2 Saved (kg)] DESC";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLeaderboard.DataSource = dt; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the leaderboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLeaderboard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}