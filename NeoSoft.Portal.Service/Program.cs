using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace NeoSoft.Portal.Service
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Build().Run();
        }

        public static IWebHostBuilder BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseIIS()
                .UseIISIntegration();
    }
}

