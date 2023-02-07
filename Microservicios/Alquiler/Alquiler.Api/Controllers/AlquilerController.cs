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
using Serilog;

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
            try
            {
                var listaAlquiler = _service.ListarAlquiler();
                return listaAlquiler;
            }
            catch (Exception ex)
            {
                Log.Information("Exception: " + ex);
            }
            return null;
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
                Log.Information("Information: " + ex);
                Console.WriteLine("El error es: " + ex);
                Console.ReadKey();
            }
            return null;
        }

        [HttpPost(RouteAlquiler.Create)]
        public void CrearAlquiler(dominio.Alquiler alquiler)
        {
            try
            {
                _service.RegistrarAlquiler(alquiler);
            }
            catch (Exception ex)
            {
                Log.Information("Exception: " + ex);
            }
            
        }

        [HttpPut(RouteAlquiler.Update)]
        public ActionResult<dominio.Alquiler> ModificarAlquiler(dominio.Alquiler alquiler)
        {
            try
            {
                _service.ModificarAlquiler(alquiler);
                return Ok();
            } catch(Exception ex)
            {
                Log.Information("Information: " + ex);
            }
            return null;
        }

        [HttpDelete(RouteAlquiler.Delete)]
        public ActionResult<dominio.Alquiler> EliminarAlquiler(double id)
        {
            try
            {
                _service.EliminarAlquiler(id);
                return Ok(id);
            } catch (Exception ex)
            {
                Log.Warning("Warning: " + ex);
            }
            return null;
        }
    }
}
