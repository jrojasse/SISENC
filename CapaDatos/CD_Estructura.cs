using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;
using CRE.INT.Log_F472;
using System.Net;

namespace CapaDatos
{
    public class CD_Estructura
    {
        private LogInfoS _logInfoS;

        public CD_Estructura()
        {
            _logInfoS = new LogInfoS();
            _logInfoS.NameClass = this.ToString();
            _logInfoS.Origen = "SISENC";

            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        _logInfoS.IpAdress = ip.ToString();
                    }
                }
            }
            catch
            {
                _logInfoS.IpAdress = "XX.XX.XX.22";
            }
        }
        public List<Estructura> Listar()
        {
            List<Estructura> EstructuraLista = new List<Estructura>();
            try
            {
               
                using (SqlConnection EstructuraConexion = new SqlConnection(Conexion.cn))
                {
                    _logInfoS.LogInfo("1.-Se Conecto",Conexion.cn);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT * FROM [dbo].[ESTRUCTURA]");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), EstructuraConexion);
                    cmd.CommandType = CommandType.Text;
                    EstructuraConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EstructuraLista.Add(
                                new Estructura()
                                {
                                    ID_Estructura = (int)dr["ID_Estructura"],
                                    Nombre_Estructura = (string)dr["Nombre_Estructura"],
                                    Activo = (bool)dr["Activo"]
                                });
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                _logInfoS.LogError("1.- Error al obtener Listado", ex);
                EstructuraLista = new List<Estructura>();
            }
            return EstructuraLista;
        }
        public int Agregar(Estructura obj, out string Mensaje)
        {
            int idgenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection EstructuraConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_AgregarEstructura", EstructuraConexion);
                    cmd.Parameters.AddWithValue("Nombre_Estructura", obj.Nombre_Estructura);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    EstructuraConexion.Open();
                    cmd.ExecuteNonQuery();
                    idgenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch(Exception ex)
            {
                idgenerado = 0;
                Mensaje = ex.Message;
            }
            return idgenerado;
        }

        public bool Editar(Estructura obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection EstructuraConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarEstructura", EstructuraConexion);
                    cmd.Parameters.AddWithValue("ID_Estructura", obj.ID_Estructura);
                    cmd.Parameters.AddWithValue("Nombre_Estructura", obj.Nombre_Estructura);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    EstructuraConexion.Open();
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
                using (SqlConnection EstructuraConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarEstructura", EstructuraConexion);
                    cmd.Parameters.AddWithValue("ID_Estructura", id);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    EstructuraConexion.Open();
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
