using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Weather
    {
        //Member Variables
        bool Precipitation;
        int Temperature;
        //Constructor
        public Weather(decimal Temp, decimal PrecipitationFactor)
        {
            Temperature = (int)(Temp);
            if (PrecipitationFactor > (decimal).5)
            {
                Precipitation = true;
            }
        }
        //Member Methods
        public bool getPrecipitation()
        {
            return Precipitation;
        }
        public int getTemperature()
        {
            return Temperature;
        }
    }
}