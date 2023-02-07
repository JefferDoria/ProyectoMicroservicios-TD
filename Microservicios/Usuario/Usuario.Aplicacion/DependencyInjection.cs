using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using Usuario.Aplicacion.Usuario;
using Usuario.Infraestructura;
using dominio = Usuario.Dominio.Entidades;

namespace Usuario.Aplicacion
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
            services.TryAddScoped<ICollectionContext<dominio.Usuario>>(x => new CollectionContext<dominio.Usuario>(x.GetService<IDbContext>()));

            //Como Repo
            services.TryAddScoped<IBaseRepository<dominio.Usuario>>(x => new BaseRepository<dominio.Usuario>(x.GetService<IDbContext>()));

            #endregion

            #region Servicios

            services.AddScoped<IUsuarioService, UsuarioService>();

            #endregion

            return services;
        }

    }
}
