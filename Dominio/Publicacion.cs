using System;
namespace Dominio
{
	public class Publicacion
	{
        #region Atributos

        private static int s_ultimoId = 1;
        private int _id;
        private Miembro _autor;
        private string _texto;
        private DateTime _fecha;

        #endregion

        #region Constructor

        public Publicacion(Miembro autor, string texto)
        {
            this._id = s_ultimoId++;
            this._autor = autor;
            this._texto = texto;
            this._fecha = DateTime.Now;
        }

        #endregion
    }
}

