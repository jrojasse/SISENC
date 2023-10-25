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
    public class CD_Riesgo
    {
        public List<Riesgo> Listar()
        {
            List<Riesgo> RiesgoLista = new List<Riesgo>();
            try
            {
                using (SqlConnection RiesgoConexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT * FROM [dbo].[Riesgo]");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), RiesgoConexion);
                    cmd.CommandType = CommandType.Text;
                    RiesgoConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            RiesgoLista.Add(
                                new Riesgo()
                                {
                                    ID_Riesgo = (int)dr["ID_Riesgo"],
                                    Nombre_Riesgo = (string)dr["Nombre_Riesgo"],
                                    Activo = (bool)dr["Activo"]
                                });
                        }
                    }
                }
            }
            catch
            {
                RiesgoLista = new List<Riesgo>();
            }
            return RiesgoLista;
        }
        public int Agregar(Riesgo obj, out string Mensaje)
        {
            int idgenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection RiesgoConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_AgregarRiesgo", RiesgoConexion);
                    cmd.Parameters.AddWithValue("ID_Riesgo", obj.ID_Riesgo);
                    cmd.Parameters.AddWithValue("Nombre_Riesgo", obj.Nombre_Riesgo);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    RiesgoConexion.Open();
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

        public bool Editar(Riesgo obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection RiesgoConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarRiesgo", RiesgoConexion);
                    cmd.Parameters.AddWithValue("ID_Riesgo", obj.ID_Riesgo);
                    cmd.Parameters.AddWithValue("Nombre_Riesgo", obj.Nombre_Riesgo);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    RiesgoConexion.Open();
                    cmd.ExecuteNonQuery();
                    Resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
                Mensaje = ex.Message;
            }
            return Resultado;
        }
        public bool Eliminar(int id, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection RiesgoConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarRiesgo", RiesgoConexion);
                    cmd.Parameters.AddWithValue("ID_Riesgo", id);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    RiesgoConexion.Open();
                    cmd.ExecuteNonQuery();
                    Resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
                Mensaje = ex.Message;
            }
            return Resultado;
        }
    }
}
