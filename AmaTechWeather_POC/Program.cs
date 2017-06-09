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
                        var weather = token.current_observation.temperature_string;
                        Console.WriteLine($"Temperature: {weather}");
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
