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
    public class CD_TipoSeguro
    {
        public List<TipoSeguro> Listar()
        {
            List<TipoSeguro> TipoSeguroLista = new List<TipoSeguro>();
            try
            {
                using (SqlConnection TipoSeguroConexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT * FROM [dbo].[Tipo_Seguro]");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), TipoSeguroConexion);
                    cmd.CommandType = CommandType.Text;
                    TipoSeguroConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            TipoSeguroLista.Add(
                                new TipoSeguro()
                                {
                                    ID_Tipo_Seguro = (string)dr["ID_Tipo_Seguro"],
                                    Nombre_Tipo_Seguro = (string)dr["Nombre_Tipo_Seguro"],
                                    Activo = (bool)dr["Activo"]
                                });
                        }
                    }
                }
            }
            catch
            {
                TipoSeguroLista = new List<TipoSeguro>();
            }
            return TipoSeguroLista;
        }
        public string Agregar(TipoSeguro obj, out string Mensaje)
        {
            string idgenerado = string.Empty;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection TipoSeguroConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_AgregarTipoSeguro", TipoSeguroConexion);
                    cmd.Parameters.AddWithValue("ID_Tipo_Seguro", obj.ID_Tipo_Seguro);
                    cmd.Parameters.AddWithValue("Nombre_Tipo_Seguro", obj.Nombre_Tipo_Seguro);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    TipoSeguroConexion.Open();
                    cmd.ExecuteNonQuery();
                    idgenerado = cmd.Parameters["Resultado"].Value.ToString();
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idgenerado = string.Empty;
                Mensaje = ex.Message;
            }
            return idgenerado;
        }

        public bool Editar(TipoSeguro obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection TipoSeguroConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarTipoSeguro", TipoSeguroConexion);
                    cmd.Parameters.AddWithValue("ID_Tipo_Seguro", obj.ID_Tipo_Seguro);
                    cmd.Parameters.AddWithValue("Nombre_Tipo_Seguro", obj.Nombre_Tipo_Seguro);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    TipoSeguroConexion.Open();
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
        public bool Eliminar(string id, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection TipoSeguroConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarTipoSeguro", TipoSeguroConexion);
                    cmd.Parameters.AddWithValue("ID_Tipo_Seguro", id);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    TipoSeguroConexion.Open();
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
