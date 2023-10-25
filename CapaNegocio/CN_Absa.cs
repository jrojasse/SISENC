using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Absa
    {
        private CD_Absa objCapaDato = new CD_Absa();
        public List<Absa> Listar()
        {
            return objCapaDato.Listar();
        }
        public int Agregar(Producto obj, string Year, string Mes, out string Mensaje)
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
                return objCapaDato.Agregar(obj, Year, Mes, out Mensaje);
            }
            else
            {
                return 0;
            }
        }
    }
}
