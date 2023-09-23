using System;
namespace Dominio
{
	public class Administrador
    {
        #region Atributos

        private static int s_ultimoId = 0;
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }

        #endregion

        #region Constructor
        public Administrador(string email, string contrasena)
        {
            this.Id = s_ultimoId++;
            this.Email = email;
            this.Contrasena = contrasena;
        }

        #endregion

        #region Metodos

        #endregion

    }
}


