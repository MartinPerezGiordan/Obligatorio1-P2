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

        #region Metodos

        #endregion
    }
}
