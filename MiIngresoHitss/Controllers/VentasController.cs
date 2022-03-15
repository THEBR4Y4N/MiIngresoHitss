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
        private MiIngresoHitssEntities ce = new MiIngresoHitssEntities();

        public ActionResult Index()
        {
            return View(ce.Venta.ToList().OrderBy(x=>x.DiaVenta));
        }
    }
}