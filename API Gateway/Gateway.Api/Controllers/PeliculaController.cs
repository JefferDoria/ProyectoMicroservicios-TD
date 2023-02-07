using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Gateway.Api.Routes.ApiRoutes;
using System.Collections.Generic;
using Peliculas = Gateway.Aplicacion.PeliculasClient;
using System.Threading.Tasks;
using Gateway.Aplicacion.PeliculasClient;
using Serilog;
using System;

namespace Gateway.Api.Controllers
{
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly Peliculas.IClient _peliculasClient;

        public PeliculaController(Peliculas.IClient peliculasClient)
        {
            _peliculasClient = peliculasClient;
        }

        [HttpGet(RoutePelicula.GetAll)]
        public Task<ICollection<Peliculas.Pelicula>> ListarPeliculas()
        {
            try
            {
                var listaPelicula = _peliculasClient.ApiV1PeliculaAllAsync();
                return listaPelicula;
            }
            catch (Exception ex)
            {
                Log.Error("ApiException: " + ex);
            }
            return null;
        }

        [HttpGet(RoutePelicula.GetById)]
        public Task<Peliculas.Pelicula> BuscarPelicula(int id)
        {
            try
            {
                var objPelicula = _peliculasClient.ApiV1PeliculaAsync(id);
                return objPelicula;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " +ex);
            }
            return null;
        }

        [HttpPost(RoutePelicula.Create)]
        public ActionResult<Task<Peliculas.Pelicula>> CrearPelicula(Peliculas.Pelicula pelicula)
        {
            try
            {
                _peliculasClient.ApiV1PeliculaCreateAsync(pelicula);

                return Ok();
            } catch (Exception ex)
            {
                Log.Error("Exception: " +ex);
            }
            return null;
        }

        [HttpDelete(RoutePelicula.Delete)]
        public ActionResult<Task<Peliculas.Pelicula>> EliminarPelicula(int id)
        {
            try
            {
                _peliculasClient.ApiV1PeliculaDeleteAsync(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }
    }
}
