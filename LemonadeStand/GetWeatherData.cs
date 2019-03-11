using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LemonadeStand
{
    public class RequestObj
    {
        //attributes associated with product of GET
        public Daily daily { get; set; }
    }
    public class Daily
    {
        public Data[] data { get; set; }
    }
    public class Data
    {
        public decimal precipProbability { get; set; }
        public decimal temperatureHigh { get; set; }
    }
    public class GetWeatherData
    {
        static HttpClient client = new HttpClient();
        static RequestObj weather;

        public static decimal[,] GetForecast()
        {
            decimal[,] forecast = new decimal[7, 2];
            for (int x = 0; x<7; x++)
            {
                forecast[x, 0] = weather.daily.data[x].temperatureHigh;
                forecast[x, 1] = weather.daily.data[x].precipProbability;
            }
            return forecast;
        }
        static async Task<RequestObj> GetRequest(string path)
        {
            RequestObj jsonObj = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)//This is the continue on , game should call this Get request THEN proceed with the rest of the game application
            {
                jsonObj = await response.Content.ReadAsAsync<RequestObj>(); 

            }
            return jsonObj;
        }

        public static void Retrieve()
        {
            RunDataRetrieval().GetAwaiter().GetResult();
        }
        static async Task RunDataRetrieval()
        {
            client.BaseAddress = new Uri("https://api.darksky.net/forecast/f9d2272cf45c9dca60f673c6ce069f62/43.040669,-87.913240?exclude=minutely,hourly,alerts");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                RequestObj jsonObj = await GetRequest(client.BaseAddress.PathAndQuery);
                weather = jsonObj;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
