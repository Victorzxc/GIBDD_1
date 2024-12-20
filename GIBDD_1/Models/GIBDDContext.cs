using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GIBDD_1.Models
{
    public partial class GIBDDContext : DbContext
    {
        public GIBDDContext()
        {
        }

        public GIBDDContext(DbContextOptions<GIBDDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccidentParticipants> AccidentParticipants { get; set; }
        public virtual DbSet<Accidents> Accidents { get; set; }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<MedicalCertificates> MedicalCertificates { get; set; }
        public virtual DbSet<Officers> Officers { get; set; }
        public virtual DbSet<TrafficRules> TrafficRules { get; set; }
        public virtual DbSet<VehicleInspections> VehicleInspections { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }
        public virtual DbSet<ViolationTypes> ViolationTypes { get; set; }
        public virtual DbSet<Violations> Violations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-RLHTV97;Database=GIBDD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccidentParticipants>(entity =>
            {
                entity.HasKey(e => e.ParticipantId)
                    .HasName("PK__accident__4E037806F12DDB6C");

                entity.ToTable("accident_participants");

                entity.Property(e => e.ParticipantId).HasColumnName("participant_id");

                entity.Property(e => e.AccidentId).HasColumnName("accident_id");

                entity.Property(e => e.DriverId).HasColumnName("driver_id");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                entity.HasOne(d => d.Accident)
                    .WithMany(p => p.AccidentParticipants)
                    .HasForeignKey(d => d.AccidentId)
                    .HasConstraintName("FK__accident___accid__4CA06362");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.AccidentParticipants)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK__accident___drive__4D94879B");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.AccidentParticipants)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK__accident___vehic__4E88ABD4");
            });

            modelBuilder.Entity<Accidents>(entity =>
            {
                entity.HasKey(e => e.AccidentId)
                    .HasName("PK__accident__A27CA62BC14DB23C");

                entity.ToTable("accidents");

                entity.Property(e => e.AccidentId).HasColumnName("accident_id");

                entity.Property(e => e.DateTime)
                    .HasColumnName("date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OfficerId).HasColumnName("officer_id");

                entity.Property(e => e.RuleId).HasColumnName("rule_id");

                entity.HasOne(d => d.Officer)
                    .WithMany(p => p.Accidents)
                    .HasForeignKey(d => d.OfficerId)
                    .HasConstraintName("FK__accidents__offic__3B75D760");

                entity.HasOne(d => d.Rule)
                    .WithMany(p => p.Accidents)
                    .HasForeignKey(d => d.RuleId)
                    .HasConstraintName("FK__accidents__rule___3C69FB99");
            });

            modelBuilder.Entity<Drivers>(entity =>
            {
                entity.HasKey(e => e.DriverId)
                    .HasName("PK__drivers__A411C5BD9551B18A");

                entity.ToTable("drivers");

                entity.Property(e => e.DriverId).HasColumnName("driver_id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("date_of_birth")
                    .HasColumnType("date");

                entity.Property(e => e.DriverLicenseNumber)
                    .HasColumnName("driver_license_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedicalCertificates>(entity =>
            {
                entity.HasKey(e => e.CertificateId)
                    .HasName("PK__medical___E2256D3150CC0929");

                entity.ToTable("medical_certificates");

                entity.Property(e => e.CertificateId).HasColumnName("certificate_id");

                entity.Property(e => e.DriverId).HasColumnName("driver_id");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnName("expiry_date")
                    .HasColumnType("date");

                entity.Property(e => e.IssueDate)
                    .HasColumnName("issue_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.MedicalCertificates)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK__medical_c__drive__534D60F1");
            });

            modelBuilder.Entity<Officers>(entity =>
            {
                entity.HasKey(e => e.OfficerId)
                    .HasName("PK__officers__AF7899974EE7AE8A");

                entity.ToTable("officers");

                entity.Property(e => e.OfficerId).HasColumnName("officer_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OfficerNumber)
                    .HasColumnName("officer_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TrafficRules>(entity =>
            {
                entity.HasKey(e => e.RuleId)
                    .HasName("PK__traffic___E92A92969FAC088A");

                entity.ToTable("traffic_rules");

                entity.Property(e => e.RuleId).HasColumnName("rule_id");

                entity.Property(e => e.ArticleNumber)
                    .HasColumnName("article_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BaseFine)
                    .HasColumnName("base_fine")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CoefficientMultiplier)
                    .HasColumnName("coefficient_multiplier")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<VehicleInspections>(entity =>
            {
                entity.HasKey(e => e.InspectionId)
                    .HasName("PK__vehicle___C3C4E743D7509412");

                entity.ToTable("vehicle_inspections");

                entity.Property(e => e.InspectionId).HasColumnName("inspection_id");

                entity.Property(e => e.InspectionDate)
                    .HasColumnName("inspection_date")
                    .HasColumnType("date");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.VehicleInspections)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK__vehicle_i__vehic__5629CD9C");
            });

            modelBuilder.Entity<Vehicles>(entity =>
            {
                entity.HasKey(e => e.VehicleId)
                    .HasName("PK__vehicles__F2947BC1691E2269");

                entity.ToTable("vehicles");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                entity.Property(e => e.DriverId).HasColumnName("driver_id");

                entity.Property(e => e.Make)
                    .HasColumnName("make")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationNumber)
                    .HasColumnName("registration_number")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Vin)
                    .HasColumnName("vin")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK__vehicles__driver__49C3F6B7");
            });

            modelBuilder.Entity<ViolationTypes>(entity =>
            {
                entity.HasKey(e => e.ViolationTypeId)
                    .HasName("PK__violatio__71B535737201E88C");

                entity.ToTable("violation_types");

                entity.Property(e => e.ViolationTypeId).HasColumnName("violation_type_id");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.FineBase)
                    .HasColumnName("fine_base")
                    .HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Violations>(entity =>
            {
                entity.HasKey(e => e.ViolationId)
                    .HasName("PK__violatio__8A989363D1A5EA32");

                entity.ToTable("violations");

                entity.Property(e => e.ViolationId).HasColumnName("violation_id");

                entity.Property(e => e.DriverId).HasColumnName("driver_id");

                entity.Property(e => e.FineAmount)
                    .HasColumnName("fine_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OfficerId).HasColumnName("officer_id");

                entity.Property(e => e.PaymentStatus)
                    .HasColumnName("payment_status")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                entity.Property(e => e.ViolationCode)
                    .HasColumnName("violation_code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ViolationTypeId).HasColumnName("violation_type_id");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Violations)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK__violation__drive__59063A47");

                entity.HasOne(d => d.Officer)
                    .WithMany(p => p.Violations)
                    .HasForeignKey(d => d.OfficerId)
                    .HasConstraintName("FK__violation__offic__5BE2A6F2");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Violations)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK__violation__vehic__59FA5E80");

                entity.HasOne(d => d.ViolationType)
                    .WithMany(p => p.Violations)
                    .HasForeignKey(d => d.ViolationTypeId)
                    .HasConstraintName("FK__violation__viola__5AEE82B9");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
