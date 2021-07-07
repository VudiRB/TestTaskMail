using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TestTaskJun
{
    /// <summary>
    /// The base class for initializing the program. Contains the Main method.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The method that initializes the program.
        /// </summary>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}