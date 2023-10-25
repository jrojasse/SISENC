using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class EstructuraController : Controller
    {
        // GET: Estructura
        public ActionResult EstructuraView()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarEstructura()
        {
            List<Estructura> oLista = new List<Estructura>();
            oLista = new CN_Estructura().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarEstructura(Estructura objeto)
        {
            object Resultado;
            string Mensaje = string.Empty;

            if (objeto.ID_Estructura == 0)
            {
                Resultado = new CN_Estructura().Agregar(objeto,out Mensaje);
            }
            else
            {
                Resultado = new CN_Estructura().Editar(objeto, out Mensaje);
            }
            
            return Json(new { Resultado = Resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult EliminarEstructura(int id)
        {
            bool Respuesta = false;
            string Mensaje = string.Empty;

            Respuesta = new CN_Estructura().Eliminar(id,out Mensaje);

            return Json(new { Resultado = Respuesta, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }
    }
}