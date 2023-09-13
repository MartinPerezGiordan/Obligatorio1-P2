using System;
namespace Dominio
{
	public abstract class Publicacion
	{
        #region Atributos

        private static int s_ultimoId = 0;
        internal int _id;
        private string _titulo;
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

        #region Get Y Set

        public int GetId()
        {
            return this._id;
        }

        public string GetTitulo()
        {
            return this._titulo;
        }

        public string GetTexto()
        {
            return this._texto;
        }

        public Miembro GetAutor()
        {
            return this._autor;
        }
        public string GetAutorNombre()
        {
            return this._autor.GetNombre();
        }

        public DateTime GetFecha()
        {
            return this._fecha;
        }

        public string GetFechaString()
        {
            return this._fecha.ToString();
        }

        #endregion
    }
}

