using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zadanie6_APBD.Models;

namespace Zadanie6_APBD.EFconfigurations;


public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(p => p.IdPrescription);
        builder.Property(p => p.Date).IsRequired();
        builder.Property(p => p.DueDate).IsRequired();

        builder.HasOne(p => p.Patient)
            .WithMany(pat => pat.Prescriptions)
            .HasForeignKey(p => p.IdPatient);

        builder.HasOne(p => p.Doctor)
            .WithMany(d => d.Prescriptions)
            .HasForeignKey(p => p.IdDoctor);

        builder.ToTable("Prescription");
    }
}