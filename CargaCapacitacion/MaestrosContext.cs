using CargaCapacitacion.Configuration;
using CargaCapacitacion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargaCapacitacion
{
    public class MaestrosContext : DbContext
    {
        public MaestrosContext()
        {
        }
        public MaestrosContext(DbContextOptions<MaestrosContext> options) : base(options)
        {
        }

        public virtual DbSet<HHRR> HHRR { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HHRRConfiguration());
        }
    }
}
