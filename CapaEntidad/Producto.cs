using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;


namespace CapaEntidad
{
    public class Producto
    {
        public int ID_Producto { get; set; }
        public Ramo oRamo { get; set; }
        public TipoSeguro oTipo_Seguro { get; set; }
        public Canal oCanal { get; set; }
        public Riesgo oRiesgo { get; set; }
        public Estructura oEstructura { get; set; }
        public Formato oFormato { get; set; }
        public string Nombre_Producto { get; set; }
        public bool Activo { get; set; }

    }

}