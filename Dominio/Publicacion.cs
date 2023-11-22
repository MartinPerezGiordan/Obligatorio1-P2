using System;
namespace Dominio
{
	public abstract class Publicacion : IComparable
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
            this.Id = s_ultimoId++;
            this.Autor = autor;
            this.Titulo = titulo;
            this.Texto = texto;
            this.Fecha = DateTime.Now;
            this._reacciones = new List<Reaccion>();
            ValidarContenido();
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

        public void QuitarReaccion(Reaccion reaccion)
        {
            this._reacciones.Remove(reaccion);
        }

        public void ValidarContenido()
        {
            if (this.Texto == null)
            {
                throw new Exception("El contenido no puede estar vacio!!");
            }
        }


        public bool HaDadoLike(int idMiembro)
        {
            bool haDadoLike = false;
            foreach (Reaccion reaccion in this.GetReacciones())
            {
                if (reaccion.IdMiembro == idMiembro && reaccion.Like)
                {
                    haDadoLike = true;
                    break;
                }
            }
            return haDadoLike;
        }

        public bool HaDadoDislike(int idMiembro)
        {
            bool haDadoDislike = false;
            foreach (Reaccion reaccion in this.GetReacciones())
            {
                if (reaccion.IdMiembro == idMiembro && !reaccion.Like)
                {
                    haDadoDislike = true;
                    break;
                }
            }
            return haDadoDislike;
        }

        public int CalcularLikes()
        {
            int likes = 0;
            foreach (Reaccion reaccion in this._reacciones)
            {
                if (reaccion.Like)
                {
                    likes++;
                }
            }
            return likes;
        }

        public int CalcularDislikes()
        {
            int dislikes = 0;

            foreach (Reaccion reaccion in this._reacciones)
            {
                if (!reaccion.Like)
                {
                    dislikes++;
                }
            }
            return dislikes;
        }

        public abstract double CalcularVA();




        public int CompareTo(Object? obj)
        {
            if(obj == null)
            {
                throw new Exception("obj es null");
            }

            Publicacion otra = obj as Publicacion;

            return this.Titulo.CompareTo(otra.Titulo);

        }
        #endregion
    }
}

