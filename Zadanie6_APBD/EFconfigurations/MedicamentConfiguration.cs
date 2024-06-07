using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zadanie6_APBD.Models;

namespace Zadanie6_APBD.EFconfigurations;

public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder.HasKey(m => m.IdMedicament);
        builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Description).HasMaxLength(100);
        builder.Property(m => m.Type).HasMaxLength(100);

        builder.ToTable("Medicament");
    }
}