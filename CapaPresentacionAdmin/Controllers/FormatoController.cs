using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class FormatoController : Controller
    {
        // GET: Formato
        public ActionResult FormatoView()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarFormato()
        {
            List<Formato> oLista = new List<Formato>();
            oLista = new CN_Formato().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarFormato(Formato objeto)
        {
            object Resultado;
            string Mensaje = string.Empty;

            if (objeto.ID_Formato == 0)
            {
                Resultado = new CN_Formato().Agregar(objeto, out Mensaje);
            }
            else
            {
                Resultado = new CN_Formato().Editar(objeto, out Mensaje);
            }

            return Json(new { Resultado = Resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult EliminarFormato(int id)
        {
            bool Respuesta = false;
            string Mensaje = string.Empty;

            Respuesta = new CN_Formato().Eliminar(id, out Mensaje);

            return Json(new { Resultado = Respuesta, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }
    }
}