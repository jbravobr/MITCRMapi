using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GenerateDatabase;

namespace GenerateDatabase.Migrations
{
    [DbContext(typeof(CRMContext))]
    [Migration("20160929022646_alter_Customer_add_Password")]
    partial class alter_Customer_add_Password
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GenerateDatabase.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Burgh")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 120);

                    b.Property<DateTimeOffset>("DtLastUpdate");

                    b.Property<int>("Number");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 150);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 9);

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("GenerateDatabase.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 13);

                    b.Property<DateTimeOffset>("DtLastUpdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("GenerateDatabase.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressId");

                    b.Property<DateTimeOffset>("DtLastUpdate");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 80);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 80);

                    b.Property<decimal>("LastOrderAmout");

                    b.Property<string>("Password");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("GenerateDatabase.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<int>("CustomerId");

                    b.Property<decimal>("Discount");

                    b.Property<DateTimeOffset>("DtLastUpdate");

                    b.Property<int>("PaymentType");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("GenerateDatabase.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<DateTimeOffset>("DtLastUpdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 80);

                    b.Property<int?>("OrderId");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("OrderId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("GenerateDatabase.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DtLastUpdate");

                    b.Property<string>("Name");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("GenerateDatabase.StockProduct", b =>
                {
                    b.Property<int>("StockId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Amount");

                    b.HasKey("StockId", "ProductId");

                    b.HasIndex("ProductId");

                    b.HasIndex("StockId");

                    b.ToTable("StockProduct");
                });

            modelBuilder.Entity("GenerateDatabase.Company", b =>
                {
                    b.HasOne("GenerateDatabase.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GenerateDatabase.Customer", b =>
                {
                    b.HasOne("GenerateDatabase.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("GenerateDatabase.Order", b =>
                {
                    b.HasOne("GenerateDatabase.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GenerateDatabase.Product", b =>
                {
                    b.HasOne("GenerateDatabase.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GenerateDatabase.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("GenerateDatabase.StockProduct", b =>
                {
                    b.HasOne("GenerateDatabase.Product", "Product")
                        .WithMany("StockProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GenerateDatabase.Stock", "Stock")
                        .WithMany("StockProducts")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
