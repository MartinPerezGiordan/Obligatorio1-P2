using System;
namespace Dominio
{
	public class Administrador
    {
        #region Atributos

        private static int _ultimoId = 1;
        private int _id;
        private string _email;
        private string _contrasena;

        #endregion

        #region Constructor
        public Administrador(string email, string contrasena)
        {
            this._id = _ultimoId++;
            this._email = email;
            this._contrasena = contrasena;
        }

        #endregion

        #region Get Y Set

        public int GetId()
        {
            return this._id;
        }

        public string GetEmail()
        {
            return this._email;
        }

        public string GetContrasena()
        {
            return this._contrasena;
        }

        #endregion
    }
}


