using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class CargaTramaController : Controller
    {
        // GET: Absa
        public ActionResult AbsaView()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarAbsa()
        {
            List<Absa> oLista = new List<Absa>();
            oLista = new CN_Absa().Listar();
            var jsonResult = Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GuardarCargaTrama(Producto Producto, string Year, string Mes)
        {
            object Resultado;
            string Mensaje = string.Empty;

            if (Producto.oEstructura.ID_Estructura == 1)
            {
                Resultado = new CN_Absa().Agregar(Producto, Year, Mes, out Mensaje);
            }
            else if (Producto.oEstructura.ID_Estructura == 3)
            {
                Resultado = new CN_CooperativaOriente().Agregar(Producto, Year, Mes, out Mensaje);
            }
            else if (Producto.oEstructura.ID_Estructura == 4)
            {
                Resultado = new CN_Cencosud().Agregar(Producto, Year, Mes, out Mensaje);
            }
            else
            {
                Resultado = 0;
                Mensaje = "El nombre del producto no puede ser vacio";
            }

            return Json(new { Resultado = Resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }
    }
}