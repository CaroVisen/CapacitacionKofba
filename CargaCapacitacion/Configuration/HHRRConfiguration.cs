using CargaCapacitacion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CargaCapacitacion.Configuration
{
    public class HHRRConfiguration : IEntityTypeConfiguration<HHRR>
    {
        public void Configure(EntityTypeBuilder<HHRR> builder)
        {
            builder.ToTable("TL_HHRR").HasNoKey();
        }
    }
}
