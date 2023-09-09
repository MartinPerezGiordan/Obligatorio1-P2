using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Invitacion
    {

        #region Atributos

        private static int s_ultimoId=0;
        private int _id;
        private Miembro _miembroSolicitante;
        private Miembro _miembroSolicitado;
        private EstadoSolicitud _estado;
        private DateOnly _fechaDeSolicitud;

        #endregion

        #region Constructor

        public Invitacion(Miembro miembroSolicitante, Miembro miembroSolicitado, EstadoSolicitud estado, DateOnly fechaDeSolicitud)
        {
            this._id = s_ultimoId++;
            this._miembroSolicitante = miembroSolicitante;
            this._miembroSolicitado = miembroSolicitado;
            this._estado = estado;
            this._fechaDeSolicitud = fechaDeSolicitud;
        }

        #endregion

        #region Get Y Set

        public int GetId()
        {
            return this._id;
        }

        public Miembro GetMiembroSolicitante()
        {
            return this._miembroSolicitante;
        }

        public Miembro GetMiembroSolicitado()
        {
            return this._miembroSolicitado;
        }

        public EstadoSolicitud GetEstadoSolicitud()
        {
            return this._estado;
        }

        public DateOnly GetFechaDeSolicitud()
        {
            return this._fechaDeSolicitud;
        }

        public void SetEstadoSolicitud(EstadoSolicitud estado)
        {
            this._estado = estado;
        }
        #endregion

    }
}
