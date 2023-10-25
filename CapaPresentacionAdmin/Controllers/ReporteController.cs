using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult ComprobantesCESView()
        {
            return View();
        }
        public ActionResult ComprobantesCPEView()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarComprobantesCES()
        {
            List<ComprobantesCES> oLista = new List<ComprobantesCES>();
            oLista = new CN_ComprobantesCES().Listar();
            var jsonResult = Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult ListarComprobantesCPE()
        {
            List<ComprobantesCPE> oLista = new List<ComprobantesCPE>();
            oLista = new CN_ComprobantesCPE().Listar();
            var jsonResult = Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public JsonResult ExportarReporte(Producto Producto, string Year, string Mes)
        {
            object Resultado;
            string Mensaje = string.Empty;

            if (Producto.oFormato.ID_Formato == 1)
            {
                Resultado = new CN_ComprobantesCPE().Exportar(Producto, Year, Mes, out Mensaje);
            }
            else if (Producto.oFormato.ID_Formato == 2)
            {
                Resultado = new CN_ComprobantesCES().Exportar(Producto, Year, Mes, out Mensaje);
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