using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Post : Publicacion
    {

        #region Atributos

        private string _nombreImagen;
        private List<Comentario> _comentarios;
        private bool _privado;
        private bool _censurado;

        #endregion

        #region Constructor
        public Post(Miembro autor, string texto, string nombreImagen) : base(autor, texto)
        {
            this._privado = false;
            this._censurado = false;
            this._comentarios = new List<Comentario>();

        }

        public Post(Miembro autor, string texto, string nombreImagen, List<Comentario> comentarios) : base(autor, texto)
        {
            this._privado = false;
            this._censurado = false;
            this._comentarios = comentarios;
        }

        #endregion

        #region Get y Set

        public int GetId()
        {
            return this._id;
        }

        public bool GetCensurado()
        {
            return this._censurado;
        }

        public List<Comentario> GetComentarios()
        {
            return this._comentarios;
        }

        #endregion

        #region Metodos

        public void AgregarComentario(Comentario comentario)
        {
            this._comentarios.Add(comentario);
        }

        public void SetCensurado(bool censurar)
        {
            this._censurado = censurar;
        }

        #endregion
    }
}
