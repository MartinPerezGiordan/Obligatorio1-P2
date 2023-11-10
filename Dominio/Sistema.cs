﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {

        #region Atributos

        private static Sistema s_instancia;
        public static Sistema Instancia{
            get
            {
                if(s_instancia == null)
                {
                    s_instancia = new Sistema();
                }
                return s_instancia; 
            }
        }
        private List<Miembro> _miembros;
        private List<Administrador> _administradores;
        private List<Publicacion> _publicaciones;
        private List<Invitacion> _invitaciones;
        private Miembro _miembroLogueado;

        #endregion

        #region Constructor
        private Sistema() 
        {
            this._miembros = new List<Miembro>();
            this._administradores = new List<Administrador>();
            this._invitaciones = new List<Invitacion>();
            this._publicaciones = new List<Publicacion>();
            precargarUsuarios();
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

        public List<Publicacion> GetPublicaciones()
        {
            return this._publicaciones;
        }
        public Miembro GetMiembroLoguedao()
        {
            return this._miembroLogueado;
        }
        #endregion

        #region Metodos

        #region Metodos Miembro
        public void AgregarMiembro(Miembro miembro)
        {
            miembro.Validar();
            this._miembros.Add(miembro);
        }

        public void validarEmailRegistro(string email)
        {
            foreach(Miembro unMiembro in this.GetMiembros())
            {
                if(unMiembro.Email == email)
                {
                    throw new Exception("Email ya esta registrado");
                }
            }
        }
        public void Login(string email, string contrasenia)
        {
            this.ValidarLogin(email, contrasenia);
            this._miembroLogueado = this.GetMiembroByEmail(email);
        }
        public bool ValidarLogin(string email, string contrasenia)
        {
            bool seEncontro = false;
            foreach (Miembro unMiembro in this.GetMiembros())
            {
                if (unMiembro.Email == email && unMiembro.Contrasenia == contrasenia)
                {
                    seEncontro = true; break;
                }
            }

            return seEncontro;
        }

        public Miembro GetMiembroById(int id)
        {
            return this._miembros[id];
        }


        //De parametro se toman ambas ids, la del solicitante y la del solicitado
        //Si el solicitante esta bloqueado se envia un error
        //En caso opuesto se procede a crear la Invitacion y se agrega a la lista de invitaciones del sistema
        public void EnviarInvitacion(int idMiembroSolicitante, int idMiembroSolicitado)
        {
            if (!GetMiembroById(idMiembroSolicitante).Bloqueado)
            {
                Invitacion nuevaInvitacion = new Invitacion(idMiembroSolicitante, idMiembroSolicitado, DateTime.Now);
                this.AgregarInvitacion(nuevaInvitacion);
                GetMiembroById(idMiembroSolicitante).AgregarInvitacionEnviada(nuevaInvitacion);
                GetMiembroById(idMiembroSolicitado).AgregarInvitacionRecibida(nuevaInvitacion);

            }
            else
            {
                throw new Exception("El miembro esta bloqueado, no puede enviar una invitacion");
            }
        }


        //Recibe un objeto invitacion y verifica que el solicitado no este bloqueado en cuyo caso manda un error.
        //Si no esta bloqueado agrega al solicitante de la invitacion a la lista de amigos
        //Cambia el estado de la invitacion a aceptada.
        public void AceptarInvitacion(Invitacion invitacion)
        {
            int idSolicitante = invitacion.GetIdMiembroSolicitante();
            Miembro solicitante = GetMiembroById(idSolicitante);

            int idSolicitado = invitacion.GetIdMiembroSolicitado();
            Miembro solicitado = GetMiembroById(idSolicitado);

            if (!solicitado.Bloqueado)
            {
                solicitado.AgregarAmigo(solicitante);
                solicitante.AgregarAmigo(solicitado);

                invitacion.SetEstadoSolicitud(EstadoSolicitud.APROBADA);
            }
            else
            {
                throw new Exception("El miembro esta bloqueado, no puede aceptar una invitacion");

            }
        }

        //Cambia el estado de la invitacion a Rechazada en el caso de que el Miembro solicitado no este bloqueado
        public void RechazarInvitacion(Invitacion invitacion)
        {
            int idSolicitado = invitacion.GetIdMiembroSolicitado();
            Miembro solicitado = GetMiembroById(idSolicitado);
        
            if (!solicitado.Bloqueado)
            { 
                invitacion.SetEstadoSolicitud(EstadoSolicitud.RECHAZADA);
            }
        }

        public Miembro GetMiembroByEmail(string email)
        {
            foreach(Miembro unMiembro in this.GetMiembros())
            {
                if(unMiembro.Email == email)
                {
                    return unMiembro;
                }
            }
            return null;
        }

        //Esta funcion permite tanto Likear una publicacion como dislikearla.
        //Acepta 3 parametros, el miembro que likea, la publicacion y si es un like(true) o dislike(false)
        //Primero ve si ya existe un like o dislike en la publicacion hecho por ese miembro, en cuyo caso solo lo cambia de like a dislike o viceversa.
        //En caso contrario crea la reaccion con el constructor de reacciones y luego lo agrega a la lista de reacciones de la publicacion.
        public void LikearUnaPublicacion(int idMiembro, int idPublicacion, bool like)
        {
            bool noHayReaccion = true;
            Publicacion publicacion = this.GetPublicacionById(idPublicacion);

            foreach(Reaccion unaReaccion in publicacion.GetReacciones())
            {
                if(unaReaccion.IdMiembro == idMiembro)
                {
                    unaReaccion.Like = like;
                    noHayReaccion = false;
                }
            }

            if(noHayReaccion)
            {
            Reaccion reaccion = new Reaccion(like,idMiembro);
            publicacion.AgregarReaccion(reaccion);
            }
        }


        #endregion

        #region Metodos Administrador

        public void AgregarAdministrador(Administrador administrador)
        {
            this._administradores.Add(administrador);
        }


        // Metod que permite bloquear o desbloquear a un miembro
        public void BloquearMiembro(int idMiembro, bool bloquear)
        {
            this.GetMiembroById(idMiembro).Bloqueado = bloquear;
        }

        //Metod que permite cambiar el valor del atributo censurado de un post
        public void CensurarPost(int idPost, bool censurar)
        {
            if (this.GetPublicacionById(idPost) is Post)
            {
                Post post = (Post)this.GetPublicacionById(idPost);
                post.SetCensurado(censurar);
            }
            else
            {
                throw new Exception("No se puede censurar comentarios");
            }
        }

        #region Post y Comentario

        // Agregar un post con id de miembro y Suma la cantidad de posts que realizo el miembro
        public void AgregarPostMiembro(int idMiembro,string titulo, string texto, string nombreImagen, bool privado)
        {
            Miembro miembro = GetMiembroById(idMiembro);
            miembro.CantidadDePublicaciones++;
            Post nuevoPost = new Post(this.GetMiembroById(idMiembro), titulo, texto, nombreImagen, privado);
            this.AgregarPublicacion(nuevoPost);
        }

        // Agregar un comentario con id de post y id de miembro que comenta verifica si es privado(y deja agregar un comentario de un amigo) o publico y Suma la cantidad de posts que realizo el miembro
        public void AgregarComentarioPost(int idPublicacion, int idMiembro, string titulo, string texto)
        {
            Miembro miembro = GetMiembroById(idMiembro);
            Miembro miembroPublicacion = this.GetPublicacionById(idPublicacion).Autor;           
            Comentario nuevoComentario = new Comentario(idPublicacion, miembro, titulo, texto);
            if (this.GetPublicacionById(idPublicacion) is Post)
            {
                Post post = (Post)this.GetPublicacionById(idPublicacion);
                if(post.Publico == true || (post.Publico == false && miembroPublicacion.GetListaDeAmigos().Contains(miembro)))
                {
                    post.AgregarComentario(nuevoComentario);
                    miembro.CantidadDePublicaciones++;
                    this.AgregarPublicacion(nuevoComentario);
                }
                else
                {
                    throw new Exception("El post es privado");
                }
            }
            else
            {
                throw new Exception("El id de publicacion no corresponde a un post");
            }
        }

        //Validacion de email del usuario en la que se busca si existe ese mail en la lista
        //para algun miembro de la lista de miembros. Si no existe se lanza una exception.
        public void validarEmail(string email)
        {
            bool seEncontro = false;
            foreach(Miembro unMiembro in this.GetMiembros())
            {
                if(unMiembro.Email == email)
                {
                    seEncontro = true; break;
                }
            }
            if (!seEncontro)
            {
                throw new Exception("No existe un usuario con ese mail");
            }
        }

        // Busqueda de publicaciones de un miembro por Email.
        //Primero se valida si existe el email y luego se busca si ese email tiene publicaciones
        //En caso de tenerlas se busca todas las publicaciones que tiene ese miembro segun su mail.
        //Si no tiene ninguna se lanza una exception. 
        public List<Publicacion> GetPublicacionesPorEmail(string email)
        {
            validarEmail(email);
            bool noHayRegistros = true;
            List<Publicacion> publicaciones = new List<Publicacion>();
            foreach(Publicacion unaPublicacion in this.GetPublicaciones())
            {
                if(unaPublicacion.Autor.Email == email)
                {
                    publicaciones.Add(unaPublicacion);
                    noHayRegistros = false;
                }

            }
            if (noHayRegistros)
            {
                throw new Exception("No hay publicaciones para ese usuario");
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
                if (publicaciones[i] is Post && ((Post)publicaciones[i]).Censurado == false)
                {
                    Post post = (Post)publicaciones[i];
                    posts.Add(post);
                }
            }
            return posts;
        }

        // Busqueda de comentarios de un miembro por Email
        //Primero se valida si el email existe
        //Se busca en las publicaciones y se arma una lista con todos las publicaciones 
        //vinculadas a ese email y si son comentario se agregan a la lista que va a retornar
        //este metodo
        public List<Comentario> GetComentariosPorEmail(string email)
        {
            validarEmail(email);
            List<Comentario> comentarios = new List<Comentario>();
            bool hayComentarios = false;
            foreach (Publicacion unaPublicacion in this.GetPublicaciones())
            {
                if (unaPublicacion.Autor.Email == email)
                {
                    if (unaPublicacion is Comentario)
                    {
                        hayComentarios = true;
                        Comentario comment = (Comentario)unaPublicacion;
                        comentarios.Add(comment);
                    }
                }
            }
            if (!hayComentarios)
            {
                throw new Exception("Este usuario aun no ha hecho comentarios");
            }
            return comentarios;
        }

        // Busqueda de post comentador por un miembro por Email
        public List<Post> GetPostPorComentarios(List<Comentario> comentarios)
        {
            List<Post> posts = new List<Post>();
            foreach (Comentario unComentario in comentarios)
            {
                Post post = (Post)this.GetPublicacionById(unComentario.IdPost);
                posts.Add(post);
            }
            
            return posts.Distinct().ToList();
        }


        #endregion

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
        public Publicacion GetPublicacionById(int id)
        {
            return this._publicaciones[id];
        }

        public double CalcularVA(int idPublicacion)
        {
            Publicacion publicacion = GetPublicacionById(idPublicacion);
            double VA = 0;
            int likes = 0;
            int dislikes = 0;
            
            foreach(Reaccion reaccion in publicacion.GetReacciones())
            {
                if (reaccion.Like)
                {
                    likes++;
                }
                else
                {
                    dislikes++;
                }
            }

            VA = (likes * 5) + (dislikes * -2);

            if(publicacion is Post)
            {
                Post post = (Post) publicacion;
                if (post.Publico)
                {
                    VA += 10;
                }
            }

            return VA;
        }

        #endregion
        #region Precargas

        private void precargarUsuarios()
        {
            AgregarMiembro(new Miembro("correo0@example.com", "contrasenia1", "Juan", "Perez", new DateTime(1990, 1, 1), false));
            AgregarMiembro(new Miembro("correo1@example.com", "contrasenia2", "Ana",  "Gomez", new DateTime(1985, 3, 15), false));
            AgregarMiembro(new Miembro("correo2@example.com", "contrasenia3", "Luis", "Rodriguez", new DateTime(1995, 5, 20), false));
            AgregarMiembro(new Miembro("correo3@example.com", "contrasenia4", "Maria", "Lopez", new DateTime(1980, 10, 10), false));
            AgregarMiembro(new Miembro("correo4@example.com", "contrasenia5", "Sofia", "Torres", new DateTime(1988, 6, 5), false));
            AgregarMiembro(new Miembro("correo5@example.com", "contrasenia6", "Pedro", "Martinez", new DateTime(1992, 12, 30), false));
            AgregarMiembro(new Miembro("correo6@example.com", "contrasenia7", "Laura", "Sanchez", new DateTime(1993, 8, 25), false));
            AgregarMiembro(new Miembro("correo7@example.com", "contrasenia8", "Carlos", "Gonzalez", new DateTime(1975, 4, 2), false));
            AgregarMiembro(new Miembro("correo8@example.com", "contrasenia9", "Marta", "Ramirez", new DateTime(1982, 7, 12), false));
            AgregarMiembro(new Miembro("correo9@example.com", "contrasenia10", "Jose", "Fernandez", new DateTime(1998, 11, 15), false));
        }

        #endregion
        #endregion

    }
}
