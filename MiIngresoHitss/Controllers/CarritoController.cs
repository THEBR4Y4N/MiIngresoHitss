using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiIngresoHitss.Models;

namespace MiIngresoHitss.Controllers
{
    public class CarritoController : Controller
    {
        private MiIngresoHitssEntities1 ce = new MiIngresoHitssEntities1();
        public ActionResult AgregaCarrito(int id)
        {
            if (Session["Carrito"] == null)
            {
                List<Item> compras = new List<Item>();
                compras.Add(new Item(ce.Producto.Find(id), 1));
                Session["Carrito"] = compras;
            }
            else
            {
                List<Item> compras = (List<Item>)Session["Carrito"];
                int IndexE = getIndex(id);
                if (IndexE == -1)
                {
                    compras.Add(new Item(ce.Producto.Find(id), 1));
                }
                else
                {
                    compras[IndexE].Cantidad++;
                    Session["Carrito"] = compras;
                }

            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            List<Item> compras = (List<Item>)Session["Carrito"];
            compras.RemoveAt(getIndex(id));
            return View("AgregaCarrito");
        }
        public ActionResult FinalizaCompra()
        {
            List<Item> compras = (List<Item>)Session["Carrito"];
            if (compras != null && compras.Count > 0)
            {
                Venta nuevaVenta = new Venta();
                nuevaVenta.DiaVenta = DateTime.Now;
                nuevaVenta.Subtotal = compras.Sum(x => x.Producto.Precio * x.Cantidad);
                nuevaVenta.Iva = nuevaVenta.Subtotal * 0.19;
                nuevaVenta.Total = nuevaVenta.Subtotal + nuevaVenta.Iva;
                nuevaVenta.ListaVenta = (from Producto in compras
                                         select new ListaVenta
                                         {
                                             ProductoId = Producto.Producto.Id,
                                             Cantidad = Producto.Cantidad,
                                             Total = Producto.Cantidad * Producto.Producto.Precio
                                         }).ToList();
                ce.Venta.Add(nuevaVenta);
                ce.SaveChanges();
            }
            return View();
        }
        private int getIndex(int Id)
        {
            List<Item> compras = (List<Item>)Session["Carrito"];
            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].Producto.Id == Id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}