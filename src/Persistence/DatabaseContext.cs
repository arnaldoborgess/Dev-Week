using Microsoft.EntityFrameworkCore;
using api_dev_week.src.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_dev_week.src.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions
            <DatabaseContext> options) : base(options)
        {
        }


        public DbSet<Person> Persons { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>(table => {
                table.HasKey(e => e.Id);
                table
                .HasMany(e => e.Contracts)
                .WithOne()
                .HasForeignKey(c => c.PersonId);
            });
            builder.Entity<Contract>(table => {
                table.HasKey(e => e.Id);
            });

        }
    }
}
