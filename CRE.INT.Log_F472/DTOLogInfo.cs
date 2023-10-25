using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace CRE.INT.Log_F472
{
    public class DTOLogInfo
    {

        [Key]
        public int IdSequence { get; set; }
        public string Origin { get; set; }
        public string NameClass { get; set; }
        public string NameMethod { get; set; }
        public string IpOrigin { get; set; }
        public string Type { get; set; }
        public string User { get; set; }
        public string Message { get; set; }
        public string Content { get; set; }
        public string Key { get; set; }

        /// <summary>
        /// Retorna toda la respuesta como un string
        /// </summary>
        /// <returns></returns>
        public string ToCadena()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
