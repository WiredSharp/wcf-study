using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticatedServiceHost
{
    class Program
    {
        internal static Uri BaseAddress => new Uri("http://localhost:9000");

        private static ILogger Logger;

        static void Main(string[] args)
        {
            SetupLogs();
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex, "program terminated");
            }
            WaitKey();
        }

        private static void Run()
        {
            // acl must be set for listening url with netsh
            // Ex: netsh http add urlacl url=http://+:9000/ user=zeric
            using (var host = new ServiceHost(typeof(AuthenticatedService)/*, BaseAddress*/))
            {
                host.Open();
                Logger.Information("service started...");
                WaitKey();
            }
            Logger.Information("...service stopped");
        }

        private static void WaitKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void SetupLogs()
        {
            Serilog.Debugging.SelfLog.Enable(Console.Error);
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.ColoredConsole()
                .CreateLogger();
            Logger = Log.ForContext<Program>();
        }
    }
}
