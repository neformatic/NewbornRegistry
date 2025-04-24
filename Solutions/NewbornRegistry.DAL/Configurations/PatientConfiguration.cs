using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewbornRegistry.Common.Constants;
using NewbornRegistry.DAL.Constants;
using NewbornRegistry.DAL.Entities;

namespace NewbornRegistry.DAL.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable(DatabaseTableNameConstants.Patients);

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Family)
            .IsRequired()
            .HasMaxLength(FieldSizeConstants.PatientFamilyMaxSize);

        builder.Property(p => p.Use)
            .HasMaxLength(FieldSizeConstants.PatientUseMaxSize);

        builder.Property(p => p.BirthDate)
            .IsRequired();

        builder.Property(p => p.Given)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList())
            .HasMaxLength(FieldSizeConstants.PatientGivenMaxSize);

        builder.HasIndex(p => p.BirthDate);
    }
}