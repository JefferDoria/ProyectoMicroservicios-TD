using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Gateway.Api.Routes.ApiRoutes;
using System.Collections.Generic;
using Alquiler = Gateway.Aplicacion.AlquileresClient;
using Usuario = Gateway.Aplicacion.UsuariosClient;
using Pelicula = Gateway.Aplicacion.PeliculasClient;
using System.Threading.Tasks;
using Gateway.Aplicacion.AlquileresClient;
using Microsoft.Extensions.Logging;
using System;
using Serilog;
using Gateway.Aplicacion.Alquileres.Request;

namespace Gateway.Api.Controllers
{

    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private readonly Alquiler.IClient _alquilerClient;
        private readonly Usuario.IClient _usuarioClient;
        private readonly Pelicula.IClient _peliculaClient;

        public AlquilerController(Alquiler.IClient alquilerClient,Usuario.IClient usuarioClient, Pelicula.IClient peliculaClient)
        {
            _alquilerClient = alquilerClient;
            _usuarioClient = usuarioClient;
            _peliculaClient = peliculaClient;
        }

        [HttpGet(RouteAlquiler.GetAll)]
        public Task<ICollection<Alquiler.Alquiler>> ListarAlquiler()
        {
            try
            {
                var listaAlquiler = _alquilerClient.ApiV1AlquilerAllAsync();
                return listaAlquiler;
            }
            catch(Exception ex)
            {
                Log.Error("ApiException: "+ex);
                
            }
            return null;
        }

        [HttpGet(RouteAlquiler.GetById)]
        public Task<Alquiler.Alquiler> BuscarAlquiler(double id)
        {
            try
            {
                var objAlquiler = _alquilerClient.ApiV1AlquilerAsync(id);
                return objAlquiler;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
            
        }

        [HttpPost(RouteAlquiler.Create)]
        public void CrearAlquiler(Alquiler.Alquiler alquiler)
        {
            try
            {
                _alquilerClient.ApiV1AlquilerCreateAsync(alquiler);
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " +ex);
                Log.Logger.Error("Exception: " + ex);

            }
        }

        [HttpPost(RouteAlquiler.Alquilar)]
        public async void Alquilar(RegistrarAlquilerRequest request)
        {
            try
            {
                var cliente = await _usuarioClient.ApiV1UsuarioAsync(request.IdUsuario);
                var pelicula = await _peliculaClient.ApiV1PeliculaAsync(request.IdPelicula);
                if (cliente!=null && pelicula!=null)
                {
                    Alquiler.Alquiler alquiler = new Alquiler.Alquiler();
                    alquiler.IdAlquiler = request.IdAlquiler;
                    alquiler.IdPelicula = request.IdPelicula;
                    alquiler.IdUsuario = request.IdUsuario;
                    alquiler.FechaInicio = request.FecInicio;
                    alquiler.FechaFin = request.FecFin;
                    await _alquilerClient.ApiV1AlquilerCreateAsync(alquiler);
                }
            }catch(Exception ex)
            {
                Log.Error("Error: " + ex);
            }            

        }

        [HttpDelete(RouteAlquiler.Delete)]
        public void EliminarAlquiler(double id)
        {
            try
            {
                _alquilerClient.ApiV1AlquilerDeleteAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
        }
    }
}
