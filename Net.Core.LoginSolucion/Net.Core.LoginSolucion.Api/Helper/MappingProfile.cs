using AutoMapper;
using Net.Core.LoginSolucion.Api.ModeloDeDatos;
using Net.Core.LoginSolucion.Web.Models;

namespace Net.Core.LoginSolucion.Api.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}
