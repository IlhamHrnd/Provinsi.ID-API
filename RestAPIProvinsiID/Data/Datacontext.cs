using Microsoft.EntityFrameworkCore;
using RestAPIProvinsiID.Models;
//using RestAPIProvinsiID.Models;

namespace RestAPIProvinsiID.Data
{
    public partial class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options)
            : base(options)
        {

        }

        public virtual DbSet<UserModel> User { get; set; } = null!;
        public virtual DbSet<AksesModel> Akses { get; set; } = null!;
        public virtual DbSet<StatusModel> Status { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=DatabaseConnection", ServerVersion.Parse("10.5.15-mariadb"));
            }
        }

        /*public virtual DbSet<AksesModel> Akses { get; set; } = null!;
        public virtual DbSet<UserModel> User { get; set; } = null!;
        public virtual DbSet<StatusModel> Status { get; set; } = null!;
        public virtual DbSet<AnggotaModel> Anggota { get; set; } = null!;
        public virtual DbSet<GenderModel> Gender { get; set; } = null!;
        public virtual DbSet<JobModel> Pekerjaan { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=DatabaseConnection", ServerVersion.Parse("10.5.15-mariadb"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("User");
            modelBuilder.Entity<StatusModel>().ToTable("Status");
            modelBuilder.Entity<AksesModel>().ToTable("Akses");
            modelBuilder.Entity<GenderModel>().ToTable("Gender");
            modelBuilder.Entity<JobModel>().ToTable("Pekerjaan");
            modelBuilder.Entity<AnggotaModel>().ToTable("Anggota");

            //Foreign key ke table Akses dari table User
            modelBuilder.Entity<UserModel>()
                .HasOne(u => u._akses)
                .WithOne(u => u._user)
                .HasForeignKey<AksesModel>(u => u.Id);

            modelBuilder.Entity<AksesModel>()
                .HasOne(a => a._user)
                .WithOne(a => a._akses)
                .HasForeignKey<UserModel>(a => a.Akses);

            //Foreign key ke table Status dari table User
            modelBuilder.Entity<UserModel>()
                .HasOne(u => u._status)
                .WithOne(u => u._user)
                .HasForeignKey<StatusModel>(u => u.Id);

            modelBuilder.Entity<StatusModel>()
                .HasOne(s => s._user)
                .WithOne(s => s._status)
                .HasForeignKey<UserModel>(s => s.Status);

            //Foreign key ke table Gender dari table Anggota
            modelBuilder.Entity<AnggotaModel>()
                .HasOne(a => a._gender)
                .WithOne(a => a._anggota)
                .HasForeignKey<GenderModel>(a => a.Id);

            modelBuilder.Entity<GenderModel>()
                .HasOne(g => g._anggota)
                .WithOne(g => g._gender)
                .HasForeignKey<AnggotaModel>(g => g.JenisKelamin);

            //Foreign key ke table Pekerjaan dari table Anggota
            modelBuilder.Entity<AnggotaModel>()
                .HasOne(a => a._job)
                .WithOne(a => a._anggota)
                .HasForeignKey<JobModel>(a => a.Id);

            modelBuilder.Entity<JobModel>()
                .HasOne(j => j._anggota)
                .WithOne(j => j._job)
                .HasForeignKey<AnggotaModel>(j => j.Pekerjaan);
        }*/
    }
}
