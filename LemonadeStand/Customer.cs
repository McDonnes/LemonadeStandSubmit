using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Customer
    {
        //Member Variables
        public double Tolerance;
        double CustomerMood;
        //Constructor
        public Customer(double Mood)
        {
            CustomerMood = Mood;
        }
        //Member Methods
        public void GenerateTolerances(int Temperature, bool Precipitation)
        {
            if (Precipitation)
            {
                if (Temperature > 90)
                {
                    Tolerance = .23;
                }
                else if (Temperature > 65)
                {
                    Tolerance = .18;
                }
                else if (Temperature > 40)
                {
                    Tolerance = .06;
                }
                else
                {
                    Tolerance = .01;
                }
            }
            else
            {
                if (Temperature > 80)
                {
                    Tolerance = .35;
                }
                else if (Temperature > 55)
                {
                    Tolerance = .20;
                }
                else if (Temperature > 10)
                {
                    Tolerance = .10;
                }
                else
                {
                    Tolerance = .05;
                }
            }
        }
        public bool WillBuy(double PriceOfALemonade)
        {
            if (Tolerance > PriceOfALemonade & CustomerMood > .30)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}