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

        }
    }
}