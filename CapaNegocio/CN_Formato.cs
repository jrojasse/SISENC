using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Formato
    {
        private CD_Formato objCapaDato = new CD_Formato();
        public List<Formato> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Agregar(Formato obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.Nombre_Formato) || string.IsNullOrWhiteSpace(obj.Nombre_Formato))
            {
                Mensaje = "El nombre del Formato no puede ser vacio";
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

        public bool Editar(Formato obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.Nombre_Formato) || string.IsNullOrWhiteSpace(obj.Nombre_Formato))
            {
                Mensaje = "El nombre del Formato no puede ser vacio";
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
