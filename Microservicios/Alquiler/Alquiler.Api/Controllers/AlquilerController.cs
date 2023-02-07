using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Alquiler.Api.Routes;
using Alquiler.Aplicacion.Alquiler;
using System;
using System.Collections.Generic;
using static Alquiler.Api.Routes.ApiRoutes;
using dominio = Alquiler.Dominio.Entidades;
using Alquiler.Aplicacion.Usuario;

namespace Alquiler.Api.Controllers
{
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private readonly IAlquilerService _service;

        public AlquilerController(IAlquilerService service)
        {
            _service = service;
        }

        [HttpGet(RouteAlquiler.GetAll)]
        public IEnumerable<dominio.Alquiler> ListarAlquiler()
        {
            var listaAlquiler = _service.ListarAlquiler();
            return listaAlquiler;
        }

        [HttpGet(RouteAlquiler.GetById)]
        public dominio.Alquiler BuscarAlquiler(double id)
        {
            try
            {
                var objAlquiler = _service.BuscarAlquiler(id);
                return objAlquiler;
            }
            catch (Exception ex)
            {
                Console.WriteLine("El error es: " + ex);
                Console.ReadKey();
            }
            return null;
        }

        [HttpPost(RouteAlquiler.Create)]
        public ActionResult<dominio.Alquiler> CrearUsuario(dominio.Alquiler alquiler)
        {
            _service.RegistrarAlquiler(alquiler);

            return Ok();
        }

        [HttpPut(RouteAlquiler.Update)]
        public ActionResult<dominio.Alquiler> ModificarUsuario(dominio.Alquiler alquiler)
        {
            _service.ModificarAlquiler(alquiler);
            return Ok();
        }

        [HttpDelete(RouteAlquiler.Delete)]
        public ActionResult<dominio.Alquiler> EliminarAlquiler(double id)
        {
            _service.EliminarAlquiler(id);
            return Ok(id);
        }
    }
}
