using System;
using System.ServiceModel;
using TestApp;

namespace Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Server HOST";


            using (var host = new ServiceHost(typeof(MouseEventService)))
            {
                //ServiceHost serviceHost = new ServiceHost(typeof(Service), new Uri("http://localhost:8301"));
                //serviceHost.AddServiceEndpoint(typeof(IContract), new BasicHttpBinding(), "");

                //serviceHost.Open();

                host.Open();

                
                Console.WriteLine("HOST is Start");
                Console.ReadLine();
                Console.ReadLine();
                Console.ReadLine();
            }
        }
    }
}
