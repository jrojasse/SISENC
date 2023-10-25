using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CooperativaOriente
    {
        public int id_CooperativaOriente_HISTORICO { get; set; }
        public string fecha_operacion { get; set; }
        public string operacion { get; set; }
        public string tipo_registro { get; set; }
        public string producto { get; set; }
        public string Sub_producto { get; set; }
        public string inicio_vigencia { get; set; }
        public string fin_vigencia { get; set; }
        public string frecuencia_pago { get; set; }
        public string forma_pago { get; set; }
        public string prima { get; set; }
        public string valor_asegurado { get; set; }
        public string moneda { get; set; }
        public string numero_credito { get; set; }
        public string Tasa { get; set; }
        public string Fecha_Desembolso_Credito { get; set; }
        public string Fecha_Vencimiento_Credito { get; set; }
        public string tipo_agente { get; set; }
        public string id_agente { get; set; }
        public string sector { get; set; }
        public string tipo_id_ejecutivo { get; set; }
        public string id_ejecutivo { get; set; }
        public string tipo_cuenta { get; set; }
        public string Situacion_contable_credito { get; set; }
        public string Tipo_Seguro { get; set; }
        public string Codigo_Tipo_Descripcion_producto { get; set; }
        public string Flag_Periodo_Gracia { get; set; }
        public string Dias_Periodo_Gracia { get; set; }
        public string Nro_Tarjeta_Credito { get; set; }
        public string Descripcion_Convenio { get; set; }
        public string Descripcion_BIN_Tarjeta_Credito { get; set; }
        public string Canal_Venta { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string tipo_titular { get; set; }
        public string id_titular { get; set; }
        public string fecha_nacimiento { get; set; }
        public string genero_titular { get; set; }
        public string estado_civil { get; set; }
        public string direccion_titular { get; set; }
        public string departamento_titular { get; set; }
        public string provincia_titular { get; set; }
        public string distrito_titular { get; set; }
        public string telefono_titular { get; set; }
        public string Celular1_Titular { get; set; }
        public string Celular2_Titular { get; set; }
        public string Oficina1_Titular { get; set; }
        public string Correo_Electronico_Titular { get; set; }
        public string Ocupacion_titular { get; set; }
        public string Tipo_Credito { get; set; }
        public string primer_apellido_mancomuno { get; set; }
        public string segundo_apellido_mancomuno { get; set; }
        public string primer_nombre_mancomuno { get; set; }
        public string segundo_nombre_mancomuno { get; set; }
        public string tipo_mancomuno { get; set; }
        public string id_mancomuno { get; set; }
        public string fecha_nacimiento_mancomuno { get; set; }
        public string genero_mancomuno { get; set; }
        public string Direccion_mancomuno { get; set; }
        public string Departamento_mancomuno { get; set; }
        public string Provincia_mancomuno { get; set; }
        public string Distrito_mancomuno { get; set; }
        public string estado_civil_mancomuno { get; set; }
        public string ocupacion_mancomuno { get; set; }
        public string Telefono_mancomuno { get; set; }
        public string Celular1_mancomuno { get; set; }
        public string Trama { get; set; }
        public DateTime Fecha_Carga { get; set; }
        public bool Activo { get; set; }

    }
}
