using Fly.Data;
using Fly;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly.Data
{
    public static class ServiceCollectionExtensions 
    {
        public static IServiceCollection AddEfRepositories(this IServiceCollection services, string connectionString)
        {
            
            



            return services;
        }
    }
}
