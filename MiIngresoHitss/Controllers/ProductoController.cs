using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiIngresoHitss.Models;

namespace MiIngresoHitss.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        private MiIngresoHitssEntities ce = new MiIngresoHitssEntities();


        public ActionResult Index()
        {
            return View(ce.Producto.ToList().OrderBy(x=>x.Nombre));
        }
    }
}