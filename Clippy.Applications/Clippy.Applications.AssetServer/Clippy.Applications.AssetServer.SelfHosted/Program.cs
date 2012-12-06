using Clippy.Applications.AssetServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clippy.Applications.AssetServer.SelfHosted
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new Nancy.Hosting.Self.NancyHost(new Bootstrapper(), new Uri("http://localhost:3000"));
            host.Start();

            Console.ReadLine();
        }
    }
}
