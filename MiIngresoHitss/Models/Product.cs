using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiIngresoHitss.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripciòn { get; set; }
        public double Precio { get; set; }
    }
}