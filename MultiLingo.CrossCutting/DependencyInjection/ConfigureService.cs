using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiLingo.Domain.Interfaces.Services;
using MultiLingo.Domain.Services;
using MultiLingo.Infra.Persistence;
using MultiLingo.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLingo.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {


        
        public static void ConfigureDependeciesService(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IServiceAluno, ServiceAluno>();
            services.AddScoped<IServiceTurma, ServiceTurma>();
            services.AddScoped<IServiceUsuario, ServiceUsuario>();

        }
    }
}
