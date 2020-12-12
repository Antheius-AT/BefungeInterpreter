using System;

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
                var interpreter = new Interpreter();
                Console.ReadLine();
                interpreter.RunCode(args[1]);
            }
            else
                throw new ArgumentException(nameof(args), "Invalid argument specified");
        }
    }
}
