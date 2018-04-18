using System;

namespace Net.Core.LoginSolucion.Api.ModeloDeDatos
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }

        // Credenciales

        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }
    }
}