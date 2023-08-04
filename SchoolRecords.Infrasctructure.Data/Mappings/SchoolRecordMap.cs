using SchoolRecords.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolRecords.Infrasctructure.Data.Mappings.Base;
using Microsoft.EntityFrameworkCore;


namespace SchoolRecords.Infrasctructure.Data.Mappings
{
    public class SchoolRecordMap : BaseMap<SchoolRecord>
    {
        public override void ConfigureMap(EntityTypeBuilder<SchoolRecord> builder)
        {

            builder.ToTable("SchoolRecords");

            builder.Property(c => c.Format)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(c => c.Name)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

        }
    }
}