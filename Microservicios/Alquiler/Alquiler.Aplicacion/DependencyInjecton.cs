using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using Alquiler.Aplicacion.Alquiler;
using Alquiler.Infraestructura;
using dominio = Alquiler.Dominio.Entidades;
using Alquiler.Aplicacion.Usuario;

namespace Alquiler.Aplicacion
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
            services.TryAddScoped<ICollectionContext<dominio.Alquiler>>(x => new CollectionContext<dominio.Alquiler>(x.GetService<IDbContext>()));

            //Como Repo
            services.TryAddScoped<IBaseRepository<dominio.Alquiler>>(x => new BaseRepository<dominio.Alquiler>(x.GetService<IDbContext>()));

            #endregion

            #region Servicios

            services.AddScoped<IAlquilerService, AlquilerService>();

            #endregion

            return services;
        }

    }
}
