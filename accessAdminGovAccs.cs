using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PantawidPasada
{
    public class accessAdminGovAccs
    {
        private void LoadAdmins(DataGridView datagrid)
        {
            string connStr = dataBaseDetails.connStr;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
                SELECT 
                    AdminID,
                    LastName AS 'Last Name',
                    FirstName AS 'First Name',
                    IFNULL(LEFT(MiddleInitial, 1), '') AS 'M.I',
                    adminStatus AS 'Admin Status'
                FROM admins";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

               

                datagrid.DataSource = dt;

                if (datagrid.Columns.Contains("AdminID"))
                {
                    datagrid.Columns["AdminID"].Visible = false;
                }
            }
        }



        private void LoadGovs(DataGridView datagrid)
        {
            string connStr = dataBaseDetails.connStr;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
                SELECT 
                    GovID,
                    LastName AS 'Last Name',
                    FirstName AS 'First Name',
                    IFNULL(LEFT(MiddleInitial, 1), '') AS 'M.I',
                    govStatus AS 'Government Status'
                FROM govAccs";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                

                datagrid.DataSource = dt;

                if (datagrid.Columns.Contains("GovID"))
                {
                    datagrid.Columns["GovID"].Visible = false;
                }
            }
        }

        public void LoadAdminsToDataGrid(DataGridView datagrid)
        {
            LoadAdmins(datagrid);
        }

        public void LoadGovsToDataGrid(DataGridView datagrid)
        {
            LoadGovs(datagrid);
        }
    }
}
