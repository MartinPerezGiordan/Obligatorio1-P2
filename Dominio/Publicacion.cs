using System;
namespace Dominio
{
	public abstract class Publicacion
	{
        #region Atributos

        private static int s_ultimoId = 0;
        public int Id { get; set; }
        public string Titulo;
        public Miembro Autor;
        public string Texto;
        public DateTime Fecha;
        private List<Reaccion> _reacciones;

        #endregion

        #region Constructor

        public Publicacion(Miembro autor, string texto, string titulo)
        {

            if (texto == null)
            {
                throw new Exception("El contenido no puede estar vacio!!");
            }

            this.Id = s_ultimoId++;
            this.Autor = autor;
            this.Titulo = titulo;
            this.Texto = texto;
            this.Fecha = DateTime.Now;
            this._reacciones = new List<Reaccion>();
        }

        #endregion

        #region Get Y Set

        public string GetAutorNombre()
        {
            return this.Autor.Nombre;
        }

        public List<Reaccion> GetReacciones()
        {
            return this._reacciones;
        }

        #endregion

        #region Metodos
        public void AgregarReaccion(Reaccion reaccion)
        {
            this._reacciones.Add(reaccion);
        }


        #endregion
    }
}

