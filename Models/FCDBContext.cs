using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Simple_Food_Delivery.Services;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Simple_Food_Delivery.Models
{
    public partial class FCDBContext : DbContext
    {
        public FCDBContext()
        {
        }

        public FCDBContext(DbContextOptions<FCDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActionTypes> ActionTypes { get; set; }
        public virtual DbSet<Actions> Actions { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersCompositions> OrdersCompositions { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                
                optionsBuilder.UseSqlServer("Server=PC1;Database=FCDB;Trusted_Connection=True;TrustServerCertificate=Yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionTypes>(entity =>
            {
                entity.HasKey(e => e.ActionTypeId)
                    .HasName("PK__ActionTy__62FE4C04F634D758");

                entity.Property(e => e.ActionTypeId)
                    .HasColumnName("ActionTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActionTitle)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Actions>(entity =>
            {
                entity.HasKey(e => e.ActionId)
                    .HasName("PK__Actions__FFE3F4B978A4AEF6");

                entity.Property(e => e.ActionId).HasColumnName("ActionID");

                entity.Property(e => e.ActionTypeId).HasColumnName("ActionTypeID");

                entity.Property(e => e.DateOfAction).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.ActionType)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.ActionTypeId)
                    .HasConstraintName("FK__Actions__ActionT__44FF419A");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.CartActionId)
                    .HasName("PK__Cart__2907B000E7A1F29A");

                entity.Property(e => e.CartActionId).HasColumnName("CartActionID");

                entity.Property(e => e.FoodImage)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FoodPrice).HasColumnType("money");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_Order_Id");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CourierId).HasColumnName("CourierID");

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.FinalPrice).HasColumnType("money");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.UserAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Courier)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CourierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__CourierI__47DBAE45");

                entity.HasOne(d => d.OrderStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__OrderSta__49C3F6B7");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__UserID__48CFD27E");
            });

            modelBuilder.Entity<OrdersCompositions>(entity =>
            {
                entity.HasKey(e => e.UselessColumn)
                    .HasName("PK__OrdersCo__ADB3555C13006B7D");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Product)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrdersCompositions)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrdersCom__Order__6754599E");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(e => e.ProductTypeId)
                    .HasColumnName("ProductTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__B40CC6ED7821670C");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductDesc).IsRequired();

                entity.Property(e => e.ProductImage).IsRequired();

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__Produc__72C60C4A");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__Roles__8AFACE3A0017DD6E");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleDescription)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RoleTitle)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CCAC49816837");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserLastName).HasMaxLength(50);

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserPhone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserSurName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Workers>(entity =>
            {
                entity.HasKey(e => e.WorkerId)
                    .HasName("PK__Workers__077C8806BE0BF349");

                entity.Property(e => e.WorkerId).HasColumnName("WorkerID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.StartWork).HasColumnType("datetime");

                entity.Property(e => e.WorkerAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WorkerEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WorkerLastName).HasMaxLength(50);

                entity.Property(e => e.WorkerLogin)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WorkerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WorkerPassword)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WorkerPhone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WorkerSurName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Workers__RoleID__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
