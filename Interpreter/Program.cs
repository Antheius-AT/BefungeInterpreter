using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1 && args[0].ToLower() == "--interactive")
                throw new NotImplementedException("Arguments were valid, however interactive mode is not implemented in this version, and is yet to come.");
            else if (args.Length == 2 && args[0].ToLower() == "--noninteractive")
            {
                var host = CreateHostBuilder(args).Build();
                host.Run();
            }
            else
                throw new ArgumentException(nameof(args), "Invalid argument specified");
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<Stack<long>>();
                    services.AddHostedService<Interpreter>(service =>
                    {
                        return new Interpreter(args[1]);
                    });
                })
                .ConfigureLogging(options =>
                {
                    options.AddConsole();
                });
        }
    }
}
