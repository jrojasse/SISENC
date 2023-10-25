using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class CanalController : Controller
    {
        // GET: Canal
        public ActionResult CanalView()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarCanal()
        {
            List<Canal> oLista = new List<Canal>();
            oLista = new CN_Canal().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarCanal(Canal objeto, int id)
        {
            object Resultado;
            string Mensaje = string.Empty;

            if (objeto.ID_Canal == id)
            {
                Resultado = new CN_Canal().Agregar(objeto, out Mensaje);
            }
            else
            {
                Resultado = new CN_Canal().Editar(objeto, out Mensaje);
            }

            return Json(new { Resultado = Resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult EliminarCanal(int id)
        {
            bool Respuesta = false;
            string Mensaje = string.Empty;

            Respuesta = new CN_Canal().Eliminar(id, out Mensaje);

            return Json(new { Resultado = Respuesta, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }
    }
}