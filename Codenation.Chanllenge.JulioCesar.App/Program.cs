using Codenation.Chanllenge.JulioCesar.Interfaces;
using Codenation.Chanllenge.JulioCesar.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Codenation.Chanllenge.JulioCesar.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();

            var result = serviceProvider.GetService<ICriptService>().DecriptJulioCesar("abc",-1);
            Console.WriteLine("Hello World!");
        }
        private static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
            .AddScoped<ICodenationService, CodenationService>()
            .AddScoped<ICriptService,CriptService>()
            .BuildServiceProvider();
        }
    }
}
