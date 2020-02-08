using Codenation.Chanllenge.JulioCesar.Interfaces;
using Codenation.Chanllenge.JulioCesar.Models;
using Codenation.Chanllenge.JulioCesar.Repositories;
using Codenation.Chanllenge.JulioCesar.Services;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using System;

namespace Codenation.Chanllenge.JulioCesar.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();


            serviceProvider.GetService<Application>().Exec() ;

        }
        private static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
            .AddScoped<ICodenationService, CodenationService>()
            .AddScoped(typeof(IFileRepository<>),typeof(FileRepository<>))
            .AddScoped<ICriptService,CriptService>()
            .AddScoped<IRestClient,RestClient>()
            .AddScoped<Application>()
            .BuildServiceProvider();
        }
    }
}
