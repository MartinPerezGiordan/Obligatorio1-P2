using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Miembro: IComparable
    {
        #region Atributos

        private static int s_ultimoId = 0;
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        private List<Miembro> _listaDeAmigos;
        private List<Invitacion> _invitacionesEnviadas;
        private List<Invitacion> _invitacionesRecibidas;
        public bool Bloqueado { get; set; }
        public int CantidadDePublicaciones { get; set; }

        #endregion

        #region Constructor
        public Miembro(string email, string contrasenia, string nombre, string apellido, DateTime fechaDeNacimiento, bool bloqueado)
        {
            this.Id = s_ultimoId++;
            this.Email = email;
            this.Contrasenia = contrasenia;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaDeNacimiento = fechaDeNacimiento;
            this._listaDeAmigos = new List<Miembro>(); //Empieza la lista de amigos vacia
            this._invitacionesEnviadas = new List<Invitacion>();
            this._invitacionesRecibidas = new List<Invitacion>();
            this.Bloqueado = bloqueado;
            this.CantidadDePublicaciones = 0;
        }
        public Miembro() { }

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

        private bool esAmigoById(int id)
        {
            bool esAmigo = false;
            foreach(Miembro unMiembro in this._listaDeAmigos)
            {
                if(id == unMiembro.Id)
                {
                    esAmigo = true;
                    break;
                }
            }
            return esAmigo;
        }

        private bool esPendienteById(int id)
        {
            bool esPendiente = false;
            foreach(Invitacion invitacion in this.GetInvitacionesEnviadas())
            {
                if(invitacion.GetIdMiembroSolicitado() == id && invitacion.GetEstadoSolicitud() == EstadoSolicitud.PENDIENTE_APROBACION)
                {
                    esPendiente = true;
                    break;
                }
            }
            foreach (Invitacion invitacion in this.GetInvitacionesRecibidas())
            {
                if(invitacion.GetIdMiembroSolicitante() == id && invitacion.GetEstadoSolicitud() == EstadoSolicitud.PENDIENTE_APROBACION)
                {
                    esPendiente = true;
                    break;
                }
            }
            return esPendiente;
        }

        //Devuelve los miembros que no son amigos del usuario y que tampoco tienen una invitacion pendiente
        public List<Miembro> ObtenerNoAmigos()
        {
            List<Miembro> noAmigos = new List<Miembro>();

            foreach (Miembro unMiembro in Sistema.Instancia.GetMiembros())
            {
                if (!this.esAmigoById(unMiembro.Id) && unMiembro.Id != this.Id && !this.esPendienteById(unMiembro.Id))
                {
                        noAmigos.Add(unMiembro);
                }
            }
            return noAmigos;
        }

        public List<Miembro> ObtenerMiembrosConInvitacionesPendientes()
        {
            List<Miembro> pendientes = new List<Miembro>();

            foreach(Miembro miembro in Sistema.Instancia.GetMiembros())
            {
                if (this.esPendienteById(miembro.Id))
                {
                    pendientes.Add(miembro);
                }
            }
            return pendientes;
        }

        public List<Miembro> ObtenerMiembrosConInvitacionesPendientesRecibidas()
        {
            List<Miembro> pendientes = new List<Miembro>();
            foreach(Invitacion invitacion in this.GetInvitacionesRecibidas())
            {
                if(invitacion.GetEstadoSolicitud() == EstadoSolicitud.PENDIENTE_APROBACION)
                {
                    pendientes.Add(Sistema.Instancia.GetMiembroById(invitacion.GetIdMiembroSolicitante()));
                }
            }
            return pendientes;
        }

  

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
            ValidarApellido();
            ValidarContrasenia();
            ValidarEmail();
            ValidarNacimiento();
        }

        public void ValidarNombre()
        {
            if (this.Nombre.Length < 3)
            {
                throw new Exception("El nombre no puede ser menor a 3 caracteres");
            }
        }
        public void ValidarApellido()
        {
            if (this.Apellido.Length < 1)
            {
                throw new Exception("Apellido no puede estar vacio");
            }
        }
        public void ValidarEmail()
        {
            if (this.Email.Length < 1)
            {
                throw new Exception("Email no puede estar vacio");
            }
            string ultimasCuatro = this.Email.Substring(this.Email.Length - 4);
            if (ultimasCuatro != ".com" || !this.Email.Contains("@"))
            {
                throw new Exception("Email invalido");
            }
        }
        public void ValidarContrasenia()
        {
            if (this.Contrasenia.Length < 8)
            {
                throw new Exception("La contraseña no puede ser menor a 8 caracteres");
            }
        }


        public void ValidarNacimiento()
        {
            DateTime fechaLimite = DateTime.Now.AddYears(-13);
            if (this.FechaDeNacimiento >= fechaLimite)
            {
                throw new Exception("Para registrarse debe ser mayor a 13 años");
            }
        }


        #endregion

        #region Override

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}, Contraseña: {Contrasenia}," +
                $" Fecha de Nacimiento: {FechaDeNacimiento}, Bloqueado: {Bloqueado}," +
                $" Cantidad de Publicaciones: {CantidadDePublicaciones}";
        }



        public int CompareTo(Object? obj)
        {
            if (obj == null)
            {
                throw new Exception("obj es null");
            }

            Miembro otro = obj as Miembro;

            return this.Apellido.CompareTo(otro.Apellido);

        }

        #endregion

    }
}
