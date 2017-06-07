using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Web.Script.Serialization; 





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
                    if(json_data != null)
                    {
                        Console.WriteLine(json_data);
                    }
                    
                    var response = JsonConvert.DeserializeObject<CurrentObservation>(json_data);

                    
                        var my_weather = response.weather;
                        var temperature = response.temperature_string;
                        Console.WriteLine("Current Weather: {0}", my_weather);
                        Console.WriteLine("Current Temp: {0}", temperature);
                    
                    
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            
           
            
        }
    }
}
