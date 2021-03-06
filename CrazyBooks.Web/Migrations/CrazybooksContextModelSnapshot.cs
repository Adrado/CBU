﻿// <auto-generated />
using System;
using CrazyBook.Lib.DA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrazyBooks.Web.Migrations
{
    [DbContext(typeof(CrazybooksContext))]
    partial class CrazybooksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CrazyBooks.Lib.Core.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Surname1");

                    b.Property<string>("Surname2");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("CrazyBooks.Lib.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<int>("Edition");

                    b.Property<string>("Title");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("CrazyBooks.Lib.Models.Lend", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BookId");

                    b.Property<Guid>("MemberId");

                    b.Property<Guid?>("RoomId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("MemberId");

                    b.HasIndex("RoomId");

                    b.ToTable("Lends");
                });

            modelBuilder.Entity("CrazyBooks.Lib.Models.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndsOn");

                    b.Property<Guid>("MemberId");

                    b.Property<Guid>("RoomId");

                    b.Property<DateTime>("StartsOn");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("RoomId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("CrazyBooks.Lib.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacity");

                    b.Property<string>("Code");

                    b.Property<bool>("IsAdapted");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("CrazyBooks.Lib.Models.Admin", b =>
                {
                    b.HasBaseType("CrazyBooks.Lib.Core.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("CrazyBooks.Lib.Models.Member", b =>
                {
                    b.HasBaseType("CrazyBooks.Lib.Core.User");

                    b.HasDiscriminator().HasValue("Member");
                });

            modelBuilder.Entity("CrazyBooks.Lib.Models.Lend", b =>
                {
                    b.HasOne("CrazyBooks.Lib.Models.Book", "Book")
                        .WithMany("Lends")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CrazyBooks.Lib.Models.Member", "Member")
                        .WithMany("Lends")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CrazyBooks.Lib.Models.Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("CrazyBooks.Lib.Models.Reservation", b =>
                {
                    b.HasOne("CrazyBooks.Lib.Models.Member", "Member")
                        .WithMany("Reservations")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CrazyBooks.Lib.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
