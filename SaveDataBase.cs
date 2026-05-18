using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace PantawidPasada
{
    public class SaveDataBase
    {
        HashPassword hashPassword = new HashPassword();
        string connStr = dataBaseDetails.connStr;

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connStr);
        }

        protected bool SaveToDatabase(UserData data)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = @"INSERT INTO driverAccs
            (first_name, last_name, middle_name, address, province,
             phone_num, email, usernameUser, passwordUser,
             plate_number, lic_num, vehicle_type, subsidy_stats)
            VALUES
            (@fname, @lname, @mname, @address, @province,
             @phone, @email, @user, @password,
             @plate, @license, @vehicle, 'Not Requested')";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@fname", data.FirstName);
                    cmd.Parameters.AddWithValue("@lname", data.LastName);
                    cmd.Parameters.AddWithValue("@mname", data.MiddleName);
                    cmd.Parameters.AddWithValue("@address", data.Address);
                    cmd.Parameters.AddWithValue("@province", data.Province);
                    cmd.Parameters.AddWithValue("@phone", data.Phone);
                    cmd.Parameters.AddWithValue("@email", data.Email);
                    cmd.Parameters.AddWithValue("@user", data.username);
                    cmd.Parameters.AddWithValue("@password", hashPassword.HashPass(data.Password));
                    cmd.Parameters.AddWithValue("@plate", data.PlateNumber);
                    cmd.Parameters.AddWithValue("@license", data.LicenseNumber);
                    cmd.Parameters.AddWithValue("@vehicle", data.VehicleType);

                    cmd.ExecuteNonQuery();

                    return true; // ✅ SUCCESS
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        MessageBox.Show(
                            "This user already exists.\nReturning to start.",
                            "Account Exists",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return false; // ❌ FAILED
                    }

                    MessageBox.Show("Database error: " + ex.Message);
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool SaveToDB(UserData data)
        {
            return SaveToDatabase(data);
        }
    }
}