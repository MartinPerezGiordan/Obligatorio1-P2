using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            precargarPosts();
            precargarComentarios();
            precargarReacciones();
            precargarInvitaciones();
            
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
            foreach(Invitacion invitacion in this.GetMiembroById(idMiembroSolicitado).GetInvitacionesRecibidas())
            {
                if(invitacion.GetIdMiembroSolicitante() == idMiembroSolicitante)
                {
                    throw new Exception("Ya se ha enviado una solicitud a ese Miembro");
                }
            }
            if (!GetMiembroById(idMiembroSolicitante).Bloqueado )
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

        //POSIBLEMENTE HAY QUE BORRARLA
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


        private void precargarPosts()
        {
            AgregarPostMiembro(0, "Foto de mis vacaciones en la playa", "¡Hermoso día en la playa hoy!", "vacaciones_playa.jpg", true);
            AgregarPostMiembro(2, "Nuevo libro recomendado", "Acabo de terminar de leer 'Harry Potter' de Martin Perez, ¡altamente recomendado!", "HarryPotter.jpg", true);
            AgregarPostMiembro(2, "Receta de la semana", "Hoy les comparto mi receta favorita de lasaña casera. ¡Es deliciosa!", "receta_lasana.jpg", true);
            AgregarPostMiembro(2, "Noticias de tecnología", "Apple anuncia el lanzamiento de su nuevo iPhone 15. ¡Estoy emocionado!", "iphone_15.jpg", true);
            AgregarPostMiembro(5, "Mi mascota", "Conozcan a mi nuevo cachorro, se llama Sarna <3", "Sarna.jpg", true);
            AgregarPostMiembro(9, "Post privado", "Privado!!", "soloamigoscomentan.jpg", false);
        }

        private void precargarComentarios()
        {
            AgregarComentarioPost(0, 8,"Este es el titulo 1", "Este es el comentario");
            AgregarComentarioPost(0, 1,"Este es el titulo 2", "Comentario 2 post 1");
            AgregarComentarioPost(0, 2,"Este es el titulo 3", "Comentario 3 post 1");
            AgregarComentarioPost(1, 0,"Este es el titulo 4", "Comentario 1 post 2");
            AgregarComentarioPost(1, 1,"Este es el titulo 5", "Comentario 2 post 2");
            AgregarComentarioPost(1, 8,"Este es el titulo 6", "Comentario 3 post 3");
            AgregarComentarioPost(2, 8,"Este es el titulo 7", "Comentario 1 post 3");
            AgregarComentarioPost(2, 8,"Este es el titulo 8", "Comentario 2 post 3");
            AgregarComentarioPost(2, 2,"Este es el titulo 9", "Comentario 3 post 3");
            AgregarComentarioPost(3, 2,"Este es el titulo 10", "Comentario 1 post 4");
            AgregarComentarioPost(3, 3,"Este es el titulo 11", "Comentario 2 post 4");
            AgregarComentarioPost(3, 8,"Este es el titulo 12", "Comentario 3 post 4");
            AgregarComentarioPost(4, 6,"Este es el titulo 13", "Comentario 1 post 5");
            AgregarComentarioPost(4, 5,"Este es el titulo 14", "Comentario 2 post 5");
            AgregarComentarioPost(4, 8,"Este es el titulo 15", "Comentario 3 post 5");
        } 

        private void precargarReacciones()
        {
            LikearUnaPublicacion(1, 0, true);
            LikearUnaPublicacion(2, 0, false);
            LikearUnaPublicacion(3, 0, true);
            LikearUnaPublicacion(4, 0, true);
            LikearUnaPublicacion(5, 0, true);
            LikearUnaPublicacion(1, 0, true);
            LikearUnaPublicacion(2, 0, true);
            LikearUnaPublicacion(3, 0, true);
            LikearUnaPublicacion(1, 1, true);
            LikearUnaPublicacion(2, 1, false);
            LikearUnaPublicacion(3, 1, true);
            LikearUnaPublicacion(4, 1, true);
            LikearUnaPublicacion(5, 1, true);
            LikearUnaPublicacion(1, 1, true);
            LikearUnaPublicacion(2, 1, true);
            LikearUnaPublicacion(3, 1, false);
            LikearUnaPublicacion(1, 5, true);
            LikearUnaPublicacion(2, 5, false);
            LikearUnaPublicacion(3, 5, true);
            LikearUnaPublicacion(4, 5, true);
            LikearUnaPublicacion(5, 5, true);
            LikearUnaPublicacion(1, 5, true);
            LikearUnaPublicacion(2, 5, true);
            LikearUnaPublicacion(3, 5, true);
            LikearUnaPublicacion(1, 6, true);
            LikearUnaPublicacion(2, 6, false);
            LikearUnaPublicacion(3, 6, true);
            LikearUnaPublicacion(4, 6, true);
            LikearUnaPublicacion(5, 6, true);
            LikearUnaPublicacion(1, 6, true);
            LikearUnaPublicacion(2, 6, true);
            LikearUnaPublicacion(3, 6, false);

        }

        private void precargarInvitaciones()
        {
            EnviarInvitacion(0,1);
            EnviarInvitacion(0,2);
            EnviarInvitacion(0,3);
            EnviarInvitacion(0,4);
            EnviarInvitacion(1,5);
            EnviarInvitacion(1,2);
            EnviarInvitacion(1,3);
            EnviarInvitacion(1,4);
            EnviarInvitacion(2,1);
            EnviarInvitacion(2,3);
            EnviarInvitacion(2,4);
            EnviarInvitacion(3,5);
            EnviarInvitacion(3,1);
            EnviarInvitacion(3,2);
            EnviarInvitacion(4,3);
            EnviarInvitacion(5,4);
            EnviarInvitacion(6,1);
            EnviarInvitacion(7,1);
            EnviarInvitacion(8,1);
            EnviarInvitacion(9,1);




            // foreach (Invitacion invitacion in GetMiembroById(1).GetInvitacionesRecibidas())
            // {
            //     AceptarInvitacion(invitacion);
            // }
            // foreach (Invitacion invitacion in GetMiembroById(3).GetInvitacionesRecibidas())
            // {
            //     AceptarInvitacion(invitacion);
            // }
            //
            // foreach (Invitacion invitacion in GetMiembroById(4).GetInvitacionesRecibidas())
            // {
            //    RechazarInvitacion(invitacion);
            // }
        }
    }
}
#endregion
#endregion

