using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Estructura
    {
        private CD_Estructura objCapaDato = new CD_Estructura();
        public List<Estructura> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Agregar(Estructura obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if(string.IsNullOrEmpty(obj.Nombre_Estructura) || string.IsNullOrWhiteSpace(obj.Nombre_Estructura))
            {
                Mensaje = "El nombre de la estructura no puede ser vacio";
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

        public bool Editar(Estructura obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.Nombre_Estructura) || string.IsNullOrWhiteSpace(obj.Nombre_Estructura))
            {
                Mensaje = "El nombre de la estructura no puede ser vacio";
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
