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
                        JsonResponse.RootObject token = JsonConvert.DeserializeObject<JsonResponse.RootObject>(json_data);
                        var temperature = token.current_observation.temperature_string;
                        var wind = token.current_observation.wind_string;
                        var rain = token.current_observation.precip_today_string;
                        var heat_Index = token.current_observation.heat_index_string;
                        var weather = token.current_observation.weather; 
                        Console.WriteLine($"Temperature: {temperature}\nWind: {wind}\nRain: {rain}\nHeat Index: {heat_Index}\nFeels Like: {weather}");
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
