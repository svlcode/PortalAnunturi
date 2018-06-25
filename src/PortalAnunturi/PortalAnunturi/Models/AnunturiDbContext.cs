using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PortalAnunturi.Models.Entities;

namespace PortalAnunturi.Models
{
    public partial class AnunturiDbContext : DbContext
    {
        public AnunturiDbContext()
        {
        }

        public AnunturiDbContext(DbContextOptions<AnunturiDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anunt> Anunt { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=AnunturiDb;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anunt>(entity =>
            {
                entity.HasKey(e => e.IdAnunt);

                entity.Property(e => e.IdAnunt).HasColumnName("Id_Anunt");

                entity.Property(e => e.DataCreare)
                    .HasColumnName("Data_Creare")
                    .HasColumnType("date");

                entity.Property(e => e.DataExpirare)
                    .HasColumnName("Data_Expirare")
                    .HasColumnType("date");

                entity.Property(e => e.Descriere)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategory).HasColumnName("Id_Category");

                entity.Property(e => e.IdUser).HasColumnName("Id_User");

                entity.Property(e => e.Titlu)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Anunt)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Anunt_Category");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Anunt)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Anunt_User");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory);

                entity.Property(e => e.IdCategory).HasColumnName("Id_Category");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser).HasColumnName("Id_User");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
