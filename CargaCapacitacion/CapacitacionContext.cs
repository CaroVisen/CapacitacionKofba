using CargaCapacitacion.Configuration;
using CargaCapacitacion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargaCapacitacion
{
    public class CapacitacionContext : DbContext
    {
        public CapacitacionContext()
        {
        }
        public CapacitacionContext(DbContextOptions<CapacitacionContext> options) : base(options)
        {
        }

        public virtual DbSet<Fichada> Fichadas { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FichadaConfiguration());
            modelBuilder.ApplyConfiguration(new CursoConfiguration());
            modelBuilder.ApplyConfiguration(new HHRRConfiguration());
        }
    }
}
