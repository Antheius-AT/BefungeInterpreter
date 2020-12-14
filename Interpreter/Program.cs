using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Interpreter.AdditionalComponents;
using Interpreter.Interfaces;
using Interpreter.InterpreterComponents;
using Interpreter.LanguageCommands.BasicCommands;
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
                var interpreter = host.Services.GetRequiredService<BefungeInterpreter>();

                interpreter.Start();
            }
            else
                throw new ArgumentException(nameof(args), "Invalid argument specified");
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    // Could think about injecting these as abstract interfaces to increase modularity.
                    // However Im keeping this as something to think about at a later stage.
                    services.AddSingleton<Torus>();
                    services.AddSingleton<Stack<long>>();
                    services.AddSingleton<Random>();
                    services.AddSingleton<ProgramCounter>();
                    services.AddSingleton<IInputHandler, ConsoleInputHandler>();
                    services.AddSingleton<IOutputHandler, ConsoleOutputHandler>();
                    services.AddTransient<ExecutableCodeContainer>(factory =>
                    {
                        return new ExecutableCodeContainer(File.ReadAllText("input.txt"));
                    });
                    services.AddSingleton<ICommandParser, DefaultCommandParser>();
                    services.AddTransient<BefungeInterpreter>();
                })
                .ConfigureLogging(options =>
                {
                    options.AddConsole();
                });
        }
    }
}
