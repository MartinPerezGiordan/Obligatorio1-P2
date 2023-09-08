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
        private static int _ultimoId;
        private int _id;
        private Miembro _miembroSolicitante;
        private Miembro _miembroSolicitado;
        private EstadoSolicitud _estado;
        private DateTime _fechaDeSolicitud;
        #endregion

    }
}
