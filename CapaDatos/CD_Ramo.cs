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
    public class CD_Ramo
    {
        public List<Ramo> Listar()
        {
            List<Ramo> RamoLista = new List<Ramo>();
            try
            {
                using (SqlConnection RamoConexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT * FROM [dbo].[Ramo]");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), RamoConexion);
                    cmd.CommandType = CommandType.Text;
                    RamoConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            RamoLista.Add(
                                new Ramo()
                                {
                                    ID_Ramo = (int)dr["ID_Ramo"],
                                    Nombre_Ramo = (string)dr["Nombre_Ramo"],
                                    Activo = (bool)dr["Activo"]
                                });
                        }
                    }
                }
            }
            catch
            {
                RamoLista = new List<Ramo>();
            }
            return RamoLista;
        }
        public int Agregar(Ramo obj, out string Mensaje)
        {
            int idgenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection RamoConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_AgregarRamo", RamoConexion);
                    cmd.Parameters.AddWithValue("ID_Ramo", obj.ID_Ramo);
                    cmd.Parameters.AddWithValue("Nombre_Ramo", obj.Nombre_Ramo);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    RamoConexion.Open();
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

        public bool Editar(Ramo obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection RamoConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarRamo", RamoConexion);
                    cmd.Parameters.AddWithValue("ID_Ramo", obj.ID_Ramo);
                    cmd.Parameters.AddWithValue("Nombre_Ramo", obj.Nombre_Ramo);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    RamoConexion.Open();
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
                using (SqlConnection RamoConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarRamo", RamoConexion);
                    cmd.Parameters.AddWithValue("ID_Ramo", id);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    RamoConexion.Open();
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
