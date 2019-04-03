using System;
using System.Collections.Generic;
using System.Text;
using FirstTryProject.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstTryProject.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:mowinckel.database.windows.net,1433;Initial Catalog=CarnGo;Persist Security Info=False;User ID={50a5b9da-dcfc-436f-85f0-c4cc254f3692};Password={Vores1.sødedatabase};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
        }
        // Server=tcp:mowinckel.database.windows.net,1433;Initial Catalog=CarnGo;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
        // Data Source=LAPTOP-SV4Q19DE;Initial Catalog=LokalTestDB;Integrated Security=True

        public DbSet<Lejer> Lejere { get; set; }
        public DbSet<LejerBesked> LejerBeskeder { get; set; }
        public DbSet<Udlejer> Udlejere { get; set; }
        public DbSet<UdlejerBesked> UdlejerBeskeder { get; set; }
        public DbSet<Bil> Biler { get; set; }
        public DbSet<UdlejetDag> UdlejedeDage { get; set; }
        public DbSet<KanUdlejesDato> KanUdlejesDatoer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KanUdlejesDato>()
                .HasOne(p => p.Bil)
                .WithMany(b => b.KanUdlejesDatoer);

            modelBuilder.Entity<UdlejetDag>()
                .HasOne(p => p.Bil)
                .WithMany(b => b.UdlejetDage);

            modelBuilder.Entity<Bil>()
                .HasOne(p => p.Lejer)
                .WithMany(b => b.Biler);

            modelBuilder.Entity<Bil>()
                .HasOne(p => p.Udlejer)
                .WithMany(b => b.Biler);

            modelBuilder.Entity<LejerBesked>()
                .HasOne(p => p.Lejer)
                .WithMany(b => b.LejerBeskeder);

            modelBuilder.Entity<UdlejerBesked>()
                .HasOne(p => p.Udlejer)
                .WithMany(b => b.UdlejerBeskeder);



        }
    }
}
    