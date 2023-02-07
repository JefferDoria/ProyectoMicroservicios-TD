using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Gateway.Api.Routes.ApiRoutes;
using System.Collections.Generic;
using Alquiler = Gateway.Aplicacion.AlquileresClient;
using System.Threading.Tasks;
using Gateway.Aplicacion.AlquileresClient;

namespace Gateway.Api.Controllers
{
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private readonly Alquiler.IClient _alquilerClient;

        public AlquilerController(Alquiler.IClient alquilerClient)
        {
            _alquilerClient = alquilerClient;
        }

        [HttpGet(RouteAlquiler.GetAll)]
        public Task<ICollection<Alquiler.Alquiler>> ListarAlquiler()
        {
            var listaAlquiler = _alquilerClient.ApiV1AlquilerAllAsync();
            return listaAlquiler;
        }

        [HttpGet(RoutePelicula.GetById)]
        public Task<Alquiler.Alquiler> BuscarAlquiler(double id)
        {
            var objAlquiler = _alquilerClient.ApiV1AlquilerAsync(id);
            return objAlquiler;
        }

        [HttpPost(RouteAlquiler.Create)]
        public ActionResult<Task<Alquiler.Alquiler>> CrearAlquiler(Alquiler.Alquiler alquiler)
        {
            _alquilerClient.ApiV1AlquilerCreateAsync(alquiler);

            return Ok();
        }

        [HttpDelete(RouteAlquiler.Delete)]
        public ActionResult<Task<Alquiler.Alquiler>> EliminarAlquiler(double id)
        {
            _alquilerClient.ApiV1AlquilerDeleteAsync(id);
            return Ok(id);
        }
    }
}
