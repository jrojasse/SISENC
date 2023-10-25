using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Producto
    {
        private CD_Producto objCapaDato = new CD_Producto();
        public List<Producto> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Agregar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.ID_Producto == 0)
            {
                Mensaje = "El código del Producto no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Nombre_Producto) || string.IsNullOrWhiteSpace(obj.Nombre_Producto))
            {
                Mensaje = "El nombre del Producto no puede ser vacio";
            }
            else if (obj.oRamo.ID_Ramo == 0)
            {
                Mensaje = "Debe seleccionar un Ramo";
            }
            else if (string.IsNullOrEmpty(obj.oTipo_Seguro.ID_Tipo_Seguro) || string.IsNullOrWhiteSpace(obj.oTipo_Seguro.ID_Tipo_Seguro))
            {
                Mensaje = "Debe seleccionar un Tipo de Seguro";
            }
            else if (obj.oCanal.ID_Canal == 0)
            {
                Mensaje = "Debe seleccionar un Canal";
            }
            else if (obj.oRiesgo.ID_Riesgo == 0)
            {
                Mensaje = "Debe seleccionar un Riesgo";
            }
            else if (obj.oEstructura.ID_Estructura == 0)
            {
                Mensaje = "Debe seleccionar una Estructura";
            }
            else if (obj.oFormato.ID_Formato == 0)
            {
                Mensaje = "Debe seleccionar un Formato";
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

        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.ID_Producto == 0)
            {
                Mensaje = "El código del Producto no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Nombre_Producto) || string.IsNullOrWhiteSpace(obj.Nombre_Producto))
            {
                Mensaje = "El nombre del Producto no puede ser vacio";
            }
            else if (obj.oRamo.ID_Ramo == 0)
            {
                Mensaje = "Debe seleccionar un Ramo";
            }
            else if (string.IsNullOrEmpty(obj.oTipo_Seguro.ID_Tipo_Seguro) || string.IsNullOrWhiteSpace(obj.oTipo_Seguro.ID_Tipo_Seguro))
            {
                Mensaje = "Debe seleccionar un Tipo de Seguro";
            }
            else if (obj.oCanal.ID_Canal == 0)
            {
                Mensaje = "Debe seleccionar un Canal";
            }
            else if (obj.oRiesgo.ID_Riesgo == 0)
            {
                Mensaje = "Debe seleccionar un Riesgo";
            }
            else if (obj.oEstructura.ID_Estructura == 0)
            {
                Mensaje = "Debe seleccionar una Estructura";
            }
            else if (obj.oFormato.ID_Formato == 0)
            {
                Mensaje = "Debe seleccionar un Formato";
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
