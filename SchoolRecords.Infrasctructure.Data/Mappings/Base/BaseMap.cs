using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolRecords.Domain.Entities.Base;

namespace SchoolRecords.Infrasctructure.Data.Mappings.Base
{
    public abstract class BaseMap<TEntity> : IEntityTypeConfiguration<TEntity>
            where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.CreatedAt)
                .HasColumnName("CreatedAt");

            ConfigureMap(builder);
        }

        public abstract void ConfigureMap(EntityTypeBuilder<TEntity> builder);
    }
}