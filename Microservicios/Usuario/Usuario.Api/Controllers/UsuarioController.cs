using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Usuario.Api.Routes;
using Usuario.Aplicacion.Usuario;
using System;
using System.Collections.Generic;
using static Usuario.Api.Routes.ApiRoutes;
using dominio = Usuario.Dominio.Entidades;

namespace Usuario.Api.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet(RouteUsuario.GetAll)]
        public IEnumerable<dominio.Usuario> ListarUsuarios()
        {
            var listaUsuario = _service.ListarUsuarios();
            return listaUsuario;
        }

        [HttpGet(RouteUsuario.GetById)]
        public dominio.Usuario BuscarUsuario(double id)
        {
            try
            {
                var objUsuario = _service.BuscarUsuario(id);
                return objUsuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine("El error es: " + ex);
                Console.ReadKey();
            }
            return null;
        }

        [HttpPost(RouteUsuario.Create)]
        public ActionResult<dominio.Usuario> CrearUsuario(dominio.Usuario usuario)
        {
            _service.RegistrarUsuario(usuario);

            return Ok();
        }

        [HttpPut(RouteUsuario.Update)]
        public ActionResult<dominio.Usuario> ModificarUsuario(dominio.Usuario usuario)
        {
            _service.ModificarUsuario(usuario);
            return Ok();
        }

        [HttpDelete(RouteUsuario.Delete)]
        public ActionResult<dominio.Usuario> EliminarUsuario(double id)
        {
            _service.EliminarUsuario(id);
            return Ok(id);
        }
    }
}
