using System;
using System.Collections.Generic;
using System.Text;

namespace PantawidPasada
{
    internal class fuelPriceData
    {
        public DateTime Date { get; set; }
        public double RON95PriceOnline { get; set; }
        public double RON97PriceOnline { get; set; }
        public double dieselPriceOnline { get; set; }

        public double fareCalculation(double dieselPriceOnline, double fuelConsumptionPerKm)
        {
            double baseDistance = 1.5;
            

            double costPerKm = fuelConsumptionPerKm * dieselPriceOnline;
            double baseFare = baseDistance * costPerKm;

            return Math.Round(baseFare, 2);
        }

        public double discountedFare(double fare, double discountPercentage)
        {
            double discountAmount = fare * (discountPercentage / 100);
            double discountedFare = fare - discountAmount;
            return Math.Round(discountedFare, 2);
        }

    }
}
