using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DateSoftware1_Api.Models
{
    public partial class DateSoftwareContext : DbContext
    {
        public DateSoftwareContext()
        {
        }

        public DateSoftwareContext(DbContextOptions<DateSoftwareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ailment> Ailments { get; set; }
        public virtual DbSet<Date> Dates { get; set; }
        public virtual DbSet<DetailAilment> DetailAilments { get; set; }
        public virtual DbSet<DetailExtraValue> DetailExtraValues { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<ExtraValue> ExtraValues { get; set; }
        public virtual DbSet<GeneralInformation> GeneralInformations { get; set; }
        public virtual DbSet<SpecialityDoctor> SpecialityDoctors { get; set; }
        public virtual DbSet<TypeDate> TypeDates { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRol> UserRols { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("SERVER = DESKTOP-L5BN9MV;DATABASE= DateSoftware;User Id =sa;Password = 123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Ailment>(entity =>
            {
                entity.HasKey(e => e.IdAilment)
                    .HasName("PK__Ailment__BA172BB96661751B");

                entity.ToTable("Ailment");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Date>(entity =>
            {
                entity.HasKey(e => e.IdDate)
                    .HasName("PK__Date__F298CC8969154717");

                entity.ToTable("Date");

                entity.Property(e => e.Date1)
                    .HasColumnType("datetime")
                    .HasColumnName("Date");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.FinalCost).HasColumnType("decimal(11, 2)");

                entity.Property(e => e.InitialCost).HasColumnType("decimal(11, 2)");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Dates)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDate575960");

                entity.HasOne(d => d.IdTypeDateNavigation)
                    .WithMany(p => p.Dates)
                    .HasForeignKey(d => d.IdTypeDate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDate201818");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Dates)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDate409312");
            });

            modelBuilder.Entity<DetailAilment>(entity =>
            {
                entity.HasKey(e => e.IdDetailAilment)
                    .HasName("PK__DetailAi__B1BA62A04EA0CB3E");

                entity.ToTable("DetailAilment");

                entity.HasOne(d => d.IdAilmentNavigation)
                    .WithMany(p => p.DetailAilments)
                    .HasForeignKey(d => d.IdAilment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDetailAilm536726");

                entity.HasOne(d => d.IdInformationNavigation)
                    .WithMany(p => p.DetailAilments)
                    .HasForeignKey(d => d.IdInformation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDetailAilm833682");
            });

            modelBuilder.Entity<DetailExtraValue>(entity =>
            {
                entity.HasKey(e => e.IdDetailExtraValue)
                    .HasName("PK__DetailEx__2843E6070322EA6B");

                entity.ToTable("DetailExtraValue");

                entity.Property(e => e.FinalPrice).HasColumnType("decimal(11, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(11, 2)");

                entity.HasOne(d => d.IdDateNavigation)
                    .WithMany(p => p.DetailExtraValues)
                    .HasForeignKey(d => d.IdDate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDetailExtr242148");

                entity.HasOne(d => d.IdExtraValueNavigation)
                    .WithMany(p => p.DetailExtraValues)
                    .HasForeignKey(d => d.IdExtraValue)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDetailExtr417901");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("PK__Doctor__F838DB3E8C017D08");

                entity.ToTable("Doctor");

                entity.Property(e => e.Adress)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.HasOne(d => d.IdSpecialityDoctorNavigation)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.IdSpecialityDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDoctor586790");
            });

            modelBuilder.Entity<ExtraValue>(entity =>
            {
                entity.HasKey(e => e.IdExtraValue)
                    .HasName("PK__ExtraVal__FB87F7E227896D38");

                entity.ToTable("ExtraValue");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(11, 2)");
            });

            modelBuilder.Entity<GeneralInformation>(entity =>
            {
                entity.HasKey(e => e.IdInformation)
                    .HasName("PK__GeneralI__D2F1D6BEE184D5C5");

                entity.ToTable("GeneralInformation");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Height)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TypeBlood)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Weight)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GeneralInformations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKGeneralInf251613");
            });

            modelBuilder.Entity<SpecialityDoctor>(entity =>
            {
                entity.HasKey(e => e.IdSpecialityDoctor)
                    .HasName("PK__Speciali__7BDE23790875F21B");

                entity.ToTable("SpecialityDoctor");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeDate>(entity =>
            {
                entity.HasKey(e => e.IdTypeDate)
                    .HasName("PK__TypeDate__E8564345F0E4973C");

                entity.ToTable("TypeDate");

                entity.Property(e => e.Cost).HasColumnType("decimal(11, 2)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__User__1788CC4C31522C39");

                entity.ToTable("User");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RecuperationCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUser545129");
            });

            modelBuilder.Entity<UserRol>(entity =>
            {
                entity.HasKey(e => e.UserRoleId)
                    .HasName("PK__UserRol__3D978A355514D65A");

                entity.ToTable("UserRol");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
