using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_ComprobantesCPE
    {
        public List<ComprobantesCPE> Listar()
        {
            List<ComprobantesCPE> ComprobantesCPELista = new List<ComprobantesCPE>();
            string Mensaje = string.Empty;
            try
            {
                using (SqlConnection ComprobantesCPEConexion = new SqlConnection(Conexion.cn))
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT [Fecha de Operacion],[Tipo Documento Identidad Asegurado Titular] ,[Número Documento Identidad Asegurado Titular] ,[Nombres / Razon Social Asegurado Titular] ,[Apellido Paterno Asegurado Titular] ,[Apellido Materno Asegurado Titular] ,[Ubigeo del Cliente] ,[Prima a Facturar] ,[Número de Póliza] ,[Inicio Vigencia] ,[Fin  Cobertura (openItem)] ,[Nombre_Producto] ,[Mes] FROM[dbo].[COMPROBANTES_CES]");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), ComprobantesCPEConexion);
                    cmd.CommandType = CommandType.Text;
                    ComprobantesCPEConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ComprobantesCPELista.Add(
                                new ComprobantesCPE()
                                {
                                    Fecha_Operacion = Convert.ToString(dr["Fecha de Operacion"]),
                                    Tipo_Documento_Identidad_Asegurado_Titular = Convert.ToString(dr["Tipo Documento Identidad Asegurado Titular"]),
                                    Numero_Documento_Identidad_Asegurado_Titular = Convert.ToString(dr["Número Documento Identidad Asegurado Titular"]),
                                    Nombres_Razon_Social_Asegurado_Titular = Convert.ToString(dr["Nombres / Razon Social Asegurado Titular"]),
                                    Apellido_Paterno_Asegurado_Titular = Convert.ToString(dr["Apellido Paterno Asegurado Titular"]),
                                    Apellido_Materno_Asegurado_Titular = Convert.ToString(dr["Apellido Materno Asegurado Titular"]),
                                    Ubigeo_Cliente = Convert.ToString(dr["Ubigeo del Cliente"]),
                                    Prima_Facturar = Convert.ToString(dr["Prima a Facturar"]),
                                    Numero_Poliza = Convert.ToString(dr["Número de Póliza"]),
                                    Inicio_Vigencia = Convert.ToString(dr["Inicio Vigencia"]),
                                    Fin_Cobertura = Convert.ToString(dr["Fin  Cobertura (openItem)"]),
                                    Nombre_Producto = Convert.ToString(dr["Nombre_Producto"]),
                                    Mes = Convert.ToString(dr["Mes"])
                                });
                        }
                    }
                }
            }
            catch
            {
                ComprobantesCPELista = new List<ComprobantesCPE>();
            }
            return ComprobantesCPELista;
        }
        public int Exportar(Producto obj, string Year, string Mes, out string Mensaje)
        {
            int idgenerado = 0;
            Mensaje = string.Empty;
            string Periodo = Year + "-" + Mes;

            try
            {
                using (SqlConnection ComprobantesCPEConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_ExportarCPE", ComprobantesCPEConexion);
                    cmd.Parameters.AddWithValue("ID_Producto", obj.ID_Producto);
                    cmd.Parameters.AddWithValue("Periodo", Periodo);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    ComprobantesCPEConexion.Open();
                    cmd.ExecuteNonQuery();
                    idgenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idgenerado = 0;
                Mensaje = ex.Message;
            }
            return idgenerado;
        }
    }
}
