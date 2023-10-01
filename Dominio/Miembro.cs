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

        private static int s_ultimoId = 0;
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        private List<Miembro> _listaDeAmigos;
        private List<Invitacion> _invitacionesEnviadas;
        private List<Invitacion> _invitacionesRecibidas;
        public bool Bloqueado { get; set; }
        public int CantidadDePublicaciones { get; set; }

        #endregion

        #region Constructor
        public Miembro(string email, string contrasenia, string nombre, DateTime fechaDeNacimiento, bool bloqueado)
        {
            this.Id = s_ultimoId++;
            this.Email = email;
            this.Contrasenia = contrasenia;
            this.Nombre = nombre;
            this.FechaDeNacimiento = fechaDeNacimiento;
            this._listaDeAmigos = new List<Miembro>(); //Empieza la lista de amigos vacia
            this._invitacionesEnviadas = new List<Invitacion>();
            this._invitacionesRecibidas = new List<Invitacion>();
            this.Bloqueado = bloqueado;
            this.CantidadDePublicaciones = 0;
            Validar();
            
        }

        #endregion

        #region Get Y Set


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

        #endregion

        #region Metodos

        public void AgregarAmigo(Miembro miembro)
        {
            this._listaDeAmigos.Add(miembro);
        }

        public void AgregarInvitacionRecibida(Invitacion invitacion)
        {
            this._invitacionesRecibidas.Add(invitacion);
        }

        public void AgregarInvitacionEnviada(Invitacion invitacion)
        {
            this._invitacionesEnviadas.Add(invitacion);
        }

        public void Validar()
        {
            ValidarNombre();
        }

        public void ValidarNombre()
        {
            if (this.Nombre.Length < 3)
            {
                throw new Exception("El nombre no puede ser menor a 3 car");
            }
        }
        #endregion

        #region Override

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}";
        }

        #endregion

    }
}
