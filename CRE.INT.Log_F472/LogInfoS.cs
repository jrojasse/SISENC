using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.INT.Log_F472
{
    public class LogInfoS
    {
        /// <summary>
        /// Obtiene la dirección de donde se encuentra el API
        /// </summary>
        private string ubicacionAPI = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private DTOLogInfo _dtoLogInfo;

        /// <summary>
        /// 
        /// </summary>
        public string Origen = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string IpAdress = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string NameClass = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string NameMethod = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string xKey = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string xUser = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public LogInfoS()
        {
            try
            {
                //ubicacionAPI = AppSetValues.GetPathDataBaseAppSet("URI_APILog");
                ubicacionAPI = ConfigurationManager.AppSettings["URI_APILog"].ToString();
            }
            catch { ubicacionAPI = string.Empty; }

            _dtoLogInfo = new DTOLogInfo();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmessaje"></param>
        /// <param name="xcontent"></param>
        /// <returns></returns>
        public VIEW_Respuesta LogInfo(string xmessaje, string xcontent)
        {
            VIEW_Respuesta respuesta = new VIEW_Respuesta();
            if (string.IsNullOrEmpty(ubicacionAPI))
            {
                respuesta.Error("Dentro del appsettings.json no se encontro URI_APILog, por favor validar");
                return respuesta;
            }

            _dtoLogInfo.Type = "Info";
            _dtoLogInfo.Origin = Origen;

            _dtoLogInfo.IpOrigin = IpAdress;
            _dtoLogInfo.NameClass = NameClass;
            _dtoLogInfo.NameMethod = NameMethod;

            _dtoLogInfo.Message = xmessaje;
            _dtoLogInfo.Content = xcontent;
            _dtoLogInfo.User = string.IsNullOrEmpty(xUser) == true ? "userLog" : xUser;
            _dtoLogInfo.Key = string.IsNullOrEmpty(xKey) ? string.Empty : xKey;

            respuesta = ConsumoApi.AddApi(ubicacionAPI, _dtoLogInfo.ToCadena());
            return respuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmessaje"></param>
        /// <returns></returns>
        public VIEW_Respuesta LogInfo(string xmessaje)
        {
            VIEW_Respuesta respuesta = new VIEW_Respuesta();
            if (string.IsNullOrEmpty(ubicacionAPI))
            {
                respuesta.Error("Dentro del appsettings.json no se encontro URI_APILog, por favor validar");
                return respuesta;
            }

            _dtoLogInfo.Type = "Info";
            _dtoLogInfo.Origin = Origen;

            _dtoLogInfo.IpOrigin = IpAdress;
            _dtoLogInfo.NameClass = NameClass;
            _dtoLogInfo.NameMethod = NameMethod;

            _dtoLogInfo.Message = xmessaje;
            _dtoLogInfo.Content = string.Empty;
            _dtoLogInfo.User = string.IsNullOrEmpty(xUser) == true ? "userLog" : xUser;
            _dtoLogInfo.Key = string.IsNullOrEmpty(xKey) ? string.Empty : xKey;

            respuesta = ConsumoApi.AddApi(ubicacionAPI, _dtoLogInfo.ToCadena());
            return respuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmessaje"></param>
        /// <returns></returns>
        public VIEW_Respuesta LogError(string xmessaje)
        {
            VIEW_Respuesta respuesta = new VIEW_Respuesta();
            if (string.IsNullOrEmpty(ubicacionAPI))
            {
                respuesta.Error("Dentro del appsettings.json no se encontro URI_APILog, por favor validar");
                return respuesta;
            }

            _dtoLogInfo.Type = "Error";
            _dtoLogInfo.Origin = Origen;

            _dtoLogInfo.IpOrigin = IpAdress;
            _dtoLogInfo.NameClass = NameClass;
            _dtoLogInfo.NameMethod = NameMethod;

            _dtoLogInfo.Message = xmessaje;
            _dtoLogInfo.Content = string.Empty;
            _dtoLogInfo.User = string.IsNullOrEmpty(xUser) == true ? "userLog" : xUser;
            _dtoLogInfo.Key = string.IsNullOrEmpty(xKey) ? string.Empty : xKey;

            respuesta = ConsumoApi.AddApi(ubicacionAPI, _dtoLogInfo.ToCadena());
            return respuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmessaje"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public VIEW_Respuesta LogError(string xmessaje, Exception ex)
        {
            VIEW_Respuesta respuesta = new VIEW_Respuesta();
            if (string.IsNullOrEmpty(ubicacionAPI))
            {
                respuesta.Error("Dentro del appsettings.json no se encontro URI_APILog, por favor validar");
                return respuesta;
            }

            _dtoLogInfo.Type = "Error";
            _dtoLogInfo.Origin = Origen;

            _dtoLogInfo.IpOrigin = IpAdress;
            _dtoLogInfo.NameClass = NameClass;
            _dtoLogInfo.NameMethod = NameMethod;

            _dtoLogInfo.Message = xmessaje;
            _dtoLogInfo.Content = ex.ToString();
            _dtoLogInfo.User = string.IsNullOrEmpty(xUser) == true ? "userLog" : xUser;
            _dtoLogInfo.Key = string.IsNullOrEmpty(xKey) ? string.Empty : xKey;

            respuesta = ConsumoApi.AddApi(ubicacionAPI, _dtoLogInfo.ToCadena());
            return respuesta;
        }
    }
}
