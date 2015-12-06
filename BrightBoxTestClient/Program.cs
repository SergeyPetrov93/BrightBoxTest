using System;
using System.IO;
using System.Net;

namespace BrightBoxTestClient
{
    class Program
    {
        static string Link = "http://localhost:57996/api/Status";

        static void Main(string[] args)
        {
            while (true)
            {
                var request = (HttpWebRequest)WebRequest.Create(Link);

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                Console.WriteLine(responseString);
                Console.ReadKey();
            }
        }
    }
}
