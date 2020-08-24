using Microsoft.Extensions.DependencyInjection;
using MultiLingo.Domain.Interfaces.Repositories;

using MultiLingo.Infra.Persistence;

namespace MultiLingo.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {

        public static void ConfigureDependeciesRepository(IServiceCollection services)
        {
            services.AddScoped<IRepositoryAluno,RepositoryAluno>();
            services.AddScoped<IRepositoryTurma, RepositoryTurma>();

        }
    }
}
