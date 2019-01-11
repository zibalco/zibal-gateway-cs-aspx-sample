using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json; // Solution Explorer->Right Click on Project Name -> Click on Manage Nuget Packages -> Search for newtonsoft -> Click on install button 
using System.Net;

namespace ZibalIPGRequests
{
    class Request
    {
        static void Main(string[] args)
        {
            try
            {
                string url = "https://gateway.zibal.ir/request"; // url
                Zibal.makeRequest Request = new Zibal.makeRequest(); // define Request
                Request.merchant = "zibal"; // String
                Request.orderId = "1000"; // String
                Request.amount = 1000; //Integer
                Request.callbackUrl = "http://callback.com/api"; //String
                Request.description = "Hello Zibal !"; // String
                var httpResponse = Zibal.HttpRequestToZibal(url, JsonConvert.SerializeObject(Request));  // get Response
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) // make stream reader
                {
                    var responseText = streamReader.ReadToEnd(); // read Response
                    Zibal.makeRequest_response item = JsonConvert.DeserializeObject<Zibal.makeRequest_response>(responseText); // Deserilize as response class object
                    // you can access track id with item.trackId , result with item.result and message with item.message
                    // in asp.net you can use Response.Redirect("https://gateway.zibal.ir/start/item.trackId"); for start gateway and redirect to third-party gateway page
                    // also you can use Response.Redirect("https://gateway.zibal.ir/start/item.trackId/direct"); for start gateway page directly
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message); // print exception error
            }
        }
    }
}
