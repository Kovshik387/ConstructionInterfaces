﻿// <auto-generated />
using System;
using ClientsProject.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClientsProject.DAL.Migrations
{
    [DbContext(typeof(ClientAccountingContext))]
    [Migration("20231110221125_Price")]
    partial class Price
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ClientsProject.DAL.Entities.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_client");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdClient"));

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)")
                        .HasColumnName("contact");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("email");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("login");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("password");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("patronymic");

                    b.Property<int?>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("surname");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdClient")
                        .HasName("clients_pkey");

                    b.HasIndex(new[] { "Login" }, "clients_login_key")
                        .IsUnique();

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("ClientsProject.DAL.Entities.Order", b =>
                {
                    b.Property<int>("Idorder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("idorder");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Idorder"));

                    b.Property<int?>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<DateOnly?>("Daterelease")
                        .HasColumnType("date")
                        .HasColumnName("daterelease");

                    b.Property<int>("IdClient")
                        .HasColumnType("integer")
                        .HasColumnName("id_client");

                    b.Property<int>("IdProduct")
                        .HasColumnType("integer")
                        .HasColumnName("id_product");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Idorder")
                        .HasName("orders_pkey");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdProduct");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("ClientsProject.DAL.Entities.Product", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_product");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdProduct"));

                    b.Property<int?>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<DateOnly?>("Daterelease")
                        .HasColumnType("date")
                        .HasColumnName("daterelease");

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("name");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("bytea")
                        .HasColumnName("photo");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("IdProduct")
                        .HasName("product_pkey");

                    b.ToTable("product", (string)null);
                });

            modelBuilder.Entity("ClientsProject.DAL.Entities.Review", b =>
                {
                    b.Property<int>("IdReview")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_review");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdReview"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int>("IdClient")
                        .HasColumnType("integer")
                        .HasColumnName("id_client");

                    b.Property<int?>("IdProduct")
                        .HasColumnType("integer")
                        .HasColumnName("id_product");

                    b.Property<bool?>("Ishelpful")
                        .HasColumnType("boolean")
                        .HasColumnName("ishelpful");

                    b.Property<string>("Message")
                        .HasColumnType("text")
                        .HasColumnName("message");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.HasKey("IdReview")
                        .HasName("review_pkey");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdProduct");

                    b.ToTable("review", (string)null);
                });

            modelBuilder.Entity("ClientsProject.DAL.Entities.Order", b =>
                {
                    b.HasOne("ClientsProject.DAL.Entities.Client", "IdClientNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdClient")
                        .IsRequired()
                        .HasConstraintName("orders_id_client_fkey");

                    b.HasOne("ClientsProject.DAL.Entities.Product", "IdProductNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdProduct")
                        .IsRequired()
                        .HasConstraintName("orders_id_product_fkey");

                    b.Navigation("IdClientNavigation");

                    b.Navigation("IdProductNavigation");
                });

            modelBuilder.Entity("ClientsProject.DAL.Entities.Review", b =>
                {
                    b.HasOne("ClientsProject.DAL.Entities.Client", "IdClientNavigation")
                        .WithMany("Reviews")
                        .HasForeignKey("IdClient")
                        .IsRequired()
                        .HasConstraintName("review_id_client_fkey");

                    b.HasOne("ClientsProject.DAL.Entities.Product", "IdProductNavigation")
                        .WithMany("Reviews")
                        .HasForeignKey("IdProduct")
                        .HasConstraintName("review_id_product_fkey");

                    b.Navigation("IdClientNavigation");

                    b.Navigation("IdProductNavigation");
                });

            modelBuilder.Entity("ClientsProject.DAL.Entities.Client", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("ClientsProject.DAL.Entities.Product", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}