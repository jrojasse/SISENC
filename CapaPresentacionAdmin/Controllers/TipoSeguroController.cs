using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class TipoSeguroController : Controller
    {
        // GET: TipoSeguro
        public ActionResult TipoSeguroView()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarTipoSeguro()
        {
            List<TipoSeguro> oLista = new List<TipoSeguro>();
            oLista = new CN_TipoSeguro().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTipoSeguro(TipoSeguro objeto, string id)
        {
            object Resultado;
            string Mensaje = string.Empty;

            if (objeto.ID_Tipo_Seguro == id)
            {
                Resultado = new CN_TipoSeguro().Agregar(objeto, out Mensaje);
            }
            else
            {
                Resultado = new CN_TipoSeguro().Editar(objeto, out Mensaje);
            }

            return Json(new { Resultado = Resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult EliminarTipoSeguro(string id)
        {
            bool Respuesta = false;
            string Mensaje = string.Empty;

            Respuesta = new CN_TipoSeguro().Eliminar(id, out Mensaje);

            return Json(new { Resultado = Respuesta, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }
    }
}
