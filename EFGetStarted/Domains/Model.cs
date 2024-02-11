using EFGetStarted.Domains.Tickets;
using EFGetStarted.Domains.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace EFGetStarted.Domains;

public class BloggingContext : DbContext
{
    // user section
    public DbSet<User> Users { get; set; }

    // ticket section
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketTag> TicketTag { get; set; }
    public DbSet<TicketHour> TicketTags { get; set; }
    public DbSet<TicketComment> TicketComments { get; set; }


    public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
    {
    }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry is { State: EntityState.Modified, Entity: CreationDateRecord entity })
            {
                entity.LastModifiedDateUTC = DateTime.UtcNow;
            }
        }

        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //To make sure all the DateTime props are store as UTC time
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(new ValueConverter<DateTime, DateTime>(
                        v => v.ToUniversalTime(),
                        v => DateTime.SpecifyKind(v, DateTimeKind.Utc)));
                }
            }
        }
    }
}
