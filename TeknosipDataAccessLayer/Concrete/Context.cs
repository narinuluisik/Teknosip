using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TeknosipEntityLayer;
using TeknosipEntityLayer.Concrete;

namespace TeknosipDataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, string>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=NARIN\\SQLEXPRESS;initial catalog=TeknosipDb;integrated security=true");

        }

        public DbSet<Problem> Problems { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<DestekKurumu> DestekKurumlari { get; set; }
        public DbSet<DestekTalebi> DestekTalepleri { get; set; }
        public DbSet<Cozum> Cozums { get; set; }
  

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Sector>()
                .HasMany(s => s.Problems)
                .WithOne(p => p.Sector)
                .HasForeignKey(p => p.SectorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Problem>()
                .HasOne(p => p.AppUser)
                .WithMany(u => u.Problems)
                .HasForeignKey(p => p.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

          






        }


    }

}
