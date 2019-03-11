using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Day
    {
        //Member Variables
        Weather TodaysWeather;
        List<Customer> TodaysCustomers;
        double Sales;
        int NumberOfPotentialCustomers;
        int NumberOfTotalSales;
        //Constructor
        public Day(List<double> MoodGenerator, decimal Temperature, decimal ChanceOfRain)
        {
            NumberOfPotentialCustomers = MoodGenerator.Count - 2;
            TodaysWeather = new Weather(Temperature, ChanceOfRain);
            TodaysCustomers = GenerateCustomers(MoodGenerator);
        }
        //Member Variables
        public List<Customer> GenerateCustomers(List<double> Moods)
        {

            List<Customer> Consumers = new List<Customer>();
            for (int x = 2; x < Moods.Count; x++)
            {
                Consumers.Add(new Customer(Moods[x]));
            }
            return Consumers;
        }
        public Player RunDay(Player Seller)
        {
            int Count = 0;
            double Price = Seller.GetCost();
            foreach (Customer x in TodaysCustomers)
            {
                x.GenerateTolerances(TodaysWeather.getTemperature(), TodaysWeather.getPrecipitation());
                if (x.WillBuy(Price))
                {
                    if (Seller.GetCup())
                    {
                        Count++;
                    }
                }
            }
            NumberOfTotalSales = Count;
            Sales = Price * Count;

            return Seller;
        }
        public double GetSales()
        {
            return Sales;
        }
        public int GetSalesCount()
        {
            return NumberOfTotalSales;
        }
        public int GetTemperature()
        {
            return TodaysWeather.getTemperature();
        }
        public bool GetPrecipitation()
        {
            return TodaysWeather.getPrecipitation();
        }

    }
}
