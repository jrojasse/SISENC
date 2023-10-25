using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class CN_TipoSeguro
    {
        private CD_TipoSeguro objCapaDato = new CD_TipoSeguro();
        public List<TipoSeguro> Listar()
        {
            return objCapaDato.Listar();
        }

        public string Agregar(TipoSeguro obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.ID_Tipo_Seguro) || string.IsNullOrWhiteSpace(obj.ID_Tipo_Seguro))
            {
                Mensaje = "El código del Tipo de Seguro no puede ser vacio";
            }
            if (string.IsNullOrEmpty(obj.Nombre_Tipo_Seguro) || string.IsNullOrWhiteSpace(obj.Nombre_Tipo_Seguro))
            {
                Mensaje = "El nombre del Tipo de Seguro no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Agregar(obj, out Mensaje);
            }
            else
            {
                return string.Empty;
            }
        }

        public bool Editar(TipoSeguro obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.ID_Tipo_Seguro) || string.IsNullOrWhiteSpace(obj.ID_Tipo_Seguro))
            {
                Mensaje = "El código del Tipo de Seguro no puede ser vacio";
            }
            if (string.IsNullOrEmpty(obj.Nombre_Tipo_Seguro) || string.IsNullOrWhiteSpace(obj.Nombre_Tipo_Seguro))
            {
                Mensaje = "El nombre del Tipo de Seguro no puede ser vacio";
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
        public bool Eliminar(string id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}
