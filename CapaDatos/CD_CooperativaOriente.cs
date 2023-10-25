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
    public class CD_CooperativaOriente
    {
        //public List<CooperativaOriente> Listar()
        //{
        //    List<CooperativaOriente> CooperativaOrienteLista = new List<CooperativaOriente>();
        //    try
        //    {
        //        using (SqlConnection CooperativaOrienteConexion = new SqlConnection(Conexion.cn))
        //        {
        //            StringBuilder sb = new StringBuilder();
        //            sb.AppendLine("SELECT [ID_CooperativaOriente_HISTORICO] ,[FechaOperacion] ,[Operacion] ,[TipoRegistro] ,[PrimerApellido] ,[SegundoApellido] ,[PrimerNombre] ,[SegundoNombre] ,[TipoTitular] ,[IdTitular] ,[FechaNacimiento] ,[GeneroTitular] ,[EstadoCivil] ,[DireccionTitular],[Activo] FROM [dbo].[CooperativaOriente_HISTORICO]");
        //            SqlCommand cmd = new SqlCommand(sb.ToString(), CooperativaOrienteConexion);
        //            cmd.CommandType = CommandType.Text;
        //            CooperativaOrienteConexion.Open();
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    CooperativaOrienteLista.Add(
        //                        new CooperativaOriente()
        //                        {
        //                            ID_CooperativaOriente_HISTORICO = (int)dr["ID_CooperativaOriente_HISTORICO"],
        //                            FechaOperacion = (string)dr["FechaOperacion"],
        //                            Operacion = (string)dr["Operacion"],
        //                            TipoRegistro = (string)dr["TipoRegistro"],
        //                            PrimerApellido = (string)dr["PrimerApellido"],
        //                            SegundoApellido = (string)dr["SegundoApellido"],
        //                            PrimerNombre = (string)dr["PrimerNombre"],
        //                            SegundoNombre = (string)dr["SegundoNombre"],
        //                            TipoTitular = (string)dr["TipoTitular"],
        //                            IdTitular = (string)dr["IdTitular"],
        //                            FechaNacimiento = (string)dr["FechaNacimiento"],
        //                            GeneroTitular = (string)dr["GeneroTitular"],
        //                            EstadoCivil = (string)dr["EstadoCivil"],
        //                            DireccionTitular = (string)dr["DireccionTitular"],
        //                            Activo = (bool)dr["Activo"]
        //                        });
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        CooperativaOrienteLista = new List<CooperativaOriente>();
        //    }
        //    return CooperativaOrienteLista;
        //}
        public int Agregar(Producto obj, string Year, string Mes, out string Mensaje)
        {
            int idgenerado = 0;
            Mensaje = string.Empty;
            string Periodo = Year + "-" + Mes;

            try
            {
                using (SqlConnection CooperativaOrienteConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_CargaTramasCooperativaOriente", CooperativaOrienteConexion);
                    cmd.Parameters.AddWithValue("Producto", obj.ID_Producto);
                    cmd.Parameters.AddWithValue("Periodo", Periodo);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    CooperativaOrienteConexion.Open();
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
