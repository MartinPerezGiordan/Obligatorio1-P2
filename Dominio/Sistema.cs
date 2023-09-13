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

        public List<Invitacion> VerInvitacionesEnviadas(Miembro miembro)
        {
            return miembro.GetInvitacionesEnviadas();
        }

        public List<Invitacion> VerInvitacionesRecibidas(Miembro miembro)
        {
            return miembro.GetInvitacionesRecibidas();
        }

        public void EnviarInvitacion(int idMiembroSolicitante, int idMiembroSolicitado)
        {
            Invitacion nuevaInvitacion = new Invitacion(idMiembroSolicitante, idMiembroSolicitado, DateTime.Now);
            this.AgregarInvitacion(nuevaInvitacion);
        }

        //Recibe un objeto invitacion y agrega al solicitante de la invitacion a la lista de amigos
        //Cambia el estado de la invitacion a aceptada.
        public void AceptarInvitacion(Invitacion invitacion)
        {
            int idSolicitante = invitacion.GetIdMiembroSolicitante();
            Miembro solicitante = GetMiembroById(idSolicitante);

            int idSolicitado = invitacion.GetIdMiembroSolicitado();
            Miembro solicitado = GetMiembroById(idSolicitado);
            solicitado.AgregarAmigo(solicitante);
            solicitante.AgregarAmigo(solicitado);

            invitacion.SetEstadoSolicitud(EstadoSolicitud.APROBADA);

        }

        //Cambia el estado de la invitacion a Rechazada.
        public void RechazarInvitacion(Invitacion invitacion)
        {
            invitacion.SetEstadoSolicitud(EstadoSolicitud.RECHAZADA);
        }

        //Ve en la lista de invitaciones que existen en el sistema, si alguna de las 
        //invitaciones pertenece a al miembro la agrega a su lista de invitaciones recibidas.
        public void ActualizarListaDeInvitaciones(Miembro miembro)
        {
            foreach (Invitacion invitacion in this._invitaciones)
            {
                if (invitacion.GetIdMiembroSolicitado() == miembro.GetId())
                {
                    miembro.AgregarInvitacionRecibida(invitacion);
                }
            }
        }





        #endregion

        public Publicacion GetPublicacionById(int id)
        {
            return this._publicaciones[id];
        }

        public Miembro GetMiembroByEmail(string email)
        {
            foreach(Miembro unMiembro in this.GetMiembros())
            {
                if(unMiembro.GetEmail() == email)
                {
                    return unMiembro;
                }
            }
            return null;
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
            this.GetMiembroById(idMiembro).SetBloqueado(bloquear);
        }

        //Metod que permite cambiar el valor del atributo censurado de un post
        public void CensurarPost(int idPost, bool censurar)
        {
            this.GetPostById(idPost).SetCensurado(censurar);
        }

        #region Post y Comentario

        // Agregar un post con id de miembro
        public void AgregarPostMiembro(int idMiembro, string texto, string nombreImagen)
        {
            Post nuevoPost = new Post(this.GetMiembroById(idMiembro), texto, nombreImagen);
            this.AgregarPublicacion(nuevoPost);
            this.AgregarPost(nuevoPost);
        }

        // Agregar un comentario con id de post y id de miembro que comenta
        public void AgregarComentarioPost(int idPublicacion, int idMiembro, string texto)
        {
            Comentario nuevoComentario = new Comentario(idPublicacion, this.GetMiembroById(idMiembro), texto);
            this.GetPostById(idPublicacion).AgregarComentario(nuevoComentario);
            this.AgregarPublicacion(nuevoComentario);
        }

        // Busqueda de publicaciones de un miembro por Email
        public List<Publicacion> GetPublicacionesPorEmail(string email)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            foreach(Publicacion unaPublicacion in this.GetPublicaciones())
            {
                if(unaPublicacion.GetAutor().GetEmail() == email)
                {
                    publicaciones.Add(unaPublicacion);
                }

            }
            return publicaciones;
        }

        // Identificar comentarios en una lista de publicaciones
        public List<Comentario> IdentificarComentarios(List<Publicacion> publicaciones)
        {
            List<Comentario> comentarios = new List<Comentario>();
            for(int i=0; i < publicaciones.Count; i++)
            {
                if (publicaciones[i] is Comentario)
                {
                    Comentario comment = (Comentario)publicaciones[i];
                    comentarios.Add(comment);
                }
            }
            return comentarios;
        }

        // Identificar posts en una lista de publicaciones
        public List<Post> IdentificarPosts(List<Publicacion> publicaciones)
        {
            List<Post> posts = new List<Post>();
            for (int i = 0; i < publicaciones.Count; i++)
            {
                if (publicaciones[i] is Post)
                {
                    Post post = (Post)publicaciones[i];
                    posts.Add(post);
                }
            }
            return posts;
        }

        public List<Comentario> GetComentariosPorEmail(string email)
        {
            List<Comentario> comentarios = new List<Comentario>();
            foreach (Publicacion unaPublicacion in this.GetPublicaciones())
            {
                if (unaPublicacion.GetAutor().GetEmail() == email)
                {
                    if (unaPublicacion is Comentario)
                    {
                        Comentario comment = (Comentario)unaPublicacion;
                        comentarios.Add(comment);
                    }
                }

            }
            return comentarios;
        }

        public List<Publicacion> GetPostPorComentarios(List<Comentario> comentarios)
        {
            List<Publicacion> posts = new List<Publicacion>();
            foreach (Comentario unComentario in comentarios)
            {
                Publicacion publicacion = this.GetPublicacionById(unComentario.GetIdPost());
                posts.Add(publicacion);
            }
            
            return posts.Distinct().ToList();
        }
        
        public string GetStringPosts(List<Publicacion> posts)
        {
            string postString = "";
            foreach(Publicacion unPost in posts)
            {
                postString += unPost.ToString();
            }
            return postString;
        }

        public string menu2(string email)
        {
            string posts = this.GetStringPosts(this.GetPostPorComentarios(this.GetComentariosPorEmail(email)));
            return posts;
        }

        #endregion


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
