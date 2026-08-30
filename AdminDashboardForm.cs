using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EcoCommuteTracker
{
    public partial class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();

            
            LoadAdminSummary();
            LoadUserList();
        }

        private void LoadAdminSummary()
        {
            try
            {
                using (SqlConnection con = DatabaseHelper.GetConnection())
                {
                    con.Open();

                    
                    string userCountQuery = "SELECT COUNT(*) FROM Users WHERE Role = 'User'";
                    using (SqlCommand cmd = new SqlCommand(userCountQuery, con))
                    {
                        int totalUsers = (int)cmd.ExecuteScalar();
                        lblTotalUsers.Text = "Total Users: " + totalUsers;
                    }

                    
                    string co2Query = "SELECT ISNULL(SUM(CO2SavedKg), 0) FROM CarbonSavings";
                    using (SqlCommand cmd = new SqlCommand(co2Query, con))
                    {
                        double totalCO2 = Convert.ToDouble(cmd.ExecuteScalar());
                        lblTotalCO2.Text = "Total System CO2 Saved: " + totalCO2.ToString("0.00") + " kg";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading dashboard stats: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserList()
        {
            try
            {
                using (SqlConnection con = DatabaseHelper.GetConnection())
                {
                    con.Open();

                    
                    string query = @"
                        SELECT 
                            U.UserID, 
                            U.FullName AS [Full Name], 
                            U.Department, 
                            U.Email, 
                            ISNULL(SUM(C.CO2SavedKg), 0) AS [Total CO2 Saved (kg)]
                        FROM Users U
                        LEFT JOIN CarbonSavings C ON U.UserID = C.UserID
                        WHERE U.Role = 'User'
                        GROUP BY U.UserID, U.FullName, U.Department, U.Email";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                       
                        dgvUsersSummary.AutoGenerateColumns = true;
                        dgvUsersSummary.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading user list: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm.LoggedInUserId = 0;
            LoginForm.LoggedInUserRole = "";
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void dgvUsersSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

    }
}