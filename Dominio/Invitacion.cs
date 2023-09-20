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
        private int _idMiembroSolicitante;
        private int _idMiembroSolicitado;
        private EstadoSolicitud _estado;
        private DateTime _fechaDeSolicitud;

        #endregion

        #region Constructor

        public Invitacion(int idMiembroSolicitante, int idMiembroSolicitado, DateTime fechaDeSolicitud)
        {
            this._id = s_ultimoId++;
            this._idMiembroSolicitante = idMiembroSolicitante;
            this._idMiembroSolicitado = idMiembroSolicitado;
            this._estado = EstadoSolicitud.PENDIENTE_APROBACION;
            this._fechaDeSolicitud = fechaDeSolicitud;
        }


        #endregion

        #region Get Y Set

        public int GetId()
        {
            return this._id;
        }

        public int GetIdMiembroSolicitante()
        {
            return this._idMiembroSolicitante;
        }

        public int GetIdMiembroSolicitado()
        {
            return this._idMiembroSolicitado;
        }

        public EstadoSolicitud GetEstadoSolicitud()
        {
            return this._estado;
        }

        public DateTime GetFechaDeSolicitud()
        {
            return this._fechaDeSolicitud;
        }

        public void SetEstadoSolicitud(EstadoSolicitud estado)
        {
            this._estado = estado;
        }
        #endregion

        public override string ToString()
        {
            return $"Id: {this.GetId()} {Environment.NewLine}Solicitante: {this.GetIdMiembroSolicitante()} {Environment.NewLine}Solicitado: {this.GetIdMiembroSolicitado()} {Environment.NewLine}Estado: {this.GetEstadoSolicitud()} {Environment.NewLine}";
        }
    }
}
