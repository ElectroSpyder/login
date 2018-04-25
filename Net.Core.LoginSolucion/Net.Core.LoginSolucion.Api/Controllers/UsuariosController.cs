using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Net.Core.LoginSolucion.Api.Infraestructura.Interfaces;
using Net.Core.LoginSolucion.Api.ModeloDeDatos;
using Net.Core.LoginSolucion.Api.Servicio.Repositorio;
using Net.Core.LoginSolucion.Web.Models;

namespace Net.Core.LoginSolucion.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuarios")]
    public class UsuariosController : Controller
    {
        private IRepository<Usuario> Repository;
        private readonly IMapper mapper;
        public UsuariosController(UsuarioRepository usuarioRepository, IMapper mapper)
        {
            Repository = usuarioRepository;
            this.mapper = mapper;
        }

        // GET: api/Usuarios

        public IActionResult GetAll()
        {
            var result = Repository.GetAll().AsEnumerable();
            if (result != null) return new JsonResult(result);
            return new NoContentResult();
        }

        //// GET: api/Usuarios/5

        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Usuarios

        public void Post(Usuario usuario)
        {
            if (usuario != null)
            {                
                var result = Repository.Get(x => x.Nombre == usuario.Nombre && x.Apellido == usuario.Apellido).FirstOrDefault();
                if (usuario == null)
                {
                    Repository.AddEntity(usuario);
                }
            }
        }

        //// PUT: api/Usuarios/5

        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5

        //public void Delete(int id)
        //{
        //}
    }
}
