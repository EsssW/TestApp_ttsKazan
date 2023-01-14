using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(TestApp.ServiceChat)))
            {
                host.Open();
                Console.WriteLine("HOST is Start");
                Console.ReadLine();
                Console.ReadLine();
                Console.ReadLine();
            }
        }
    }
}
