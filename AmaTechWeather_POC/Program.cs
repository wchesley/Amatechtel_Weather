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


// Written By: Walker Chesley
// Date: 06/10/2017


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
                    var myObject = new RootObject();
                    JsonConvert.PopulateObject(json_data, myObject);
                    string weather = myObject.current_observation.temp_f.ToString();
                    Console.WriteLine("Temp: {0}", weather);
   
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            
           
            
        }
    }
}
