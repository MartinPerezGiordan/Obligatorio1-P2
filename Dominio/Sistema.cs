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
        private List<Publicacion> _publicaciones;

        #endregion

        #region Constructor
        public Sistema() 
        { 
            this._miembros = new List<Miembro>();
            this._administradores = new List<Administrador>();
            this._invitaciones = new List<Invitacion>();
            this._publicaciones = new List<Publicacion>();
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

        #endregion

        #endregion

    }
}
