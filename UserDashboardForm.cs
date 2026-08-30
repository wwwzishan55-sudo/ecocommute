using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EcoCommuteTracker
{
    public partial class UserDashboardForm : Form
    {
        // Rough, widely-cited conversion constants used for the "what this means" figures.
        // A mature tree absorbs roughly this much CO2 per year:
        private const double KgCo2PerTreeYear = 21.0;
        // Burning 1 liter of gasoline produces roughly this much CO2:
        private const double KgCo2PerLiterGasoline = 2.31;

        public UserDashboardForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(UserDashboardForm_Load);
        }

        private void UserDashboardForm_Load(object sender, EventArgs e)
        {
            LoadUserSummary();
            LoadSavingsChart();
        }

        private void LoadUserSummary()
        {
            try
            {
                using (SqlConnection con = DatabaseHelper.GetConnection())
                {
                    con.Open();

                    
                    string userQuery = "SELECT FullName FROM Users WHERE UserID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(userQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", LoginForm.LoggedInUserId);
                        object result = cmd.ExecuteScalar();
                        if (result != null && lblWelcome != null)
                        {
                            lblWelcome.Text = "Welcome, " + result.ToString() + "!";
                        }
                    }

                    
                    string savingsQuery = "SELECT ISNULL(SUM(CO2SavedKg), 0) FROM CarbonSavings WHERE UserID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(savingsQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", LoginForm.LoggedInUserId);
                        double totalSaved = Convert.ToDouble(cmd.ExecuteScalar());
                        if (lblTotalSavings != null)
                        {
                            lblTotalSavings.Text = "Total CO2 Saved: " + totalSaved.ToString("0.00") + " kg";
                        }

                        UpdateEcoEquivalents(totalSaved);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Translates a raw kg-of-CO2 number into more intuitive, relatable comparisons.
        /// </summary>
        private void UpdateEcoEquivalents(double totalCo2SavedKg)
        {
            if (lblTreesEquivalent == null || lblFuelEquivalent == null)
                return;

            double treeYears = totalCo2SavedKg / KgCo2PerTreeYear;
            double litersOfGasoline = totalCo2SavedKg / KgCo2PerLiterGasoline;

            lblTreesEquivalent.Text = $"🌳 Equivalent to {treeYears:0.0} tree-years of CO2 absorption";
            lblFuelEquivalent.Text = $"⛽ Equivalent to {litersOfGasoline:0.0} L of gasoline never burned";
        }

        /// <summary>
        /// Loads a per-transport-mode breakdown of the user's CO2 savings into the bar chart,
        /// using the System.Windows.Forms.DataVisualization.Charting reference that was already
        /// in the project file but never actually used anywhere.
        /// </summary>
        private void LoadSavingsChart()
        {
            if (chartSavings == null)
                return;

            try
            {
                using (SqlConnection con = DatabaseHelper.GetConnection())
                {
                    con.Open();

                    string query = @"
                        SELECT TransportMode, ISNULL(SUM(CO2SavedKg), 0) AS TotalCO2
                        FROM CarbonSavings
                        WHERE UserID = @UserID
                        GROUP BY TransportMode
                        ORDER BY TotalCO2 DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", LoginForm.LoggedInUserId);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            Series series = chartSavings.Series["CO2Series"];
                            series.Points.Clear();

                            if (dt.Rows.Count == 0)
                            {
                                // No commutes logged yet — leave the chart empty rather than erroring.
                                return;
                            }

                            foreach (DataRow row in dt.Rows)
                            {
                                string mode = row["TransportMode"].ToString();
                                double co2 = Convert.ToDouble(row["TotalCO2"]);
                                int pointIndex = series.Points.AddXY(mode, co2);
                                series.Points[pointIndex].Color = ColorForMode(mode);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the chart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static System.Drawing.Color ColorForMode(string mode)
        {
            switch (mode.ToLowerInvariant())
            {
                case "walking": return System.Drawing.Color.MediumSeaGreen;
                case "bicycle": return System.Drawing.Color.SteelBlue;
                case "bus": return System.Drawing.Color.Goldenrod;
                case "train": return System.Drawing.Color.MediumPurple;
                default: return System.Drawing.Color.Gray;
            }
        }

        private void btnLogCommute_Click(object sender, EventArgs e)
        {
            // Was previously wired to open the leaderboard by mistake.
            LogCommuteForm logForm = new LogCommuteForm();
            logForm.ShowDialog();
            LoadUserSummary();
            LoadSavingsChart();
        }

        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
            // Was previously wired to open the log-commute dialog by mistake.
            UserLeaderboardForm leaderboardForm = new UserLeaderboardForm();
            leaderboardForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm.LoggedInUserId = 0;
            LoginForm.LoggedInUserRole = "";
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            CommuteHistoryForm historyForm = new CommuteHistoryForm();
            historyForm.ShowDialog();

            LoadUserSummary();
            LoadSavingsChart();
        }
    }
}