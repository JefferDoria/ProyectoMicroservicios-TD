using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using Pelicula.Aplicacion.Pelicula;
using Pelicula.Infraestructura;
using dominio = Pelicula.Dominio.Entidades;

namespace Pelicula.Aplicacion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration) 
        {
            #region Mongo

            string cs = configuration.GetSection("DBSettings:ConnectionString").Value;
            var dbUrl = new MongoUrl(cs);

            services.AddScoped<IDbContext>(x => new DbContext(dbUrl));

            //Entidades            
            services.TryAddScoped<ICollectionContext<dominio.Pelicula>>(x => new CollectionContext<dominio.Pelicula>(x.GetService<IDbContext>()));

            //Como Repo
            services.TryAddScoped<IBaseRepository<dominio.Pelicula>>(x => new BaseRepository<dominio.Pelicula>(x.GetService<IDbContext>()));

            #endregion

            #region Servicios

            services.AddScoped<IPeliculaService, PeliculaService>();

            #endregion

            return services;
        }

    }
}
