using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Miembro
    {
        #region Atributos

        private static int s_ultimoId = 1;
        private int _id;
        private string _email;
        private string _contrasenia;
        private string _nombre;
        //DEJAR APELLIDO??
        //private string _apellido;
        private DateOnly _fechaDeNacimiento;
        private List<Miembro> _listaDeAmigos;
        private List<Invitacion> _invitaciones;
        private bool _bloqueado;

        #endregion

        #region Constructor
        public Miembro(string email, string contrasenia, string nombre, DateOnly fechaDeNacimiento, bool bloqueado)
        {
            this._id = s_ultimoId++;
            this._email = email;
            this._contrasenia = contrasenia;
            this._nombre = nombre;
            this._fechaDeNacimiento = fechaDeNacimiento;
            this._listaDeAmigos = new List<Miembro>(); //Empieza la lista de amigos vacia
            this._invitaciones = new List<Invitacion>(); // Supongo que los miembros van a tener una lista de invitacios para aceptar o rechazar
            this._bloqueado = bloqueado;
        }

        #endregion

        #region Get Y Set

        public int GetId()
        {
            return this._id;
        }

        public string GetEmail()
        {
            return this._email;
        }

        public string GetContrasenia()
        {
            return this._contrasenia;
        }

        public string GetNombre()
        {
            return this._nombre;
        }

        public DateOnly GetFechaDeNacimiento()
        {
            return this._fechaDeNacimiento;
        }

        public List<Miembro> GetListaDeAmigos()
        {
            return this._listaDeAmigos;
        }

        public List<Invitacion> GetInvitaciones()
        {
            return this._invitaciones;
        }

        public bool GetBloqueado()
        {
            return this._bloqueado;
        }

        public void SetBloqueado(bool bloqueado)
        {
            this._bloqueado = bloqueado;
        }

        #endregion

        #region Metodos



        #endregion

        #region Override
        #endregion

    }
}
