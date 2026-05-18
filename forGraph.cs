using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.Measure;
using SkiaSharp;

namespace PantawidPasada
{
    public class forGraph
    {
        public void SetupPriceChart(CartesianChart chart, string brand)
        {
            string connStr = dataBaseDetails.connStr;

            var dieselValues = new List<double>();
            var unleadedValues = new List<double>();
            var premValues = new List<double>();
            var labels = new List<string>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"
                    SELECT dateToday, dieselPrice, unleadedPrice, premiumUnleadedPrice
                    FROM fuelPrice
                    WHERE fuelStationName = @brand
                    ORDER BY dateToday ASC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@brand", brand);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime date = Convert.ToDateTime(reader["dateToday"]);
                            labels.Add(date.ToString("MMM dd"));

                            dieselValues.Add(SafeDouble(reader["dieselPrice"]));
                            unleadedValues.Add(SafeDouble(reader["unleadedPrice"]));
                            premValues.Add(SafeDouble(reader["premiumUnleadedPrice"]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading chart: " + ex.Message);
                return;
            }

            // =========================
            // SERIES (WITH COLORS + LEGEND NAMES)
            // =========================
            chart.Series = new ISeries[]
            {
                new LineSeries<double>
                {
                    Name = "Diesel",
                    Values = dieselValues,
                    GeometrySize = 8,
                    Stroke = new SolidColorPaint(SKColors.Red, 3),
                    Fill = null
                },
                new LineSeries<double>
                {
                    Name = "Unleaded",
                    Values = unleadedValues,
                    GeometrySize = 8,
                    Stroke = new SolidColorPaint(SKColors.Blue, 3),
                    Fill = null
                },
                new LineSeries<double>
                {
                    Name = "Premium",
                    Values = premValues,
                    GeometrySize = 8,
                    Stroke = new SolidColorPaint(SKColors.Green, 3),
                    Fill = null
                }
            };

            // =========================
            // X AXIS (DATES)
            // =========================
            chart.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = labels,
                    Name = "Date",
                    LabelsRotation = 15,
                    TextSize = 12
                }
            };

            // =========================
            // Y AXIS (INCREMENT = 1 FIX)
            // =========================
            chart.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Price (₱)",
                    TextSize = 12,

                    // 🔥 THIS IS THE IMPORTANT PART
                    MinStep = 1
                }
            };

            // =========================
            // LEGEND
            // =========================
            chart.LegendPosition = LegendPosition.Right;

            // =========================
            // TOOLTIP
            // =========================
            chart.TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Top;
        }

        // SAFE CONVERTER
        private double SafeDouble(object value)
        {
            return value == DBNull.Value ? 0 : Convert.ToDouble(value);
        }
    }
}