using SchoolRecords.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolRecords.Infrasctructure.Data.Mappings.Base;
using Microsoft.EntityFrameworkCore;

namespace SchoolRecords.Infrasctructure.Data.Mappings
{
    public class UserMap : BaseMap<User>
    {
        public override void ConfigureMap(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("Users");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(c => c.Surname)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired(false);

            builder.HasIndex(c => c.Email)
                .IsUnique();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.BirthDate)
                .HasColumnType("datetime")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(x => x.Schooling)
                .WithMany()
                .IsRequired();

            builder.HasOne(x => x.SchoolRecord)
                .WithOne()
                .IsRequired(false);
        }
    }
}