using SchoolRecords.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolRecords.Infrasctructure.Data.Mappings.Base;
using Microsoft.EntityFrameworkCore;

namespace SchoolRecords.Infrasctructure.Data.Mappings
{
    public class SchoolingMap : BaseMap<Schooling>
    {
        public override void ConfigureMap(EntityTypeBuilder<Schooling> builder)
        {

            builder.ToTable("Schoolings");

            builder.Property(c => c.Description)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired(false);

            builder.HasData(new Schooling()
            {
                Id = 1,
                Active = true,
                CreatedAt = new DateTime(2023,08,08),
                Description = "Ensino Infantil",
                Type = SchoolingTypeEnum.Infantil
            });

            builder.HasData(new Schooling()
            {
                Id = 2,
                Active = true,
                CreatedAt = new DateTime(2023, 08, 08),
                Description = "Ensino Fundamental",
                Type = SchoolingTypeEnum.Fundamental
            });

            builder.HasData(new Schooling()
            {
                Id = 3,
                Active = true,
                CreatedAt = new DateTime(2023, 08, 08),
                Description = "Ensino Médio",
                Type = SchoolingTypeEnum.Medio
            });

            builder.HasData(new Schooling()
            {
                Id = 4,
                Active = true,
                CreatedAt = new DateTime(2023, 08, 08),
                Description = "Ensino Superior",
                Type = SchoolingTypeEnum.Superior
            });
        }
    }
}