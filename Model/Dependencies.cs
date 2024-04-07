using Microsoft.Extensions.DependencyInjection;
using Model.DB;
using Model.Models;

namespace Model;

public static class Dependencies
{
    public static IServiceCollection SetDataDependencies(this IServiceCollection services)
    {
        services.AddDbContext<ChinookContext>();

        services.AddScoped<IBaseService<Album>, BaseService<Album>>();
        services.AddScoped<IBaseService<Artist>, BaseService<Artist>>();
        services.AddScoped<IBaseService<Customer>, BaseService<Customer>>();
        services.AddScoped<IBaseService<Employee>, BaseService<Employee>>();
        services.AddScoped<IBaseService<Genre>, BaseService<Genre>>();
        services.AddScoped<IBaseService<Invoice>, BaseService<Invoice>>();
        services.AddScoped<IBaseService<InvoiceLine>, BaseService<InvoiceLine>>();
        services.AddScoped<IBaseService<MediaType>, BaseService<MediaType>>();
        services.AddScoped<IBaseService<Playlist>, BaseService<Playlist>>();
        services.AddScoped<IBaseService<Track>, BaseService<Track>>();

        return services;
    }
}