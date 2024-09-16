using ClinicManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementAPI.Data
{
    public class ClinicDbContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>()
       .HasKey(p => p.Id)
       .HasAnnotation("SqlServer:Identity", "1, 1");  

            modelBuilder.Entity<Appointment>()
                .HasKey(a => a.Id)
                .HasAnnotation("SqlServer:Identity", "1, 1");  

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);
        }
    }


}
