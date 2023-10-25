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
    public class CD_Formato
    {
        public List<Formato> Listar()
        {
            List<Formato> FormatoLista = new List<Formato>();
            try
            {
                using (SqlConnection FormatoConexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT * FROM [dbo].[FORMATO]");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), FormatoConexion);
                    cmd.CommandType = CommandType.Text;
                    FormatoConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            FormatoLista.Add(
                                new Formato()
                                {
                                    ID_Formato = (int)dr["ID_Formato"],
                                    Nombre_Formato = (string)dr["Nombre_Formato"],
                                    Activo = (bool)dr["Activo"]
                                });
                        }
                    }
                }
            }
            catch
            {
                FormatoLista = new List<Formato>();
            }
            return FormatoLista;
        }
        public int Agregar(Formato obj, out string Mensaje)
        {
            int idgenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection FormatoConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_AgregarFormato", FormatoConexion);
                    cmd.Parameters.AddWithValue("Nombre_Formato", obj.Nombre_Formato);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    FormatoConexion.Open();
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

        public bool Editar(Formato obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection FormatoConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarFormato", FormatoConexion);
                    cmd.Parameters.AddWithValue("ID_Formato", obj.ID_Formato);
                    cmd.Parameters.AddWithValue("Nombre_Formato", obj.Nombre_Formato);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    FormatoConexion.Open();
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
                using (SqlConnection FormatoConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarFormato", FormatoConexion);
                    cmd.Parameters.AddWithValue("ID_Formato", id);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    FormatoConexion.Open();
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
