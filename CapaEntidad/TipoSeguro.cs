using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;

namespace CapaEntidad
{
    public class TipoSeguro
    {
        public string ID_Tipo_Seguro { get; set; }
        public string Nombre_Tipo_Seguro { get; set; }
        public bool Activo { get; set; }
    }
    
}