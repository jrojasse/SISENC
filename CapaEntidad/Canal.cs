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
    public class Canal
    {
        public int ID_Canal { get; set; }
        public string Nombre_Canal { get; set; }
        public bool Activo { get; set; }
    }
}