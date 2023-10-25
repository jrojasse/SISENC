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
    public class Ramo
    {
        public int ID_Ramo { get; set; }
        public string Nombre_Ramo { get; set; }
        public bool Activo { get; set; }
    }

}
