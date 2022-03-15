using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiIngresoHitss.Models;
using Microsoft.EntityFrameworkCore;

namespace MiIngresoHitss.Context
{
    public class MVCContext : DbContext
    {
        public MVCContext(DbContextOptions options): base(options) 
        {

        }
        public DbSet<Product> Producto { get; set; }
    }
}