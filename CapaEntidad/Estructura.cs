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

    public class Estructura
    {
        public int ID_Estructura { get; set; }
        public string Nombre_Estructura { get; set; }
        public bool Activo { get; set; }
    }
}