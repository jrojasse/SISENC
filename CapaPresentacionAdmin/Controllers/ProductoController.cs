using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;
using Newtonsoft.Json;

namespace CapaPresentacionAdmin.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult ProductoView()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarProducto()
        {
            List<Producto> oLista = new List<Producto>();
            oLista = new CN_Producto().Listar();
            var jsonResult = Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

            //return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarProducto(Producto objeto, int id)
        {
            object Resultado;
            string Mensaje = string.Empty;

            if (objeto.ID_Producto == id)
            {
                Resultado = new CN_Producto().Agregar(objeto, out Mensaje);
            }
            else
            {
                Resultado = new CN_Producto().Editar(objeto, out Mensaje);
            }

            return Json(new { Resultado = Resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult EliminarProducto(int id)
        {
            bool Respuesta = false;
            string Mensaje = string.Empty;

            Respuesta = new CN_Producto().Eliminar(id, out Mensaje);

            return Json(new { Resultado = Respuesta, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }
    }
}