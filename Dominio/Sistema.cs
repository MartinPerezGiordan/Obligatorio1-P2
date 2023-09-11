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
        private List<Invitacion> _invitaciones;
        private List<Post> _posts;

        #endregion

        #region Constructor
        public Sistema() 
        { 
            this._miembros = new List<Miembro>();
            this._administradores = new List<Administrador>();
            this._invitaciones = new List<Invitacion>();
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
        #endregion

        #region Metodos

        #region Metodos Miembro
        public void AgregarMiembro(Miembro miembro)
        {
            //Falta agregar Validacion
            this._miembros.Add(miembro);
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

        public void AgregarPostMiembro(int idMiembro, string texto, string nombreImagen)
        {
            foreach (Miembro unMiembro in this.GetMiembros())
            {
                if (unMiembro.GetId() == idMiembro)
                {
                    Post nuevoPost = new Post(unMiembro, texto, nombreImagen);
                    AgregarPost(nuevoPost);
                }
            }
            
        }
        #endregion

        #region Metodos Invitacion

        public void AgregarInvitacion(Invitacion invitacion)
        {
            this._invitaciones.Add(invitacion);
        }

        #endregion

        #region Metodos Publicacion

        public void AgregarPost(Post post)
        {
            this._posts.Add(post);
        }

        #endregion

        #endregion

    }
}
