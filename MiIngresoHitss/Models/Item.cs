using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiIngresoHitss.Models
{
    public class Item
    {
        private Producto _producto;

        public Producto Producto
        {
            get
            {
                return _producto;
            }
            set
            {
                _producto = value;
            }
        }

        private int _cantidad;
        public int Cantidad
        {
            get
            {
                return _cantidad;
            }
            set
            {
                _cantidad = value;
            }
        }

        public Item()
        {

        }

        public Item(Producto producto, int cantidad)
        {
            this._producto = producto;
            this._cantidad = cantidad;
        }


    }
}