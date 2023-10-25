using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class RamoController : Controller
    {
        // GET: Ramo
        public ActionResult RamoView()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarRamo()
        {
            List<Ramo> oLista = new List<Ramo>();
            oLista = new CN_Ramo().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarRamo(Ramo objeto, int id)
        {
            object Resultado;
            string Mensaje = string.Empty;

            if (objeto.ID_Ramo == id)
            {
                Resultado = new CN_Ramo().Agregar(objeto, out Mensaje);
            }
            else
            {
                Resultado = new CN_Ramo().Editar(objeto, out Mensaje);
            }

            return Json(new { Resultado = Resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult EliminarRamo(int id)
        {
            bool Respuesta = false;
            string Mensaje = string.Empty;

            Respuesta = new CN_Ramo().Eliminar(id, out Mensaje);

            return Json(new { Resultado = Respuesta, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }
    }
}