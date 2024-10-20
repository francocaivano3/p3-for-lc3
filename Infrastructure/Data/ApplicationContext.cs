
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<EventOrganizer> EventsOrganizers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasKey(e => e.Id); 

            modelBuilder.Entity<Ticket>().HasKey(t => t.Id); 

            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("Role")
                .HasValue<Client>("Client")
                .HasValue<EventOrganizer>("Event Organizer")
                .HasValue<SuperAdmin>("Super Admin");

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Event) 
                .WithMany(e => e.Tickets)  
                .HasForeignKey(t => t.EventId) 
                .OnDelete(DeleteBehavior.Cascade);  

            //modelBuilder.Entity<EventOrganizer>()
            //    .HasKey(o => o.Id);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.EventOrganizer)
                .WithMany(o => o.MyEvents)
                .HasForeignKey(e => e.EventOrganizerId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
