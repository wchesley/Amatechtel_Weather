using System;
using System.Net;
using Newtonsoft.Json;
 


// Written By: Walker Chesley
// Date: 06/07/2017
// Depentants: Json.net


namespace AmaTechWeather_POC
{
    
    class Program
    {
        static void Main(string[] args)
        {
            string ApiAddr = "http://api.wunderground.com/api/047d1a51849f71a0/conditions/q/TX/Amarillo.json";

            using (var client = new WebClient())
            {
                try
                {
                    var json_data = client.DownloadString(ApiAddr);
                    if (json_data != null)
                    {
                        RootObject response = JsonConvert.DeserializeObject<RootObject>(json_data);
                        var temperature = response.current_observation.temperature_string;
                        var wind = response.current_observation.wind_string;
                        var rain = response.current_observation.precip_today_string;
                        var heat_Index = response.current_observation.heat_index_string;
                        var weather = response.current_observation.weather; 
                        Console.WriteLine($"Temperature: {temperature}\nWind: {wind}\nRain: {rain}\nLooks Like: {weather}");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Error occured, no response given");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
