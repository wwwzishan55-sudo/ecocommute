using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EcoCommuteTracker
{
    public partial class LogCommuteForm : Form
    {
        public LogCommuteForm()
        {
            InitializeComponent();
        }

        private void btnSaveCommute_Click(object sender, EventArgs e)
        {
            
            if (cmbTransportMode.SelectedItem == null || string.IsNullOrWhiteSpace(txtDistance.Text))
            {
                MessageBox.Show("Please select a transport mode and enter the distance!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtDistance.Text.Trim(), out double distance) || distance <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for distance!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mode = cmbTransportMode.SelectedItem.ToString();

            // Sanity check: flag unrealistic distances instead of silently accepting them
            // (e.g. "500 km on foot") so bad data doesn't quietly inflate the leaderboard.
            bool isHumanPowered = mode.Equals("Walking", StringComparison.OrdinalIgnoreCase) ||
                                   mode.Equals("Bicycle", StringComparison.OrdinalIgnoreCase);
            double maxReasonableKm = isHumanPowered ? 100 : 500;

            if (distance > maxReasonableKm)
            {
                DialogResult confirm = MessageBox.Show(
                    $"{distance:0.#} km by {mode} looks unusually high. Save it anyway?",
                    "Check your distance",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.No)
                    return;
            }

            double co2SavedPerKm;

            // Compared case-insensitively so mismatched casing (e.g. "walking" vs "Walking")
            // can never again silently fall through to the 0.0 default.
            switch (mode.ToLowerInvariant())
            {
                case "walking":
                case "bicycle":
                    co2SavedPerKm = 0.192;
                    break;
                case "bus":
                    co2SavedPerKm = 0.103;
                    break;
                case "train":
                    co2SavedPerKm = 0.151;
                    break;
                default:
                    co2SavedPerKm = 0.0;
                    break;
            }

            double totalCo2Saved = distance * co2SavedPerKm;

            try
            {
                using (SqlConnection con = DatabaseHelper.GetConnection())
                {
                    con.Open();
                    // Column is LogDate (not CommuteDate) to match what CommuteHistoryForm and
                    // the rest of the app read from — previously these were out of sync, so every
                    // logged commute had a NULL LogDate and skipped the history date filter.
                    string query = "INSERT INTO CarbonSavings (UserID, TransportMode, DistanceKm, CO2SavedKg, LogDate) VALUES (@UserID, @Mode, @Distance, @CO2Saved, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", LoginForm.LoggedInUserId);
                        cmd.Parameters.AddWithValue("@Mode", mode);
                        cmd.Parameters.AddWithValue("@Distance", distance);
                        cmd.Parameters.AddWithValue("@CO2Saved", totalCo2Saved);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Commute logged successfully! You saved {totalCo2Saved:0.00} kg of CO2.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogCommuteForm_Load(object sender, EventArgs e)
        {

        }
    }
}