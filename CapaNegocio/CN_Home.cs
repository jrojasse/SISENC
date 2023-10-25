using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Home
    {
        private CD_Home objCapaDato = new CD_Home();
        public List<V_ProductoUltimoPeriodo> Listar()
        {
            return objCapaDato.Listar();
        }
    }
}
