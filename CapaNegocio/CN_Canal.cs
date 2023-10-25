using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Canal
    {
        private CD_Canal objCapaDato = new CD_Canal();
        public List<Canal> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Agregar(Canal obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.Nombre_Canal) || string.IsNullOrWhiteSpace(obj.Nombre_Canal))
            {
                Mensaje = "El nombre del Canal no puede ser vacio";
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

        public bool Editar(Canal obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.Nombre_Canal) || string.IsNullOrWhiteSpace(obj.Nombre_Canal))
            {
                Mensaje = "El nombre del Canal no puede ser vacio";
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
