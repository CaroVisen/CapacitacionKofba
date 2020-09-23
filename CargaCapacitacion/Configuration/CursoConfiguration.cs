using CargaCapacitacion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargaCapacitacion.Configuration
{
    public class CursoConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("TBL_Cursos").HasKey("Id");
        }
    }
}
