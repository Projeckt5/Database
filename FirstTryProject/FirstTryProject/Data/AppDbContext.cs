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
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-SV4Q19DE;Initial Catalog=LokalTestDB;Integrated Security=True");
        } 

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
    