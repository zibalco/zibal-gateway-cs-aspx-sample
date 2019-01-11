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
    class Verify
    {
   
        static void Main(string[] args)
        {
            try
            {
                string url = "https://gateway.zibal.ir/verify"; // url
                Zibal.verifyRequest Request = new Zibal.verifyRequest(); // define Request
                Request.merchant = "zibal"; // String
                Request.trackId = "TRACK ID IN MAKEREQUEST() RESPONSE PARAMETERS"; // String 
                var httpResponse = Zibal.HttpRequestToZibal(url, JsonConvert.SerializeObject(Request));  // get Response
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) // make stream reader
                {
                    var responseText = streamReader.ReadToEnd(); // read Response
                    Zibal.verifyResponse item = JsonConvert.DeserializeObject<Zibal.verifyResponse>(responseText); // Deserilize as response class object
                    // you can access paidAt time with item.paidAt , result with item.result , message with item.message , status with item.status and amount with item.amount
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message); // print exception error
            }
        } 
    }
}
