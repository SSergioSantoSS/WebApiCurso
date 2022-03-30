using WebCursos.Application.Interfaces.Mappers;
using WebCursos.Domain.Core.Interfaces.Repositories;
using WebCursos.Domain.Core.Interfaces.Services;
using WebCursos.Domain.Services;
using WebCursos.Infrastructure.Data;
using WebCursos.Infrastructure.Data.Repositories;

namespace ApiCurso.Configuration
{
    public static class DependencyInectionConfig
    {
        public static IServiceCollection ResolveDependecies(this IServiceCollection services) 
        {
            //services.AddScoped<SqlContext>();
            services.AddScoped<IMapperAluno, MapperAluno>();
            services.AddScoped<IMapperTurma, MapperTurma>();
            services.AddScoped<IMapperUsuario, MapperUsuario>();
            services.AddScoped<IMapperMatricula, MapperMatricula>();
            services.AddScoped<IMapperAlunoTurma, MapperAlunoTurma>();

            services.AddScoped<IRepositoryAluno, RepositoryAluno>();
            services.AddScoped<IRepositoryTurma, RepositoryTurma>();
            services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();
            services.AddScoped<IRepositoryMatricula, RepositoryMatricula>();
            services.AddScoped<IRepositoryAlunoTurma, RepositoryAlunoTurma>();

            services.AddScoped<IServiceAluno, ServiceAluno>();
            services.AddScoped<IServiceTurma, ServiceTurma>();
            services.AddScoped<IServiceMatricula, ServiceMatricula>();
            services.AddScoped<IServiceUsuario, ServiceUsuario>();
            services.AddScoped<IServiceAlunoTurma, ServiceAlunoTurma>();


            return services;
        }
    }
}
