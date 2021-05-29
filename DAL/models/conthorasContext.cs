using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.models
{
    public partial class conthorasContext : DbContext
    {
        public conthorasContext()
        {
        }

        public conthorasContext(DbContextOptions<conthorasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cabhoras> Cabhoras { get; set; }
        public virtual DbSet<Daily> Daily { get; set; }
        public virtual DbSet<Linhoras> Linhoras { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserProject> UserProject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;uid=usuario_hibernate;pwd=1234;database=conthoras", x => x.ServerVersion("8.0.21-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cabhoras>(entity =>
            {
                entity.ToTable("cabhoras");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.HasIndex(e => e.Iduser)
                    .HasName("iduser");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datecab)
                    .HasColumnName("datecab")
                    .HasColumnType("date");

                entity.Property(e => e.Iduser)
                    .HasColumnName("iduser")
                    .HasColumnType("varchar(36)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Cabhoras)
                    .HasForeignKey(d => d.Iduser)
                    .HasConstraintName("cabhoras_ibfk_1");
            });

            modelBuilder.Entity<Daily>(entity =>
            {
                entity.ToTable("daily");

                entity.HasIndex(e => e.Dailyid)
                    .HasName("dailyid")
                    .IsUnique();

                entity.HasIndex(e => e.Dailyuser)
                    .HasName("dailyuser");

                entity.Property(e => e.Dailyid)
                    .HasColumnName("dailyid")
                    .HasColumnType("varchar(36)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Dailyinout)
                    .HasColumnName("dailyinout")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dailytype)
                    .HasColumnName("dailytype")
                    .HasColumnType("varchar(1)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Dailyuser)
                    .HasColumnName("dailyuser")
                    .HasColumnType("varchar(36)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.DailyuserNavigation)
                    .WithMany(p => p.Daily)
                    .HasForeignKey(d => d.Dailyuser)
                    .HasConstraintName("daily_ibfk_1");
            });

            modelBuilder.Entity<Linhoras>(entity =>
            {
                entity.HasKey(e => new { e.Idlin, e.Idcab })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("linhoras");

                entity.HasIndex(e => e.Idcab)
                    .HasName("idcab");

                entity.Property(e => e.Idlin)
                    .HasColumnName("idlin")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idcab).HasColumnName("idcab");

                entity.Property(e => e.Firsttime)
                    .HasColumnName("firsttime")
                    .HasColumnType("time");

                entity.Property(e => e.Idproject).HasColumnName("idproject");

                entity.Property(e => e.Lasttime)
                    .HasColumnName("lasttime")
                    .HasColumnType("time");

                entity.HasOne(d => d.IdcabNavigation)
                    .WithMany(p => p.Linhoras)
                    .HasForeignKey(d => d.Idcab)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("linhoras_ibfk_1");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => e.Sessid)
                    .HasName("PRIMARY");

                entity.ToTable("session");

                entity.HasIndex(e => e.Sessid)
                    .HasName("sessid")
                    .IsUnique();

                entity.HasIndex(e => e.Sessuser)
                    .HasName("sessuser");

                entity.Property(e => e.Sessid)
                    .HasColumnName("sessid")
                    .HasColumnType("varchar(36)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Sessend)
                    .HasColumnName("sessend")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sesstart)
                    .HasColumnName("sesstart")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sesstoken)
                    .HasColumnName("sesstoken")
                    .HasColumnType("varchar(1024)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Sessuser)
                    .HasColumnName("sessuser")
                    .HasColumnType("varchar(36)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.SessuserNavigation)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.Sessuser)
                    .HasConstraintName("session_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Id)
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("varchar(36)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FirstLogin)
                    .HasColumnName("first_login")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastLogin)
                    .HasColumnName("last_login")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nick)
                    .HasColumnName("nick")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Rol)
                    .HasColumnName("rol")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Surname)
                    .HasColumnName("surname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<UserProject>(entity =>
            {
                entity.HasKey(e => new { e.Iduser, e.Idproject })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("user_project");

                entity.HasIndex(e => e.Idproject)
                    .HasName("idproject");

                entity.Property(e => e.Iduser)
                    .HasColumnName("iduser")
                    .HasColumnType("varchar(36)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Idproject).HasColumnName("idproject");

                entity.HasOne(d => d.IdprojectNavigation)
                    .WithMany(p => p.UserProject)
                    .HasForeignKey(d => d.Idproject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_project_ibfk_2");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.UserProject)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_project_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
