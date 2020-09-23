using CargaCapacitacion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargaCapacitacion.Configuration
{
    public class FichadaConfiguration : IEntityTypeConfiguration<Fichada>
    {
        public void Configure(EntityTypeBuilder<Fichada> builder)
        {
            builder.ToTable("TBL_Fichadas").HasNoKey();
        }
    }
}
