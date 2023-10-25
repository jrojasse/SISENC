using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Riesgo
    {
        private CD_Riesgo objCapaDato = new CD_Riesgo();
        public List<Riesgo> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Agregar(Riesgo obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.Nombre_Riesgo) || string.IsNullOrWhiteSpace(obj.Nombre_Riesgo))
            {
                Mensaje = "El nombre del Riesgo no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Agregar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool Editar(Riesgo obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.Nombre_Riesgo) || string.IsNullOrWhiteSpace(obj.Nombre_Riesgo))
            {
                Mensaje = "El nombre del Riesgo no puede ser vacio";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }
        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}
