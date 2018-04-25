using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Net.Core.LoginSolucion.Api.ModeloDeDatos;
using Net.Core.LoginSolucion.Web.Models;
using Net.Core.LoginSolucion.Web.Servicio;
using System.Collections.Generic;

namespace Net.Core.LoginSolucion.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private IMapper mapper;

        public UsuarioController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            Client service = new Client();
            var listado = service.GetUsuarios();
            var model = mapper.Map<List<UsuarioViewModel>>(listado);
            return View(model);
        }

        public IActionResult Create()
        {
            return View(new UsuarioViewModel());
        }

        [HttpPost]
        public IActionResult Create(UsuarioViewModel model)
        {
            Client service = new Client();
            if (model!=null)
            {
                var usuarioModel = mapper.Map<Usuario>(model);
                var result = service.CreateUsuario(usuarioModel);                
            }
            return View("Index");
        }

    }
}