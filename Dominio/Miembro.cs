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

        private static int _ultimoId;
        private int _id;
        private string _email;
        private string _contrasenia;
        private string _nombre;
        //DEJAR APELLIDO??
        //private string _apellido;
        private DateTime _fechaDeNacimiento;
        private List<Miembro> _listaDeAmigos;
        private bool _bloqueado;

        #endregion

        #region Constructor
        public Miembro(string email, string contrasenia, string nombre, DateTime fechaDeNacimiento, bool bloqueado)
        {
            this._id = _ultimoId++;
            this._email = email;
            this._contrasenia = contrasenia;
            this._nombre = nombre;
            this._fechaDeNacimiento = fechaDeNacimiento;
            this._listaDeAmigos = new List<Miembro>(); //Empieza la lista de amigos vacia
            this._bloqueado = bloqueado;
        }

        #endregion

        #region GET Y SET

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

        public DateTime GetFechaDeNacimiento()
        {
            return this._fechaDeNacimiento;
        }

        public List<Miembro> GetListaDeAmigos()
        {
            return this._listaDeAmigos;
        }

        public bool GetBloqueado()
        {
            return this._bloqueado;
        }

        #endregion

        #region Metodos



        #endregion

        #region Override
        #endregion

    }
}
