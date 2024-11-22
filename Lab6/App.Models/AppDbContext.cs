using Microsoft.EntityFrameworkCore;

namespace App.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentUser> DocumentUsers { get; set; }
    public DbSet<ClientEntity> Clients { get; set; }
    public DbSet<Staff> Staff { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<PaymentDetail> PaymentDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<RefAgeBand> AgeBands { get; set; }
    public DbSet<RefGender> Genders { get; set; }
    public DbSet<RefSalonTreatment> SalonTreatments { get; set; }
    public DbSet<RefHairStyle> HairStyles { get; set; }
    public DbSet<StaffCharge> StaffCharges { get; set; }
    public DbSet<RefStaffJobTitle> StaffJobTitles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientEntity>()
            .HasOne(c => c.AgeBand)
            .WithMany(ab => ab.Clients)
            .HasForeignKey(c => c.AgeBandCode);

        modelBuilder.Entity<ClientEntity>()
            .HasOne(c => c.Gender)
            .WithMany(g => g.Clients)
            .HasForeignKey(c => c.GenderCode);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Client)
            .WithMany(c => c.Appointments)
            .HasForeignKey(a => a.ClientId);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Staff)
            .WithMany(s => s.Appointments)
            .HasForeignKey(a => a.StaffId);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.HairStyle)
            .WithMany(hs => hs.Appointments)
            .HasForeignKey(a => a.HairStyleCode);

        modelBuilder.Entity<PaymentDetail>()
            .HasOne(pd => pd.Client)
            .WithMany(c => c.PaymentDetails)
            .HasForeignKey(pd => pd.ClientId);
    }
}
