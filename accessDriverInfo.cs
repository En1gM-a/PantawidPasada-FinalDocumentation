using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PantawidPasada
{
    public class accessDriverInfo
    {
        private void LoadDrivers(DataGridView datagrid)
        {
            string connStr = dataBaseDetails.connStr;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
                SELECT 
                    driver_id,
                    last_name AS 'Last Name',
                    first_name AS 'First Name',
                    IFNULL(LEFT(middle_name, 1), '') AS 'M.I',
                    email as 'Email',
                    subsidy_stats AS 'Subsidy Status'
                FROM driverAccs
                WHERE subsidy_stats IN ('Pending', 'Under Review', 'On Hold')";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                datagrid.DataSource = dt;
                if (datagrid.Columns.Contains("driver_id"))
                {
                    datagrid.Columns["driver_id"].Visible = false;
                    datagrid.Columns["Email"].Visible = false;
                }
            }
        }

        private void LoadDriversApproved(DataGridView datagrid)
        {
            string connStr = dataBaseDetails.connStr;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
                SELECT 
    driver_id,
    last_name AS 'Last Name',
    first_name AS 'First Name',
    IFNULL(LEFT(middle_name, 1), '') AS 'M.I',
    subsidy_stats AS 'Subsidy Status'
FROM driverAccs
WHERE subsidy_stats = 'Approved';";
                

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                datagrid.DataSource = dt;
                if (datagrid.Columns.Contains("driver_id"))
                {
                    datagrid.Columns["driver_id"].Visible = false;
                }
            }
        }

        public int GetTotalApprovedDrivers()
        {
            string connStr = dataBaseDetails.connStr;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM driverAccs WHERE subsidy_stats = 'Approved'";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void LoadDriversToDataGrid(DataGridView datagrid)
        {
            LoadDrivers(datagrid);
        }

        public void LoadApprovedDriversToDataGrid(DataGridView datagrid)
        {
            LoadDriversApproved(datagrid);
        }
    }
}
