using AcademiaMktEscolas.Infra.Data.AcademiaMkt.Repositories;
using AgendasTech.Application.AgendaTech.Interfaces;
using AgendasTech.Application.AgendaTech.Services;
using AgendasTech.Application.AutoMapper;
using AgendasTech.Domain.AgendaTech.Interfaces.Repositories;
using AgendasTech.Domain.AgendaTech.Interfaces.Services;
using AgendasTech.Domain.AgendaTech.Services;
using AgendasTech.Domain.Core.Interfaces;
using AgendasTech.Infra.Data;
using AgendasTech.Infra.Data.AgendaTech;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AgendasTech.Infra.IoC;
public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterApplication(services);
        RegisterDomainServices(services);
        RegisterRepositories(services);
        RegisterCoreServices(services);

        services.AddScoped<IUnitOfWork<AgendaTechContext>, UnitOfWork<AgendaTechContext>>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddAutoMapper(typeof(Profiles));

        return services;
    }

    public static IServiceCollection ConfigureDatabases(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionStringMysql = configuration.GetConnectionString("DatabaseAgenda");

        services.AddDbContextPool<AgendaTechContext>(options =>
                        options.UseMySql(connectionStringMysql,
                            ServerVersion.AutoDetect(connectionStringMysql)));
        return services;
    }

    public static IServiceCollection RegisterCoreServices(IServiceCollection services)
    {
        //Caso precise do Core

        return services;
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddTransient<IAgendaRepository, AgendaRepository>();
    }

    private static void RegisterApplication(IServiceCollection services)
    {
        services.AddScoped<IAgendaApplication, AgendaApplication>();
    }
    private static void RegisterDomainServices(IServiceCollection services)
    {
        services.AddScoped<IAgendaService, AgendaService>();
    }
}
