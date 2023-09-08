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
        //private List<Administrador> _administradores;
        //private List<Publicacion> _publicaciones;

        #endregion

        #region Constructor
        public Sistema() 
        { 
            this._miembros = new List<Miembro>();
        }
        #endregion

        #region GET Y SET

        public List<Miembro> GetMiembros()
        {
            return this._miembros;
        }

        #endregion

        #region Metodos
        public void AgregarMiembro(Miembro miembro)
        {
            //Falta agregar Validacion
            this._miembros.Add(miembro);
        }
        #endregion
    }
}
