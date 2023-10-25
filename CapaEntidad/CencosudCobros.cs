using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CencosudCobros
    {
        public int ID_CENCOSUD_COBROS_HISTORICO { get; set; }
        public CencosudAltas oCencosudAltas { get; set; }
        public string NRO_SOLICITUD { get; set; }
        public string FECHA_PAGO { get; set; }
        public string NUMERO_OPERACION { get; set; }
        public string IMPORTE_PAGADO { get; set; }
        public string CODIGO_MONEDA_IMPORTE_PAGADO { get; set; }
        public string FECHA_VENCIMIENTO_CUOTA { get; set; }
        public string FECHA_INICIO_COBERTURA { get; set; }
        public string FECHA_FIN_COBERTURA { get; set; }
        public string CODIGO_MEDIO_PAGO { get; set; }
        public string PRIMA_CUOTA { get; set; }
        public string CODIGO_MONEDA_PRIMA_CUOTA { get; set; }
        public int ID_Trama { get; set; }
        public DateTime Fecha_Carga { get; set; }
        public bool Activo { get; set; }

    }
}
