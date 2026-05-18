using Parquet;
using Parquet.Data;
using Parquet.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PantawidPasada
{
    class fuelPriceONLINE
    {
        private static string url = "https://storage.data.gov.my/commodities/fuelprice.parquet";
        private static string cacheFile = "fuelprice.parquet";

        public static async Task<List<fuelPriceData>> GetPricesAsync()
        {
            byte[] fileBytes;

            // 🔥 Download latest data
            byte[] newData;
            using (HttpClient client = new HttpClient())
            {
                newData = await client.GetByteArrayAsync(url);
            }

            // 🔥 Check cache
            if (!File.Exists(cacheFile))
            {
                await File.WriteAllBytesAsync(cacheFile, newData);
                fileBytes = newData;
            }
            else
            {
                byte[] oldData = await File.ReadAllBytesAsync(cacheFile);

                DateTime oldLatest = await GetLatestDate(oldData);
                DateTime newLatest = await GetLatestDate(newData);

                if (newLatest > oldLatest)
                {
                    await File.WriteAllBytesAsync(cacheFile, newData);
                    fileBytes = newData;
                }
                else
                {
                    fileBytes = oldData;
                }
            }

            // 🔥 Read parquet data
            List<fuelPriceData> prices = new List<fuelPriceData>();

            using (var ms = new MemoryStream(fileBytes))
            using (var reader = await ParquetReader.CreateAsync(ms))
            {
                DataField[] fields = reader.Schema.GetDataFields();

                var dateField = Array.Find(fields, f => f.Name.Equals("date", StringComparison.OrdinalIgnoreCase));
                var ron95Field = Array.Find(fields, f => f.Name.Equals("RON95", StringComparison.OrdinalIgnoreCase));
                var ron97Field = Array.Find(fields, f => f.Name.Equals("RON97", StringComparison.OrdinalIgnoreCase));
                var dieselField = Array.Find(fields, f => f.Name.Equals("Diesel", StringComparison.OrdinalIgnoreCase));

                for (int i = 0; i < reader.RowGroupCount; i++)
                {
                    using (var rowGroupReader = reader.OpenRowGroupReader(i))
                    {
                        var dateCol = await rowGroupReader.ReadColumnAsync(dateField);
                        var ron95Col = await rowGroupReader.ReadColumnAsync(ron95Field);
                        var ron97Col = await rowGroupReader.ReadColumnAsync(ron97Field);
                        var dieselCol = await rowGroupReader.ReadColumnAsync(dieselField);

                        for (int r = 0; r < dateCol.Data.Length; r++)
                        {
                            prices.Add(new fuelPriceData
                            {
                                Date = DateTime.Parse(dateCol.Data.GetValue(r).ToString()),
                                RON95PriceOnline = Convert.ToDouble(ron95Col.Data.GetValue(r)),
                                RON97PriceOnline = Convert.ToDouble(ron97Col.Data.GetValue(r)),
                                dieselPriceOnline = Convert.ToDouble(dieselCol.Data.GetValue(r))
                            });
                        }
                    }
                }
            }

            return prices;
        }

        // 🔥 FIXED (FULLY ASYNC, NO .Result)
        private static async Task<DateTime> GetLatestDate(byte[] fileBytes)
        {
            using (var ms = new MemoryStream(fileBytes))
            using (var reader = await ParquetReader.CreateAsync(ms))
            {
                var field = Array.Find(reader.Schema.GetDataFields(), f => f.Name == "date");

                using (var groupReader = reader.OpenRowGroupReader(reader.RowGroupCount - 1))
                {
                    var column = await groupReader.ReadColumnAsync(field);
                    int lastIndex = column.Data.Length - 1;

                    return DateTime.Parse(column.Data.GetValue(lastIndex).ToString());
                }
            }
        }

        // 🔥 Get most recent 2 entries
        public static List<fuelPriceData> GetRecentPrices(List<fuelPriceData> prices)
        {
            prices.Sort((a, b) => b.Date.CompareTo(a.Date));

            List<fuelPriceData> result = new List<fuelPriceData>();

            if (prices.Count > 0) result.Add(prices[0]);
            if (prices.Count > 1) result.Add(prices[1]);

            return result;
        }
    }
}