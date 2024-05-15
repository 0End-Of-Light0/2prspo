using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EF1PJ1.Models
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buildingmaterial> Buildingmaterials { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<Evaluation> Evaluations { get; set; } = null!;
        public virtual DbSet<EvaluationCr> EvaluationCrs { get; set; } = null!;
        public virtual DbSet<Object> Objects { get; set; } = null!;
        public virtual DbSet<Realtor> Realtors { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost:5432;Database=postgres;Username=postgres;Password=123451");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

            modelBuilder.Entity<Buildingmaterial>(entity =>
            {
                entity.HasKey(e => e.Materialcode)
                    .HasName("buildingmaterial_pk");

                entity.ToTable("buildingmaterial");

                entity.Property(e => e.Materialcode)
                    .HasColumnName("materialcode")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.Districtcode)
                    .HasName("district_pk");

                entity.ToTable("district");

                entity.Property(e => e.Districtcode)
                    .HasColumnName("districtcode")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.HasKey(e => e.EvCode)
                    .HasName("evaluation_pk");

                entity.ToTable("evaluation");

                entity.Property(e => e.EvCode)
                    .HasColumnName("ev_code")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CrCode).HasColumnName("cr_code");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Evulation).HasColumnName("evulation");

                entity.Property(e => e.ObjCode).HasColumnName("obj_code");

                entity.HasOne(d => d.CrCodeNavigation)
                    .WithMany(p => p.Evaluations)
                    .HasForeignKey(d => d.CrCode)
                    .HasConstraintName("evaluation_evaluation_cr_fk");

                entity.HasOne(d => d.ObjCodeNavigation)
                    .WithMany(p => p.Evaluations)
                    .HasForeignKey(d => d.ObjCode)
                    .HasConstraintName("evaluation_object_fk");
            });

            modelBuilder.Entity<EvaluationCr>(entity =>
            {
                entity.HasKey(e => e.CrCode)
                    .HasName("evaluation_cr_pk");

                entity.ToTable("evaluation_cr");

                entity.Property(e => e.CrCode)
                    .HasColumnName("cr_code")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Object>(entity =>
            {
                entity.HasKey(e => e.Objcode)
                    .HasName("object_pk");

                entity.ToTable("object");

                entity.Property(e => e.Objcode)
                    .HasColumnName("objcode")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Adress)
                    .HasColumnType("character varying")
                    .HasColumnName("adress");

                entity.Property(e => e.Cellcount).HasColumnName("cellcount");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.District).HasColumnName("district");

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.Material).HasColumnName("material");

                entity.Property(e => e.Message)
                    .HasColumnType("character varying")
                    .HasColumnName("message");

                entity.Property(e => e.Square).HasColumnName("square");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.DistrictNavigation)
                    .WithMany(p => p.Objects)
                    .HasForeignKey(d => d.District)
                    .HasConstraintName("object_district_fk");

                entity.HasOne(d => d.MaterialNavigation)
                    .WithMany(p => p.Objects)
                    .HasForeignKey(d => d.Material)
                    .HasConstraintName("object_buildingmaterial_fk");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Objects)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("object_type_fk");
            });

            modelBuilder.Entity<Realtor>(entity =>
            {
                entity.HasKey(e => e.ReCode)
                    .HasName("realtor_pk");

                entity.ToTable("realtor");

                entity.Property(e => e.ReCode)
                    .HasColumnName("re_code")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.FirstName)
                    .HasColumnType("character varying")
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasColumnType("character varying")
                    .HasColumnName("last_name");

                entity.Property(e => e.Patronymic)
                    .HasColumnType("character varying")
                    .HasColumnName("patronymic");

                entity.Property(e => e.Telephone)
                    .HasColumnType("character varying")
                    .HasColumnName("telephone");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.SaleCode)
                    .HasName("sales_pk");

                entity.ToTable("sales");

                entity.Property(e => e.SaleCode)
                    .HasColumnName("sale_code")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CodeRe).HasColumnName("code_re");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.ObjCode).HasColumnName("obj_code");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.CodeReNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CodeRe)
                    .HasConstraintName("sales_realtor_fk");

                entity.HasOne(d => d.ObjCodeNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ObjCode)
                    .HasConstraintName("sales_object_fk");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasKey(e => e.Codetype)
                    .HasName("тип_pk");

                entity.ToTable("Type");

                entity.Property(e => e.Codetype)
                    .HasColumnName("codetype")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Nametype)
                    .HasColumnType("character varying")
                    .HasColumnName("nametype");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
