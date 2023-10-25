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
    public class CD_Absa
    {
        public List<Absa> Listar()
        {
            List<Absa> AbsaLista = new List<Absa>();
            string Mensaje = string.Empty;
            try
            {
                using (SqlConnection AbsaConexion = new SqlConnection(Conexion.cn))
                {
                    
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT [ID_ABSA_HISTORICO], [FechaOperacion],[PrimerApellido] ,[SegundoApellido] ,[PrimerNombre] ,[SegundoNombre] ,[TipoTitular] ,[IdTitular] ,[FrecuenciaPago] ,[InicioVigencia] ,[FinVigencia] ,[Producto] ,[Prima] ,[ValorAsegurado] ,[NumeroCredito] ,[TipoCredito] ,[NombreClienteTitular] ,[Activo] FROM [dbo].[ABSA_HISTORICO]");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), AbsaConexion);
                    cmd.CommandType = CommandType.Text;
                    AbsaConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            AbsaLista.Add(
                                new Absa()
                                {
                                    ID_ABSA_HISTORICO = (int)dr["ID_ABSA_HISTORICO"],
                                    FechaOperacion = Convert.ToString(dr["FechaOperacion"]),
                                    PrimerApellido = Convert.ToString(dr["PrimerApellido"]),
                                    SegundoApellido = Convert.ToString(dr["SegundoApellido"]),
                                    PrimerNombre = Convert.ToString(dr["PrimerNombre"]),
                                    SegundoNombre = Convert.ToString(dr["SegundoNombre"]),
                                    TipoTitular = Convert.ToString(dr["TipoTitular"]),
                                    IdTitular = Convert.ToString(dr["IdTitular"]),
                                    FrecuenciaPago = Convert.ToString(dr["FrecuenciaPago"]),
                                    InicioVigencia = Convert.ToString(dr["InicioVigencia"]),
                                    FinVigencia = Convert.ToString(dr["FinVigencia"]),
                                    Producto = Convert.ToString(dr["Producto"]),
                                    Prima = Convert.ToString(dr["Prima"]),
                                    ValorAsegurado = Convert.ToString(dr["ValorAsegurado"]),
                                    NumeroCredito = Convert.ToString(dr["NumeroCredito"]),
                                    TipoCredito = Convert.ToString(dr["TipoCredito"]),
                                    NombreClienteTitular = Convert.ToString(dr["NombreClienteTitular"]),
                                    Activo = (bool)dr["Activo"]
                                });
                        }
                    }
                }
            }
            catch
            {
                AbsaLista = new List<Absa>();
            }
            return AbsaLista;
        }
        public int Agregar(Producto obj, string Year, string Mes,out string Mensaje)
        {
            int idgenerado = 0;
            Mensaje = string.Empty;
            string Periodo = Year + "-" + Mes;

            try
            {
                using (SqlConnection AbsaConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_CargaTramasAbsa", AbsaConexion);
                    cmd.Parameters.AddWithValue("Producto", obj.ID_Producto);
                    cmd.Parameters.AddWithValue("Periodo", Periodo);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    AbsaConexion.Open();
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
