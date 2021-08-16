﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreManager.Infrastructure.Context;

namespace StoreManager.Infrastructure.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FunctionUser", b =>
                {
                    b.Property<int>("FunctionsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("FunctionsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("FunctionUser");
                });

            modelBuilder.Entity("OptionVariant", b =>
                {
                    b.Property<int>("OptionsId")
                        .HasColumnType("int");

                    b.Property<int>("VariantsId")
                        .HasColumnType("int");

                    b.HasKey("OptionsId", "VariantsId");

                    b.HasIndex("VariantsId");

                    b.ToTable("OptionVariant");
                });

            modelBuilder.Entity("ProductVariant", b =>
                {
                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("VariantsId")
                        .HasColumnType("int");

                    b.HasKey("ProductsId", "VariantsId");

                    b.HasIndex("VariantsId");

                    b.ToTable("ProductVariant");
                });

            modelBuilder.Entity("StoreManager.Core.Auth.Function", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Admin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Functions");
                });

            modelBuilder.Entity("StoreManager.Core.Auth.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastAccess")
                        .HasColumnType("datetime2");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StoreManager.Core.Inventory.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("StoreManager.Core.Inventory.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("StoreManager.Core.Inventory.Variant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.ToTable("Variants");
                });

            modelBuilder.Entity("FunctionUser", b =>
                {
                    b.HasOne("StoreManager.Core.Auth.Function", null)
                        .WithMany()
                        .HasForeignKey("FunctionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreManager.Core.Auth.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OptionVariant", b =>
                {
                    b.HasOne("StoreManager.Core.Inventory.Option", null)
                        .WithMany()
                        .HasForeignKey("OptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreManager.Core.Inventory.Variant", null)
                        .WithMany()
                        .HasForeignKey("VariantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductVariant", b =>
                {
                    b.HasOne("StoreManager.Core.Inventory.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreManager.Core.Inventory.Variant", null)
                        .WithMany()
                        .HasForeignKey("VariantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoreManager.Core.Inventory.Option", b =>
                {
                    b.HasOne("StoreManager.Core.Inventory.Product", "Product")
                        .WithMany("Options")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("StoreManager.Core.Inventory.Product", b =>
                {
                    b.Navigation("Options");
                });
#pragma warning restore 612, 618
        }
    }
}
