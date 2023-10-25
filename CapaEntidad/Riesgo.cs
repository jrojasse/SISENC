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
    public class Riesgo
    {
        public int ID_Riesgo { get; set; }
        public string Nombre_Riesgo { get; set; }
        public bool Activo { get; set; }
    }

}