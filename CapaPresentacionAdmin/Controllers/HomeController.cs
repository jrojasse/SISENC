using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;
using CRE.INT.Log_F472;
using Newtonsoft.Json;

namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {
        private LogInfoS _logInfoS;

        public HomeController()
        {
            _logInfoS = new LogInfoS();
            _logInfoS.NameClass = this.ToString();
            _logInfoS.Origen = "SISENC";

            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        _logInfoS.IpAdress = ip.ToString();
                    }
                }
            }
            catch
            {
                _logInfoS.IpAdress = "XX.XX.XX.22";
            }
        }
        public ActionResult Index()
        {
            //*******************************************************************************
            //Registro de Seguimiento
            //*******************************************************************************

            _logInfoS.NameMethod = MethodBase.GetCurrentMethod().Name;
            _logInfoS.LogInfo("4.-Carga la vista de Home index");

            //*******************************************************************************
            //*******************************************************************************
            return View();
        }
        public JsonResult ListarV_ProductoUltimoPeriodo()
        {
            List<V_ProductoUltimoPeriodo> oLista = new List<V_ProductoUltimoPeriodo>();
            oLista = new CN_Home().Listar();
            var jsonResult = Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}