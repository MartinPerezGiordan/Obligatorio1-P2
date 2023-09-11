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
        //ESTO ESTA RARO, PREGUNTAR!
        private Sistema _sistema;

        private static int s_ultimoId = 1;
        private int _id;
        private string _email;
        private string _contrasenia;
        private string _nombre;
        private DateOnly _fechaDeNacimiento;
        private List<Miembro> _listaDeAmigos;
        private List<Invitacion> _invitacionesEnviadas;
        private List<Invitacion> _invitacionesRecibidas;
        private bool _bloqueado;

        #endregion

        #region Constructor
        public Miembro(Sistema sistema, string email, string contrasenia, string nombre, DateOnly fechaDeNacimiento, bool bloqueado)
        {
            this._sistema = sistema;
            this._id = s_ultimoId++;
            this._email = email;
            this._contrasenia = contrasenia;
            this._nombre = nombre;
            this._fechaDeNacimiento = fechaDeNacimiento;
            this._listaDeAmigos = new List<Miembro>(); //Empieza la lista de amigos vacia
            this._invitacionesEnviadas = new List<Invitacion>();
            this._invitacionesRecibidas = new List<Invitacion>();
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

        public List<Invitacion> GetInvitacionesEnviadas()
        {
            return this._invitacionesEnviadas;
        }

        public List<Invitacion> GetInvitacionesRecibidas()
        {
            return this._invitacionesRecibidas;
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

        public void EnviarInvitacion(int idMiembroSolicitado)
        {
            Invitacion nuevaInvitacion = new Invitacion(this._id, idMiembroSolicitado, DateTime.Now);
            this._sistema.AgregarInvitacion(nuevaInvitacion);
        }


        //Recibe un objeto invitacion y agrega al solicitante de la invitacion a la lista de amigos
        //Cambia el estado de la invitacion a aceptada.
        //Saca la invitacion de la lista de invitaciones recibidas del Miembro.
        public void AceptarInvitacion(Invitacion invitacion)
        {
            int idSolicitante = invitacion.GetIdMiembroSolicitante();
            Miembro solicitante = this._sistema.GetMiembroById(idSolicitante);
            this._listaDeAmigos.Add(solicitante);

            invitacion.SetEstadoSolicitud(EstadoSolicitud.APROBADA);

            this._invitacionesRecibidas.Remove(invitacion);
        }

        //Cambia el estado de la invitacion a Rechazada.
        //Saca la invitacion de la lista de invitaciones recibidas del Miembro.
        public void RechazarInvitacion(Invitacion invitacion) 
        {
            invitacion.SetEstadoSolicitud(EstadoSolicitud.RECHAZADA);
            this._invitacionesRecibidas.Remove(invitacion);
        }


        //Ve en la lista de invitaciones que existen en el sistema, si alguna de las 
        //invitaciones pertenece a al miembro la agrega a su lista de invitaciones recibidas.
        public void ActualizarListaDeInvitaciones()
        {
            foreach(Invitacion invitacion in this._sistema.GetInvitaciones())
            {
                if (invitacion.GetIdMiembroSolicitado() == this._id)
                {
                    this._invitacionesRecibidas.Add(invitacion);
                }
            }
        }

        //Ve la lista de invitaciones del sistema. Si alguna de las invitaciones las envio el miembro y estan con estado aceptado
        //entonces se agrega al miembro solicitado a los amigos del solicitante
        public void ActualizarListaDeAmigos()
        {
            foreach (Invitacion invitacion in this._sistema.GetInvitaciones())
            {
                if (invitacion.GetIdMiembroSolicitante() == this._id && invitacion.GetEstadoSolicitud() == EstadoSolicitud.APROBADA)
                {
                    int idMiembroSolicitado = invitacion.GetIdMiembroSolicitado();
                    Miembro miembroSolicitado = _sistema.GetMiembroById(idMiembroSolicitado);
                    this._listaDeAmigos.Add(miembroSolicitado);
                }
            }
        }


        #endregion

        #region Override

        public override string ToString()
        {
            return $"ID: {_id}, Nombre: {_nombre}";
        }

        #endregion

    }
}
