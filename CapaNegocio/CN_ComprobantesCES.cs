using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_ComprobantesCES
    {
        private CD_ComprobantesCES objCapaDato = new CD_ComprobantesCES();
        public List<ComprobantesCES> Listar()
        {
            return objCapaDato.Listar();
        }
        public int Exportar(Producto obj, string Year, string Mes, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.ID_Producto == 0)
            {
                Mensaje = "El nombre del producto no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(Year) || string.IsNullOrWhiteSpace(Year))
            {
                Mensaje = "Debe seleccionar un año";
            }
            else if (string.IsNullOrEmpty(Mes) || string.IsNullOrWhiteSpace(Mes))
            {
                Mensaje = "Debe seleccionar un mes";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Exportar(obj, Year, Mes, out Mensaje);
            }
            else
            {
                return 0;
            }
        }
    }
}
