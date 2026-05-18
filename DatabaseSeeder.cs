using MySql.Data.MySqlClient;
using System;

namespace PantawidPasada
{
    /// <summary>
    /// Provides database seeding utilities for populating test or initial data
    /// into the application's database tables.
    /// </summary>
    public class DatabaseSeeder
    {
        /// <summary>
        /// Seeds the <c>govAccs</c> table with 50 randomly generated government accounts.
        /// Each account is assigned a random name, agency (DOTr, DOH, DPWH, or DSWD),
        /// contact number, email, and either an Active or Deactivated status.
        /// All accounts share the same hashed default password ("wowowin").
        /// 
        /// Intended for development and testing purposes only.
        /// </summary>
        public void SeedGovAccounts()
        {
            string connStr = dataBaseDetails.connStr;
            HashPassword hasher = new HashPassword();
            Random rand = new Random();

            // Pool of Filipino first and last names used for random name generation
            string[] firstNames = {
                "Juan","Maria","Jose","Ana","Luis","Mark","Carlo","Daniel","Francis","Kevin",
                "Angela","Rose","Carla","Stephanie","Liza","Hazel","Irene","Karen","Beverly","Donna",
                "Arnold","Gilbert","Hector","Alvin","Dennis","Rodel","Cesar","Rogelio","Michael","Patrick"
            };

            string[] lastNames = {
                "Santos","Reyes","Cruz","Garcia","Bautista","Flores","Mendoza","Ramos","Torres","Rivera",
                "Lopez","Gonzales","Aquino","Castro","Navarro","Villanueva","Herrera","Vega","Salazar","Perez"
            };

            // Government agencies that can be assigned to seeded accounts
            string[] agencies = {
                "DOTr","DOH","DPWH","DSWD"
            };

            // Possible account statuses
            string[] statuses = {
                "Active","Deactivated"
            };

            // Hash the shared default password once to avoid re-hashing on every iteration
            string hashedPass = hasher.HashPass("wowowin");

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                // Insert 50 randomized government accounts
                for (int i = 0; i < 50; i++)
                {
                    string first = firstNames[rand.Next(firstNames.Length)];
                    string last = lastNames[rand.Next(lastNames.Length)];
                    // Single uppercase letter used as middle initial
                    string middle = ((char)('A' + rand.Next(0, 26))).ToString();

                    // Append a short unique suffix to prevent duplicate usernames
                    string unique = Guid.NewGuid().ToString("N").Substring(0, 5);

                    string username = $"gov_{first.ToLower()}{last.ToLower()}{unique}";
                    string email = $"{username}@gov.ph";
                    // Generate a random Philippine mobile number starting with "09"
                    string contact = "09" + rand.Next(100000000, 999999999);

                    string query = @"
                    INSERT INTO govAccs
                    (FirstName, LastName, MiddleInitial, Agency,
                     Username, Password, govStatus, contactNum, email)
                    VALUES
                    (@first, @last, @middle, @agency,
                     @username, @password, @status, @contact, @email)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@first", first);
                    cmd.Parameters.AddWithValue("@last", last);
                    cmd.Parameters.AddWithValue("@middle", middle);
                    cmd.Parameters.AddWithValue("@agency", agencies[rand.Next(agencies.Length)]);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPass);
                    cmd.Parameters.AddWithValue("@status", statuses[rand.Next(statuses.Length)]);
                    cmd.Parameters.AddWithValue("@contact", contact);
                    cmd.Parameters.AddWithValue("@email", email);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
