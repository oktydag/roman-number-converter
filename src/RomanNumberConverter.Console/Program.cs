using System;
using System.Net.Mime;
using Autofac;
using RomanNumberConverter.Console.ApplicationServices;
using RomanNumberConverter.Console.Domain;

namespace RomanConsoleApp
{
    public class RomanNumberConverter
    {
        public static void Main(string[] args)
        {
            // Dependency Injection
            IContainer serviceProvider = BuildServiceProvider();

            while (true)
            {
                try
                {
                    Console.WriteLine("\n Enter a number");
                    string input = Console.ReadLine();

                    //Domain
                    Numeric numeric = new Numeric(input);

                    //ApplicationService
                    var romanConverterService = serviceProvider.Resolve<IRomanConverter>();

                    // UserInterface
                    Console.WriteLine(input.ToString() + " --> " + romanConverterService.ToRoman(numeric.Number) + "\n");

                    SeperateEachResult();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message} ");
                }
            }
        }

        private static IContainer BuildServiceProvider()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RomanConverter>().As<IRomanConverter>();
            return builder.Build();
        }

        private static void SeperateEachResult()
        {
            Console.WriteLine("\n **************************************");
        }
    }
}