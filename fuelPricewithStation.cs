using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PantawidPasada
{
    public class fuelPricewithStation
    {
        public string StationName { get; set; }
        public string Area { get; set; }
        public DateTime DateOfPrice { get; set; }
        public double dieselPrice { get; set; }
        public double unleadedPrice { get; set; }
        public double premUnleadedPrice { get; set; }

        string connStr = dataBaseDetails.connStr;

        // =========================
        // SAVE TO DATABASE
        // =========================
        private void SaveFuelToDatabase(fuelPricewithStation fuelData)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO fuelPrice
                        (fuelStationName, area, dieselPrice, unleadedPrice, premiumUnleadedPrice, dateToday)
                        VALUES
                        (@station, @area, @diesel, @unleaded, @premium, @date)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@station", fuelData.StationName);
                    cmd.Parameters.AddWithValue("@area", fuelData.Area);
                    cmd.Parameters.AddWithValue("@diesel", fuelData.dieselPrice);
                    cmd.Parameters.AddWithValue("@unleaded", fuelData.unleadedPrice);
                    cmd.Parameters.AddWithValue("@premium", fuelData.premUnleadedPrice);
                    cmd.Parameters.AddWithValue("@date", fuelData.DateOfPrice);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving fuel price: " + ex.Message, "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =========================
        // ADD FUEL PRICE (PUBLIC)
        // =========================
        public void AddFuelPriceData(string stationName, string area, double dieselPrice,
            double unleadedPrice, double premiumUnleadedPrice, DateTime dateNow)
        {
            fuelPricewithStation newFuelData = new fuelPricewithStation
            {
                StationName = stationName,
                Area = area,
                dieselPrice = dieselPrice,
                unleadedPrice = unleadedPrice,
                premUnleadedPrice = premiumUnleadedPrice,
                DateOfPrice = dateNow
            };
            SaveFuelToDatabase(newFuelData);
        }

        // =========================
        // LOAD MOST RECENT PRICES
        // =========================
        public List<fuelPricewithStation> LoadMostRecent()
        {
            List<fuelPricewithStation> list = new List<fuelPricewithStation>();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT fp.*
                        FROM fuelPrice fp
                        INNER JOIN (
                            SELECT fuelStationName, MAX(dateToday) AS latestDate
                            FROM fuelPrice
                            GROUP BY fuelStationName
                        ) latest
                        ON fp.fuelStationName = latest.fuelStationName
                        AND fp.dateToday = latest.latestDate";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new fuelPricewithStation
                        {
                            StationName = reader["fuelStationName"].ToString(),
                            Area = reader["area"].ToString(),
                            dieselPrice = Convert.ToDouble(reader["dieselPrice"]),
                            unleadedPrice = Convert.ToDouble(reader["unleadedPrice"]),
                            premUnleadedPrice = Convert.ToDouble(reader["premiumUnleadedPrice"]),
                            DateOfPrice = Convert.ToDateTime(reader["dateToday"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading fuel prices: " + ex.Message, "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return list;
        }

        // =========================
        // LOAD SECOND MOST RECENT
        // =========================
        public List<fuelPricewithStation> LoadSecondMostRecent()
        {
            List<fuelPricewithStation> list = new List<fuelPricewithStation>();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT fp.*
                        FROM fuelPrice fp
                        INNER JOIN (
                            SELECT fuelStationName, MAX(dateToday) AS secondDate
                            FROM fuelPrice
                            WHERE dateToday < (
                                SELECT MAX(dateToday)
                                FROM fuelPrice fp2
                                WHERE fp2.fuelStationName = fuelPrice.fuelStationName
                            )
                            GROUP BY fuelStationName
                        ) second
                        ON fp.fuelStationName = second.fuelStationName
                        AND fp.dateToday = second.secondDate";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new fuelPricewithStation
                        {
                            StationName = reader["fuelStationName"].ToString(),
                            Area = reader["area"].ToString(),
                            dieselPrice = Convert.ToDouble(reader["dieselPrice"]),
                            unleadedPrice = Convert.ToDouble(reader["unleadedPrice"]),
                            premUnleadedPrice = Convert.ToDouble(reader["premiumUnleadedPrice"]),
                            DateOfPrice = Convert.ToDateTime(reader["dateToday"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading previous fuel prices: " + ex.Message, "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return list;
        }

        // =========================
        // LOAD BY DATE
        // =========================
        public List<fuelPricewithStation> LoadByDate(DateTime selectedDate)
        {
            List<fuelPricewithStation> list = new List<fuelPricewithStation>();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT * FROM fuelPrice
                        WHERE DATE(dateToday) = @date";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@date", selectedDate.ToString("yyyy-MM-dd"));
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new fuelPricewithStation
                        {
                            StationName = reader["fuelStationName"].ToString(),
                            Area = reader["area"].ToString(),
                            dieselPrice = Convert.ToDouble(reader["dieselPrice"]),
                            unleadedPrice = Convert.ToDouble(reader["unleadedPrice"]),
                            premUnleadedPrice = Convert.ToDouble(reader["premiumUnleadedPrice"]),
                            DateOfPrice = Convert.ToDateTime(reader["dateToday"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading fuel prices by date: " + ex.Message, "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return list;
        }

        // =========================
        // PRICE CHANGE CALCULATIONS
        // =========================
        public double GetDieselChange(string stationName)
        {
            var recent = LoadMostRecent().Find(f => f.StationName == stationName);
            var previous = LoadSecondMostRecent().Find(f => f.StationName == stationName);

            if (recent == null || previous == null) return 0;
            return recent.dieselPrice - previous.dieselPrice;
        }

        public double GetUnleadedChange(string stationName)
        {
            var recent = LoadMostRecent().Find(f => f.StationName == stationName);
            var previous = LoadSecondMostRecent().Find(f => f.StationName == stationName);

            if (recent == null || previous == null) return 0;
            return recent.unleadedPrice - previous.unleadedPrice;
        }

        public double GetPremiumChange(string stationName)
        {
            var recent = LoadMostRecent().Find(f => f.StationName == stationName);
            var previous = LoadSecondMostRecent().Find(f => f.StationName == stationName);

            if (recent == null || previous == null) return 0;
            return recent.premUnleadedPrice - previous.premUnleadedPrice;
        }

        // =========================
        // HELPER - FORMAT CHANGE
        // =========================
        public string FormatChange(double change)
        {
            if (change > 0) return $"▲ +{change:F2}";
            if (change < 0) return $"▼ {change:F2}";
            return "— no change";
        }
    }
}