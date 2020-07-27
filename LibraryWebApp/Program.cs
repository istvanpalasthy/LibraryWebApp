using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LibraryWebApp
{
    public class Program
    {

        private static readonly string dbHost = ("localhost");
        private static readonly string dbUser = ("postgres");
        private static readonly string dbPass = ("pista333");
        private static readonly string dbName = ("LibraryMSystem");

        public static readonly string ConnectionString = $"Host={dbHost};Username={dbUser};Password={dbPass};Database={dbName}";
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
