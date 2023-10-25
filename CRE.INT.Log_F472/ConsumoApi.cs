namespace CRE.INT.Log_F472
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    public static class ConsumoApi
    {
        public static VIEW_Respuesta AddApi(string sURL, string info)
        {
            VIEW_Respuesta respuesta = new VIEW_Respuesta();
            respuesta.Ok();
            try
            {
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create(sURL);
                wrGETURL.Method = "POST";
                wrGETURL.ContentType = @"application/json; charset=utf-8";
                using (var stream = new StreamWriter(wrGETURL.GetRequestStream()))
                {
                    //var json = JsonConvert.SerializeObject(info);
                    var json = info;
                    stream.Write(json);
                }
                HttpWebResponse webresponse = wrGETURL.GetResponse() as HttpWebResponse;
                Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                StreamReader loResponseStream = new StreamReader(webresponse.GetResponseStream(), enc);
                string strResult = loResponseStream.ReadToEnd();

                respuesta = JsonConvert.DeserializeObject<VIEW_Respuesta>(strResult);

                // close the stream object
                loResponseStream.Close();
                // close the response object
                webresponse.Close();

            }
            catch (Exception ex)
            {
                respuesta.Error("Error al Momento de registrar en el API", ex);
                return respuesta;
            }

            return respuesta;
        }
    }
}
