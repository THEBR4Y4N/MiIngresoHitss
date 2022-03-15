using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiIngresoHitss.Models;

namespace MiIngresoHitss.Controllers
{
    public class VentasController : Controller
    {
        // GET: Ventas
        private MiIngresoHitssEntities1 ce = new MiIngresoHitssEntities1();

        public ActionResult Index()
        {
            return View(ce.Venta.ToList().OrderBy(x=>x.DiaVenta));
        }
    }
}