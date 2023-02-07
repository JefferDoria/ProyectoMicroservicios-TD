using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Gateway.Aplicacion.Common;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;

namespace Gateway.Aplicacion
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicacion(this IServiceCollection services, IConfiguration configuration)
        {            
            // Clientes
            services.AddClientes(configuration);

            return services;
        }

        public static IServiceCollection AddClientes(this IServiceCollection services, IConfiguration configuration)
        {
            //CLIENT_SETTINGS
            var msSettings = new ClientSettings();
            configuration.Bind(nameof(ClientSettings), msSettings);

            #region Cliente Ms Peliculas

            services.AddHttpClient("Pelicula", client =>
            {
                client.BaseAddress = new Uri(msSettings.PeliculasUrl);
            });
            services.AddHttpClient("Alquiler", client =>
            {
                client.BaseAddress = new Uri(msSettings.AlquileresUrl);
            });
            services.AddHttpClient("Usuario", client =>
            {
                client.BaseAddress = new Uri(msSettings.UsuariosUrl);
            });

            #endregion

            services.AddTransient<PeliculasClient.IClient, PeliculasClient.Client>();
            services.AddTransient<AlquileresClient.IClient, AlquileresClient.Client>();
            services.AddTransient<UsuariosClient.IClient, UsuariosClient.Client>();

            return services;
        }
    }
}
