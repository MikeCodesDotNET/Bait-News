using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace BaitNews
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var host = new WebHostBuilder()
				.UseKestrel()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseSetting("detailedErrors", "true")
				.UseIISIntegration()
				.UseStartup<Startup>()
                .UseApplicationInsights()
                .CaptureStartupErrors(true)
				.Build();

			host.Run();
        }
    }
}
