using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Ramo
    {
        private CD_Ramo objCapaDato = new CD_Ramo();
        public List<Ramo> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Agregar(Ramo obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.Nombre_Ramo) || string.IsNullOrWhiteSpace(obj.Nombre_Ramo))
            {
                Mensaje = "El nombre del Ramo no puede ser vacio";
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

        public bool Editar(Ramo obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.Nombre_Ramo) || string.IsNullOrWhiteSpace(obj.Nombre_Ramo))
            {
                Mensaje = "El nombre del Ramo no puede ser vacio";
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
