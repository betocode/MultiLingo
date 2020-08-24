using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiLingo.Domain.Interfaces.Services;
using MultiLingo.Domain.Services;
using MultiLingo.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLingo.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {


        
        public static void ConfigureDependeciesService(IServiceCollection services)
        {
            services.AddScoped<IServiceAluno, ServiceAluno>();
            services.AddScoped<IServiceTurma, ServiceTurma>();
            
        }
    }
}
