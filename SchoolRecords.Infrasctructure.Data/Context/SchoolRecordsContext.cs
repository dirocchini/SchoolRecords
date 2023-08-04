using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SchoolRecords.ApplicationServices.Interfaces;
using SchoolRecords.Domain.Entities;
using SchoolRecords.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRecords.Infrasctructure.Data.Context
{
    public class SchoolRecordsContext : DbContext, IApplicationContext
    {
        public SchoolRecordsContext(DbContextOptions options) : base(options)
        {
            if (Database.GetPendingMigrations().Any())
                Database.Migrate();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Schooling> Schooling { get; set; }
        public DbSet<SchoolRecord> SchoolRecords { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolRecordsContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry<BaseEntity> entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.Active = true;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
