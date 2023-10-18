using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WEB_TTTN.Entities
{
    public partial class HospitalDatabaseContext : DbContext
    {
        public HospitalDatabaseContext()
        {
        }

        public HospitalDatabaseContext(DbContextOptions<HospitalDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Certificate> Certificates { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; } = null!;
        public virtual DbSet<HospitalHealthInsurance> HospitalHealthInsurances { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Medicine> Medicines { get; set; } = null!;
        public virtual DbSet<MedicineBill> MedicineBills { get; set; } = null!;
        public virtual DbSet<Nation> Nations { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<TypeService> TypeServices { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=HospitalDatabase;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("Account");

                entity.Property(e => e.Username).HasMaxLength(200);

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Password).HasMaxLength(500);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.Username).HasMaxLength(200);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blog_Account");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("Certificate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CertificateName).HasMaxLength(500);

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Img)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Usedate).HasColumnType("date");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Certificate_Employee");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassName).HasMaxLength(50);

                entity.Property(e => e.Img)
                    .HasMaxLength(3000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Blogid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Blog");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.Email, "IX_Employee")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(400);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Email)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Identification)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Img)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Username).HasMaxLength(200);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Employee_Class");

                entity.HasOne(d => d.EmployeeRole)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeRoleId)
                    .HasConstraintName("FK_Employee_EmployeeRole");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Account");
            });

            modelBuilder.Entity<EmployeeRole>(entity =>
            {
                entity.ToTable("EmployeeRole");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.RoleName).HasMaxLength(500);
            });

            modelBuilder.Entity<HospitalHealthInsurance>(entity =>
            {
                entity.HasKey(e => e.InsuranceId);

                entity.ToTable("Hospital health insurance");

                entity.Property(e => e.InsuranceId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InsuranceID");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Createday).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.HospitalName).HasMaxLength(500);

                entity.Property(e => e.Img)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Usedate).HasColumnType("date");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Img)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("Medicine");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Getdate).HasColumnType("date");

                entity.Property(e => e.Img)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Usedate).HasColumnType("date");

                entity.HasOne(d => d.Nation)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.Nationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medicine_Nation");
            });

            modelBuilder.Entity<MedicineBill>(entity =>
            {
                entity.ToTable("MedicineBill");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.MedicineBills)
                    .HasForeignKey(d => d.Medicineid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedicineBill_Medicine");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.MedicineBills)
                    .HasForeignKey(d => d.Serviceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedicineBill_Service");
            });

            modelBuilder.Entity<Nation>(entity =>
            {
                entity.ToTable("Nation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(400);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.HasIndex(e => e.Email, "IX_Patient")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(400);

                entity.Property(e => e.Email)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Img).HasMaxLength(1000);

                entity.Property(e => e.InsuranceId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InsuranceID");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Username).HasMaxLength(200);

                entity.HasOne(d => d.Insurance)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.InsuranceId)
                    .HasConstraintName("FK_Patient_Hospital health insurance");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_Account");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoleName).HasMaxLength(500);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Email).HasMaxLength(500);

                entity.Property(e => e.Endtime).HasColumnType("datetime");

                entity.Property(e => e.Eventname).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Starttime).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.Employeeid)
                    .HasConstraintName("FK_Schedule_Employee");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.Locationid)
                    .HasConstraintName("FK_Schedule_Location");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.Patientid)
                    .HasConstraintName("FK_Schedule_Patient");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Decription).HasMaxLength(2000);

                entity.Property(e => e.GetDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_Employee");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_Patient");

                entity.HasOne(d => d.TypeService)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.TypeServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_TypeService");
            });

            modelBuilder.Entity<TypeService>(entity =>
            {
                entity.ToTable("TypeService");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ServiceName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
