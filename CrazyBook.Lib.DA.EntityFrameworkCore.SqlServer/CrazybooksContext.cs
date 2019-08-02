using CrazyBooks.Lib.Core;
using CrazyBooks.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CrazyBook.Lib.DA
{
    public class CrazybooksContext : DbContext
    {
        public CrazybooksContext(DbContextOptions<CrazybooksContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Lend>()
            //    .HasOne(x => x.Member)
            //    .WithMany(x => x.Lends);

            //modelBuilder.Entity<Lend>()
            //    .HasOne(x => x.Book)
            //    .WithMany(x => x.Lends);

            //modelBuilder.Entity<Reservation>()
            //    .HasOne(x => x.Member)
            //    .WithMany(x => x.Reservations);

            //modelBuilder.Entity<Lend>()
            //    .HasOne(x => x.Book)
            //    .WithMany(x => x.Lends);

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Lend> Lends { get; set; }
        public DbSet<Reservation> Reservations { get; set; }        
    }
}
