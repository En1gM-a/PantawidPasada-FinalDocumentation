using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace PantawidPasada
{
    /// <summary>
    /// Handles authentication for all user roles in the application:
    /// drivers, administrators, government users, and fuel editors.
    /// Credentials are hashed with SHA-256 before being compared against the database.
    /// </summary>
    public class loginCheck
    {
        private string connStr = dataBaseDetails.connStr;

        // Shared instances used across login checks
        UserData userData = new UserData();
        adminAcc adminData = new adminAcc();
        govData dataGov = new govData();
        HashPassword hash = new HashPassword();

        /// <summary>
        /// Holds an error code when login fails for a specific reason.
        /// Set to "deactivated" when the account exists but has been disabled.
        /// Empty string when the failure is simply incorrect credentials.
        /// </summary>
        public string LoginError { get; private set; } = "";

        /// <summary>
        /// Validates driver credentials against the <c>driverAccs</c> table.
        /// On success, fills the provided <paramref name="data"/> object with all
        /// driver profile fields from the database row.
        /// </summary>
        /// <param name="username">The username entered on the login form.</param>
        /// <param name="password">The plain-text password entered on the login form.</param>
        /// <param name="data">A <see cref="UserData"/> object to populate on successful login.</param>
        /// <returns><c>true</c> if credentials match a database record; otherwise <c>false</c>.</returns>
        protected bool CheckLoginUser(string? username, string? password, UserData data)
        {
            try
            {
                string hashedPassword = hash.HashPass(password);

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = "SELECT * FROM driverAccs WHERE usernameUser=@username AND passwordUser=@password";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            // Populate the UserData object with all fields from the matched row
                            data.FirstName = reader["first_name"].ToString();
                            data.LastName = reader["last_name"].ToString();
                            data.MiddleName = reader["middle_name"].ToString();
                            data.Address = reader["address"].ToString();
                            data.Province = reader["province"].ToString();
                            data.Phone = reader["phone_num"].ToString();
                            data.Email = reader["email"].ToString();
                            data.username = reader["usernameUser"].ToString();
                            data.Password = reader["passwordUser"].ToString();
                            data.Income = reader["income"].ToString();
                            data.EmploymentType = reader["employment_type"].ToString();
                            data.SourceOfIncome = reader["source_of_income"].ToString();
                            data.FinancialObligation = reader["finan_ob"].ToString();
                            data.PlateNumber = reader["plate_number"].ToString();
                            data.LicenseNumber = reader["lic_num"].ToString();
                            data.VehicleType = reader["vehicle_type"].ToString();
                            data.subsidyStatus = reader["subsidy_stats"].ToString();
                            data.createDay = reader["created_at"].ToString();
                            data.reason = reader["reason"].ToString();

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking login: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Validates administrator credentials against the <c>admins</c> table.
        /// On success, fills the provided <paramref name="data"/> object with admin profile fields.
        /// Sets <see cref="LoginError"/> to "deactivated" if the account status is Deactivated.
        /// </summary>
        /// <param name="username">The username entered on the login form.</param>
        /// <param name="password">The plain-text password entered on the login form.</param>
        /// <param name="data">An <see cref="adminAcc"/> object to populate on successful login.</param>
        /// <returns>
        /// <c>true</c> if credentials are valid and the account is active; otherwise <c>false</c>.
        /// </returns>
        protected bool CheckLoginAdmin(string? username, string? password, adminAcc data)
        {
            try
            {
                string hashedPassword = hash.HashPass(password);

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = "SELECT * FROM admins WHERE UsernameAdmin=@username AND PasswordAdmin=@password";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            // Populate the adminAcc object with all fields from the matched row
                            data.FirstName = reader["FirstName"].ToString();
                            data.LastName = reader["LastName"].ToString();
                            data.MiddleInit = reader["MiddleInitial"].ToString();
                            data.role = reader["RoleAdmin"].ToString();
                            data.username = reader["UsernameAdmin"].ToString();
                            data.email = reader["email"].ToString();
                            data.phoneNum = reader["contactNum"].ToString();
                            data.createDay = reader["CreatedAt"].ToString();
                            data.status = reader["adminStatus"].ToString();

                            // Block login if the account has been deactivated by a super admin
                            if (reader["adminStatus"].ToString() == "Deactivated")
                            {
                                LoginError = "deactivated";
                                return false;
                            }

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking login: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Validates government user credentials against the <c>govAccs</c> table.
        /// On success, fills the provided <paramref name="data"/> object with the government user's profile.
        /// Sets <see cref="LoginError"/> to "deactivated" if the account status is Deactivated.
        /// </summary>
        /// <param name="username">The username entered on the login form.</param>
        /// <param name="password">The plain-text password entered on the login form.</param>
        /// <param name="data">A <see cref="govData"/> object to populate on successful login.</param>
        /// <returns>
        /// <c>true</c> if credentials are valid and the account is active; otherwise <c>false</c>.
        /// </returns>
        protected bool CheckLoginGov(string? username, string? password, govData data)
        {
            try
            {
                string hashedPassword = hash.HashPass(password);

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = "SELECT * FROM govAccs WHERE Username=@username AND Password=@password";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            // Populate the govData object with all fields from the matched row
                            data.firstName = reader["FirstName"].ToString();
                            data.lastName = reader["LastName"].ToString();
                            data.middleInit = reader["MiddleInitial"].ToString();
                            data.agency = reader["Agency"].ToString();
                            data.username = reader["Username"].ToString();
                            data.govStats = reader["govStatus"].ToString();
                            data.contactNum = reader["contactNum"].ToString();
                            data.email = reader["email"].ToString();
                            data.createDay = reader["CreatedAt"].ToString();

                            // Block login if the government account has been deactivated
                            if (reader["govStatus"].ToString() == "Deactivated")
                            {
                                LoginError = "deactivated";
                                return false;
                            }

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking login: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Validates fuel editor credentials against the <c>fuelEditors</c> table.
        /// On success, fills the provided <paramref name="data"/> object with the editor's profile.
        /// Sets <see cref="LoginError"/> to "deactivated" if the account status is Deactivated.
        /// </summary>
        /// <param name="username">The username entered on the login form.</param>
        /// <param name="password">The plain-text password entered on the login form.</param>
        /// <param name="data">A <see cref="fuelEditorData"/> object to populate on successful login.</param>
        /// <returns>
        /// <c>true</c> if credentials are valid and the account is active; otherwise <c>false</c>.
        /// </returns>
        protected bool CheckLoginFuelEditor(string? username, string? password, fuelEditorData data)
        {
            try
            {
                string hashedPassword = hash.HashPass(password);
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"
                SELECT * 
                FROM fuelEditors 
                WHERE username = @username 
                AND password = @password";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            // Populate the fuelEditorData object with fields from the matched row
                            data.editor_id = Convert.ToInt32(reader["editor_id"]);
                            data.name = reader["name"].ToString();
                            data.username = reader["username"].ToString();
                            data.status = reader["status"].ToString();

                            // Block login if the fuel editor account has been deactivated
                            if (data.status == "Deactivated")
                            {
                                LoginError = "deactivated";
                                return false;
                            }

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking fuel editor login: " + ex.Message);
                return false;
            }
        }

        // ── Public API ────────────────────────────────────────────────────────

        /// <summary>Authenticates a driver/user account. See <see cref="CheckLoginUser"/>.</summary>
        public bool loginUser(string? user, string? pass, UserData data)
        {
            return CheckLoginUser(user, pass, data);
        }

        /// <summary>Authenticates an administrator account. See <see cref="CheckLoginAdmin"/>.</summary>
        public bool loginAdmin(string? user, string? pass, adminAcc data)
        {
            return CheckLoginAdmin(user, pass, data);
        }

        /// <summary>Authenticates a government user account. See <see cref="CheckLoginGov"/>.</summary>
        public bool loginGov(string? user, string? pass, govData data)
        {
            return CheckLoginGov(user, pass, data);
        }

        /// <summary>Authenticates a fuel editor account. See <see cref="CheckLoginFuelEditor"/>.</summary>
        public bool loginFuelEditor(string? user, string? pass, fuelEditorData data)
        {
            return CheckLoginFuelEditor(user, pass, data);
        }
    }
}
