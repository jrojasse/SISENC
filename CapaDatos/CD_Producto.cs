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
    public class CD_Producto
    {
        public List<Producto> Listar()
        {
            List<Producto> ProductoLista = new List<Producto>();
            try
            {
                using (SqlConnection ProductoConexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT P.ID_Producto,P.Nombre_Producto,R.ID_Ramo,R.Nombre_Ramo,T.ID_Tipo_Seguro,T.Nombre_Tipo_Seguro,");
                    sb.AppendLine("C.ID_Canal,C.Nombre_Canal,RI.ID_Riesgo,RI.Nombre_Riesgo,ES.ID_Estructura,ES.Nombre_Estructura,");
                    sb.AppendLine("F.ID_Formato,F.Nombre_Formato, P.activo FROM [dbo].[Producto] P");
                    sb.AppendLine("INNER JOIN[RAMO] R ON P.ID_RAMO = R.ID_RAMO");
                    sb.AppendLine("INNER JOIN[TIPO_SEGURO] T ON P.ID_Tipo_Seguro = T.ID_Tipo_Seguro");
                    sb.AppendLine("INNER JOIN[CANAL] C ON P.ID_Canal = C.ID_Canal");
                    sb.AppendLine("INNER JOIN[RIESGO] RI ON P.ID_Riesgo = RI.ID_Riesgo");
                    sb.AppendLine("INNER JOIN[ESTRUCTURA] ES ON P.ID_Estructura = ES.ID_Estructura");
                    sb.AppendLine("INNER JOIN[FORMATO] F ON P.ID_Formato = F.ID_Formato");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), ProductoConexion);
                    cmd.CommandType = CommandType.Text;
                    ProductoConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ProductoLista.Add(
                                new Producto()
                                {
                                    ID_Producto = (int)dr["ID_Producto"],
                                    Nombre_Producto = (string)dr["Nombre_Producto"],
                                    oRamo = new Ramo() { ID_Ramo = (int)dr["ID_Ramo"], Nombre_Ramo = (string)dr["Nombre_Ramo"] },
                                    oTipo_Seguro = new TipoSeguro() { ID_Tipo_Seguro = (string)dr["ID_Tipo_Seguro"], Nombre_Tipo_Seguro = (string)dr["Nombre_Tipo_Seguro"] },
                                    oCanal = new Canal() { ID_Canal = (int)dr["ID_Canal"], Nombre_Canal = (string)dr["Nombre_Canal"] },
                                    oRiesgo = new Riesgo() { ID_Riesgo = (int)dr["ID_Riesgo"], Nombre_Riesgo = (string)dr["Nombre_Riesgo"] },
                                    oEstructura = new Estructura() { ID_Estructura = (int)dr["ID_Estructura"], Nombre_Estructura = (string)dr["Nombre_Estructura"] },
                                    oFormato = new Formato() { ID_Formato = (int)dr["ID_Formato"], Nombre_Formato = (string)dr["Nombre_Formato"] },
                                    Activo = (bool)dr["Activo"]
                                });
                        }
                    }
                }
            }
            catch
            {
                ProductoLista = new List<Producto>();
            }
            return ProductoLista;
        }
        public int Agregar(Producto obj, out string Mensaje)
        {
            int idgenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection ProductoConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_AgregarProducto", ProductoConexion);
                    cmd.Parameters.AddWithValue("ID_Producto", obj.ID_Producto);
                    cmd.Parameters.AddWithValue("Nombre_Producto", obj.Nombre_Producto);
                    cmd.Parameters.AddWithValue("ID_Ramo", obj.oRamo.ID_Ramo);
                    cmd.Parameters.AddWithValue("ID_Tipo_Seguro", obj.oTipo_Seguro.ID_Tipo_Seguro);
                    cmd.Parameters.AddWithValue("ID_Canal", obj.oCanal.ID_Canal);
                    cmd.Parameters.AddWithValue("ID_Riesgo", obj.oRiesgo.ID_Riesgo);
                    cmd.Parameters.AddWithValue("ID_Estructura", obj.oEstructura.ID_Estructura);
                    cmd.Parameters.AddWithValue("ID_Formato", obj.oFormato.ID_Formato);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    ProductoConexion.Open();
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

        public bool Editar(Producto obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection ProductoConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarProducto", ProductoConexion);
                    cmd.Parameters.AddWithValue("ID_Producto", obj.ID_Producto);
                    cmd.Parameters.AddWithValue("Nombre_Producto", obj.Nombre_Producto);
                    cmd.Parameters.AddWithValue("ID_Ramo", obj.oRamo.ID_Ramo);
                    cmd.Parameters.AddWithValue("ID_Tipo_Seguro", obj.oTipo_Seguro.ID_Tipo_Seguro);
                    cmd.Parameters.AddWithValue("ID_Canal", obj.oCanal.ID_Canal);
                    cmd.Parameters.AddWithValue("ID_Riesgo", obj.oRiesgo.ID_Riesgo);
                    cmd.Parameters.AddWithValue("ID_Estructura", obj.oEstructura.ID_Estructura);
                    cmd.Parameters.AddWithValue("ID_Formato", obj.oFormato.ID_Formato);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    ProductoConexion.Open();
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
                using (SqlConnection ProductoConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarProducto", ProductoConexion);
                    cmd.Parameters.AddWithValue("ID_Producto", id);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    ProductoConexion.Open();
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
