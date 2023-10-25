using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ComprobantesCPE
    {
        public string Moneda { get; set; }
        public string Tipo_documento_identidad { get; set; }
        public string Numero_documento_Identidad_cliente { get; set; }
        public string Nombre_Razon_Social_Cliente { get; set; }
        public string Apellido_Paterno_Cliente { get; set; }
        public string Apellido_Materno_Cliente { get; set; }
        public string Fecha_Nacimiento_Cliente { get; set; }
        public string Mail_Cliente { get; set; }
        public string Direccion_Cliente { get; set; }
        public string Departamento_Cliente { get; set; }
        public string Provincia_Cliente { get; set; }
        public string Distrito_Cliente { get; set; }
        public string Ubigeo_Cliente { get; set; }
        public string Tipo_Documento_Identidad_Asegurado_Titular { get; set; }
        public string Numero_Documento_Identidad_Asegurado_Titular { get; set; }
        public string Nombres_Razon_Social_Asegurado_Titular { get; set; }
        public string Apellido_Paterno_Asegurado_Titular { get; set; }
        public string Apellido_Materno_Asegurado_Titular { get; set; }
        public string Fecha_Nacimiento_Asegurado_Titular { get; set; }
        public string Mail_Asegurado_Titular { get; set; }
        public string Direccion_Asegurado_Titular { get; set; }
        public string Departamento_Asegurado { get; set; }
        public string Provincia_Asegurado { get; set; }
        public string Distrito_Asegurado { get; set; }
        public string Ubigeo_Asegurado { get; set; }
        public string Fecha_Operacion { get; set; }
        public string Tipo_Asiento { get; set; }
        public string Prima_Facturar { get; set; }
        public string Numero_Poliza { get; set; }
        public string Inicio_Vigencia { get; set; }
        public string Fin_Cobertura { get; set; }
        public int ID_Producto { get; set; }
        public int Codigo_Ramo { get; set; }
        public int Canal_Venta { get; set; }
        public string Monto_Comision_Recaudacion { get; set; }
        public string Monto_Bruto_Comision_Comercializacion { get; set; }
        public string IGV_Comision_Comercializacion { get; set; }
        public string Monto_Bruto_Comision_Asistencias { get; set; }
        public string IGV_Comision_Asistencias { get; set; }
        public string Monto_Bruto_Comision_Incentivos { get; set; }
        public string IGV_Comision_Incentivos { get; set; }
        public string Monto_Comision_Corredor { get; set; }
        public string IGV_Corredor { get; set; }
        public string CODIGO_RODUCTO { get; set; }
        public string TipoCredito { get; set; }
        public string Nombre_Producto { get; set; }
        public string Mes { get; set; }
    }
}
