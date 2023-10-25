using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class RiesgoController : Controller
    {
        // GET: Riesgo
        public ActionResult RiesgoView()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarRiesgo()
        {
            List<Riesgo> oLista = new List<Riesgo>();
            oLista = new CN_Riesgo().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarRiesgo(Riesgo objeto, int id)
        {
            object Resultado;
            string Mensaje = string.Empty;

            if (objeto.ID_Riesgo == id)
            {
                Resultado = new CN_Riesgo().Agregar(objeto, out Mensaje);
            }
            else
            {
                Resultado = new CN_Riesgo().Editar(objeto, out Mensaje);
            }

            return Json(new { Resultado = Resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult EliminarRiesgo(int id)
        {
            bool Respuesta = false;
            string Mensaje = string.Empty;

            Respuesta = new CN_Riesgo().Eliminar(id, out Mensaje);

            return Json(new { Resultado = Respuesta, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }
    }
}