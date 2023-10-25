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
    public class CD_Home
    {
        public List<V_ProductoUltimoPeriodo> Listar()
        {
            List<V_ProductoUltimoPeriodo> V_ProductoUltimoPeriodoLista = new List<V_ProductoUltimoPeriodo>();
            try
            {
                using (SqlConnection V_ProductoUltimoPeriodoConexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT P.ID_Producto,P.Nombre_Producto,VP.Periodo FROM [dbo].[V_ProductoUltimoPeriodo] VP");
                    sb.AppendLine("INNER JOIN [dbo].[PRODUCTO] P ON VP.ID_Producto = P.ID_Producto");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), V_ProductoUltimoPeriodoConexion);
                    cmd.CommandType = CommandType.Text;
                    V_ProductoUltimoPeriodoConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            V_ProductoUltimoPeriodoLista.Add(
                                new V_ProductoUltimoPeriodo()
                                {
                                    oProducto = new Producto() { ID_Producto = (int)dr["ID_Producto"], Nombre_Producto = (string)dr["Nombre_Producto"] },
                                    Periodo = Convert.ToString(dr["Periodo"])
                                });
                        }
                    }
                }
            }
            catch
            {
                V_ProductoUltimoPeriodoLista = new List<V_ProductoUltimoPeriodo>();
            }
            return V_ProductoUltimoPeriodoLista;
        }
    }
}
