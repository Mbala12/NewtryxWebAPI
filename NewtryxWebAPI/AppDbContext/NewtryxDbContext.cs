using Microsoft.EntityFrameworkCore;
using NewtryxWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtryxWebAPI.AppDbContext
{
    public class NewtryxDbContext: DbContext
    {
        public NewtryxDbContext(DbContextOptions<NewtryxDbContext> options):
                    base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One-to-Many Relationship between Item(1) and OrderDetail(1..*)
            modelBuilder.Entity<Item>().HasKey(x => x.ItemId);
            modelBuilder.Entity<OrderDetail>().HasKey(x => x.OrderDetailId);
            modelBuilder.Entity<OrderDetail>()
                     .HasOne(x => x.Item)
                     .WithMany(x => x.OrderDetails)
                     .HasForeignKey(x => x.ItemId)
                     .OnDelete(DeleteBehavior.Restrict);

            //One-to-Many Relationship between Restaurant(1) and Reservation(1..*)
            modelBuilder.Entity<Restaurant>().HasKey(x => x.RestaurantId);
            modelBuilder.Entity<Reservation>().HasKey(x => x.ReservationId);
            modelBuilder.Entity<Reservation>()
                     .HasOne(x => x.Restaurant)
                     .WithMany(x => x.Reservations)
                     .HasForeignKey(x => x.RestaurantId)
                     .OnDelete(DeleteBehavior.Restrict);

            //One-to-Many Relationship between User(1) and Reservation(1..*)
            modelBuilder.Entity<User>().HasKey(x => x.UserId);
            modelBuilder.Entity<Reservation>().HasKey(x => x.ReservationId);
            modelBuilder.Entity<Reservation>()
                     .HasOne(x => x.User)
                     .WithMany(x => x.Reservations)
                     .HasForeignKey(x => x.UserId)
                     .OnDelete(DeleteBehavior.Restrict);

            //One-to-Many Relationship between Order(1) and OrderDetail(1..*)
            modelBuilder.Entity<Order>().HasKey(x => x.OrderId);
            modelBuilder.Entity<OrderDetail>().HasKey(x => x.OrderDetailId);
            modelBuilder.Entity<OrderDetail>()
                     .HasOne(x => x.Order)
                     .WithMany(x => x.OrderDetails)
                     .HasForeignKey(x => x.OrderId)
                     .OnDelete(DeleteBehavior.Restrict);

            //One-to-Many Relationship between OrderDetail(1..*) and Reservation(1)
            modelBuilder.Entity<OrderDetail>().HasKey(x => x.OrderDetailId);
            modelBuilder.Entity<Reservation>().HasKey(x => x.ReservationId);
            modelBuilder.Entity<OrderDetail>()
                     .HasOne(x => x.Reservation)
                     .WithMany(x => x.OrderDetails)
                     .HasForeignKey(x => x.ReservationId)
                     .OnDelete(DeleteBehavior.Restrict);

            //One-to-Many Relationship between ReservationStatus(1) and Reservation(1..*)
            modelBuilder.Entity<ReservationStatus>().HasKey(x => x.ReservationStatusId);
            modelBuilder.Entity<Reservation>().HasKey(x => x.ReservationId);
            modelBuilder.Entity<Reservation>()
                     .HasOne(x => x.ReservationStatus)
                     .WithMany(x => x.Reservations)
                     .HasForeignKey(x => x.ReservationStatusId)
                     .OnDelete(DeleteBehavior.Restrict);

            //Specification of the Column Type Decimal for every Entity column in SQL Server
            modelBuilder.Entity<Item>().Property(x => x.ItemPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<OrderDetail>().Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<OrderDetail>().Property(x => x.SubTotal).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Order>().Property(x => x.FinalTotal).HasColumnType("decimal(18,2)");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<ReservationStatus> ReservationStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
