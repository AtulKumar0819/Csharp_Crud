using Microsoft.EntityFrameworkCore;
using StudentApi.Models;

namespace HotelBookingAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Student> Students { get; set; } // Changed from Bookings to Students
        public DbSet<StudentAddress> StudentAddresses { get; set; }

       
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Student-StudentAddress relationship
            modelBuilder.Entity<StudentAddress>()
                .HasOne(sa => sa.Student)
                .WithMany(s => s.Addresses)
                .HasForeignKey(sa => sa.StudentId);
        }
    }
}
