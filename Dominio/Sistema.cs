using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {

        #region Atributos
        private List<Miembro> _miembros;
        private List<Administrador> _administradores;
        private List<Publicacion> _publicaciones;
        private List<Invitacion> _invitaciones;
        private List<Post> _posts;

        #endregion

        #region Constructor
        public Sistema() 
        { 
            this._miembros = new List<Miembro>();
            this._administradores = new List<Administrador>();
            this._invitaciones = new List<Invitacion>();
            this._publicaciones = new List<Publicacion>();
            this._posts = new List<Post>();
        }
        #endregion

        #region Get Y Set

        public List<Miembro> GetMiembros()
        {
            return this._miembros;
        }

        public List<Administrador> GetAdministradores()
        {
            return this._administradores;
        }

        public List<Invitacion> GetInvitaciones()
        {
            return this._invitaciones;
        }

        public List<Post> GetPosts()
        {
            return this._posts;
        }

        public List<Publicacion> GetPublicaciones()
        {
            return this._publicaciones;
        }
        #endregion

        #region Metodos

        #region Metodos Miembro
        public void AgregarMiembro(Miembro miembro)
        {
            //Falta agregar Validacion
            this._miembros.Add(miembro);
        }

        public Miembro GetMiembroById(int id)
        {
            return this._miembros[id];
        }
        #endregion

        public Publicacion GetPublicacionById(int id)
        {
            return this._publicaciones[id];
        }

        public Post GetPostById(int id)
        {
            return this._posts[id];
        }

        #region Metodos Administrador

        public void AgregarAdministrador(Administrador administrador)
        {
            this._administradores.Add(administrador);
        }


        // Metod que permite bloquear o desbloquear a un miembro
        public void BloquearMiembro(int idMiembro, bool bloquear)
        {
            foreach (Miembro unMiembro in this.GetMiembros())
            {
                if(unMiembro.GetId() == idMiembro)
                {
                    unMiembro.SetBloqueado(bloquear);
                }
            }
        }

        //Metod que permite cambiar el valor del atributo censurado de un post
        public void CensurarPost(int idPost, bool censurar)
        {
            foreach (Post unPost in this.GetPosts())
            {
                if (unPost.GetId() == idPost)
                {
                    unPost.SetCensurado(censurar);
                }
            }
        }

        // Agregar un post con id de miembro
        public void AgregarPostMiembro(int idMiembro, string texto, string nombreImagen)
        {
            Post nuevoPost = new Post(this.GetMiembroById(idMiembro), texto, nombreImagen);
            this.AgregarPublicacion(nuevoPost);  
        }

        // Agregar un comentario con id de post y id de miembro que comenta
        public void AgregarComentarioPost(int idPublicacion, int idMiembro, string texto)
        {
            Comentario nuevoComentario = new Comentario(this.GetMiembroById(idMiembro), texto);
            this.GetPostById(idPublicacion).AgregarComentario(nuevoComentario);

        }


        // miSistema.CrearInvitacion(usuarioSolicitante, usuarioSolicitado)

        #endregion

        #region Metodos Invitacion

        public void AgregarInvitacion(Invitacion invitacion)
        {
            this._invitaciones.Add(invitacion);
        }

        #endregion

        #region Metodos Publicacion


        public void AgregarPublicacion(Publicacion publicacion)
        {
            this._publicaciones.Add(publicacion);
        }
        public void AgregarPost(Post publicacion)
        {
            this._posts.Add(publicacion);
        }


        #endregion

        #endregion

    }
}
