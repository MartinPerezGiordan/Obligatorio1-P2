using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Reaccion
    {
        public bool Like { get; set; }
        public int IdMiembro { get; set; }

    public Reaccion(bool like, int idMiembro) 
        { 
            this.Like = like;
            this.IdMiembro = idMiembro;
        }


    }
}
