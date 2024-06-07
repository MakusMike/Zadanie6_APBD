using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zadanie6_APBD.Models;

namespace Zadanie6_APBD.EFconfigurations;

public class PrescriptionMedicamentConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder.HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });

        builder.Property(pm => pm.Dose).IsRequired();
        builder.Property(pm => pm.Details).HasMaxLength(100);

        builder.HasOne(pm => pm.Medicament)
            .WithMany(m => m.PrescriptionMedicaments)
            .HasForeignKey(pm => pm.IdMedicament);

        builder.HasOne(pm => pm.Prescription)
            .WithMany(p => p.PrescriptionMedicaments)
            .HasForeignKey(pm => pm.IdPrescription);

        builder.ToTable("Prescription_Medicament");
    }
}