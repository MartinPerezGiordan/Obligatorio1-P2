using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dominio
{
    public class Post : Publicacion
    {

        #region Atributos

        public string NombreImagen;
        private List<Comentario> _comentarios;
        public bool Publico { get; set; }
        public bool Censurado { get; set; }

        #endregion

        #region Constructor
        public Post(Miembro autor, string titulo, string texto, string nombreImagen, bool publico) : base(autor, texto, titulo)
        {

            this.Publico = publico;
            this.Censurado = false;
            this._comentarios = new List<Comentario>();
            this.NombreImagen = nombreImagen;
            ValidarNombreImagen();

        }


        #endregion

        #region Get y Set

        public List<Comentario> GetComentarios()
        {
            return this._comentarios;
        }

        #endregion

        #region Metodos

        // Agregar Comentario al Post
        public void AgregarComentario(Comentario comentario)
        {
            if(this.Censurado == false)
            {
                this._comentarios.Add(comentario);
            } else
            {
                throw new Exception("Post esta censurado");
            }
        }

        public void SetCensurado(bool censurar)
        {
            this.Censurado = censurar;
        }

        public void ValidarNombreImagen()
        {
            string ultimasCuatro = this.NombreImagen.Substring(this.NombreImagen.Length - 4);
            if (ultimasCuatro != ".png" && ultimasCuatro != ".jpg")
            {
                throw new Exception("La imagen debe ser .jpg o .png");
            }
        }


        public override double CalcularVA()
        {
            double VA = 0;
            int likes = this.CalcularLikes();
            int dislikes = this.CalcularDislikes();

            VA = (likes* 5) + (dislikes* -2);

            if (this.Publico)
            {
                VA += 10;
            }
            return VA;
        }
                
        


        #endregion

        #region Override

        public override string ToString()
        {
            return $"Id: {this.Id} {Environment.NewLine}Autor: {this.Autor.Nombre} {Environment.NewLine}Texto: {this.Texto} {Environment.NewLine}Fecha: {this.Fecha} {Environment.NewLine}Nombre Imagen: {this.NombreImagen}{Environment.NewLine}";
        }
        #endregion
    }
}
