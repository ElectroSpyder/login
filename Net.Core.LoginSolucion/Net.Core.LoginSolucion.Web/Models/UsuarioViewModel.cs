using System;

namespace Net.Core.LoginSolucion.Web.Models
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto {
            get{ return Nombre + " " + Apellido; }
            
        }
        public string Direccion { get; set; }

        // Credenciales

        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }
    }
}
