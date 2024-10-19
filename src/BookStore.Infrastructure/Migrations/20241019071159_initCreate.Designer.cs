﻿// <auto-generated />
using System;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStore.Infrastructure.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    [Migration("20241019071159_initCreate")]
    partial class initCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookCategory", b =>
                {
                    b.Property<long>("BookId")
                        .HasColumnType("bigint")
                        .HasColumnName("book_id");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("category_id");

                    b.HasKey("BookId", "CategoryId")
                        .HasName("PK__book_cat__1459F47AF53B586B");

                    b.HasIndex("CategoryId");

                    b.ToTable("book_categories", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("author");

                    b.Property<string>("DetailDesc")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("detail_desc");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("discount");

                    b.Property<string>("Factory")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("factory");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint")
                        .HasColumnName("quantity");

                    b.Property<string>("ShortDesc")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("short_desc");

                    b.Property<long?>("Sold")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L)
                        .HasColumnName("sold");

                    b.HasKey("Id")
                        .HasName("PK__books__3213E83FB46B716A");

                    b.ToTable("books", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Cart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("Sum")
                        .HasColumnType("int")
                        .HasColumnName("sum");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PK__carts__3213E83F78ED2A57");

                    b.HasIndex("UserId");

                    b.ToTable("carts", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Entities.CartDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("BookId")
                        .HasColumnType("bigint")
                        .HasColumnName("book_id");

                    b.Property<long>("CartId")
                        .HasColumnType("bigint")
                        .HasColumnName("cart_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("PK__cart_det__3213E83F6409673C");

                    b.HasIndex("BookId");

                    b.HasIndex("CartId");

                    b.ToTable("cart_detail", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK__categori__3213E83FE423EA6F");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Customer", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<long?>("Points")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L)
                        .HasColumnName("points");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PK__customer__3213E83FA96F4118");

                    b.HasIndex(new[] { "UserId" }, "UQ__customer__B9BE370E06240819")
                        .IsUnique()
                        .HasFilter("[user_id] IS NOT NULL");

                    b.ToTable("customers", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Employee", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth_date");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("gender");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("position");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("PK__employee__3213E83F96F2727D");

                    b.HasIndex(new[] { "UserId" }, "UQ__employee__B9BE370EE42C34DB")
                        .IsUnique()
                        .HasFilter("[user_id] IS NOT NULL");

                    b.ToTable("employees", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint")
                        .HasColumnName("customer_id");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint")
                        .HasColumnName("employee_id");

                    b.Property<DateTime?>("OrderDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("order_date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("total_price");

                    b.HasKey("Id")
                        .HasName("PK__orders__3213E83FF633A05F");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Entities.OrderDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("BookId")
                        .HasColumnType("bigint")
                        .HasColumnName("book_id");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint")
                        .HasColumnName("order_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("PK__order_de__3213E83F8211B8D1");

                    b.HasIndex("BookId");

                    b.HasIndex("OrderId");

                    b.ToTable("order_detail", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK__roles__3213E83F29EBD87B");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Entities.StockImport", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint")
                        .HasColumnName("employee_id");

                    b.Property<DateTime?>("ImportDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("import_date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<long>("SupplierId")
                        .HasColumnType("bigint")
                        .HasColumnName("supplier_id");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("total_cost");

                    b.HasKey("Id")
                        .HasName("PK__stock_im__3213E83F2D75BE0C");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SupplierId");

                    b.ToTable("stock_imports", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Entities.StockImportDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("BookId")
                        .HasColumnType("bigint")
                        .HasColumnName("book_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint")
                        .HasColumnName("quantity");

                    b.Property<long>("StockImportId")
                        .HasColumnType("bigint")
                        .HasColumnName("stock_import_id");

                    b.HasKey("Id")
                        .HasName("PK__stock_im__3213E83FB3C74451");

                    b.HasIndex("BookId");

                    b.HasIndex("StockImportId");

                    b.ToTable("stock_import_details", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Supplier", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("address");

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("contact_email");

                    b.Property<string>("ContactPhone")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("contact_phone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK__supplier__3213E83FC1B8A092");

                    b.ToTable("suppliers", (string)null);
                });

            modelBuilder.Entity("BookStore.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("address");

                    b.Property<string>("Avatar")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("avatar");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("full_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("phone");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("PK__users__3213E83FC7AEE2AD");

                    b.HasIndex("RoleId");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("BookCategory", b =>
                {
                    b.HasOne("BookStore.Domain.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .IsRequired()
                        .HasConstraintName("FK__book_cate__book___6D0D32F4");

                    b.HasOne("BookStore.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK__book_cate__categ__6E01572D");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Cart", b =>
                {
                    b.HasOne("BookStore.Domain.Entities.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__carts__user_id__5EBF139D");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.CartDetail", b =>
                {
                    b.HasOne("BookStore.Domain.Entities.Book", "Book")
                        .WithMany("CartDetails")
                        .HasForeignKey("BookId")
                        .IsRequired()
                        .HasConstraintName("FK__cart_deta__book___628FA481");

                    b.HasOne("BookStore.Domain.Entities.Cart", "Cart")
                        .WithMany("CartDetails")
                        .HasForeignKey("CartId")
                        .IsRequired()
                        .HasConstraintName("FK__cart_deta__cart___619B8048");

                    b.Navigation("Book");

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Customer", b =>
                {
                    b.HasOne("BookStore.Domain.Entities.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("BookStore.Domain.Entities.Customer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__customers__user___5070F446");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Employee", b =>
                {
                    b.HasOne("BookStore.Domain.Entities.User", "User")
                        .WithOne("Employee")
                        .HasForeignKey("BookStore.Domain.Entities.Employee", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__employees__user___5441852A");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Order", b =>
                {
                    b.HasOne("BookStore.Domain.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK__orders__customer__5AEE82B9");

                    b.HasOne("BookStore.Domain.Entities.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__orders__employee__5BE2A6F2");

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.OrderDetail", b =>
                {
                    b.HasOne("BookStore.Domain.Entities.Book", "Book")
                        .WithMany("OrderDetails")
                        .HasForeignKey("BookId")
                        .IsRequired()
                        .HasConstraintName("FK__order_det__book___66603565");

                    b.HasOne("BookStore.Domain.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK__order_det__order__656C112C");

                    b.Navigation("Book");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.StockImport", b =>
                {
                    b.HasOne("BookStore.Domain.Entities.Employee", "Employee")
                        .WithMany("StockImports")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__stock_imp__emplo__72C60C4A");

                    b.HasOne("BookStore.Domain.Entities.Supplier", "Supplier")
                        .WithMany("StockImports")
                        .HasForeignKey("SupplierId")
                        .IsRequired()
                        .HasConstraintName("FK__stock_imp__suppl__71D1E811");

                    b.Navigation("Employee");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.StockImportDetail", b =>
                {
                    b.HasOne("BookStore.Domain.Entities.Book", "Book")
                        .WithMany("StockImportDetails")
                        .HasForeignKey("BookId")
                        .IsRequired()
                        .HasConstraintName("FK__stock_imp__book___76969D2E");

                    b.HasOne("BookStore.Domain.Entities.StockImport", "StockImport")
                        .WithMany("StockImportDetails")
                        .HasForeignKey("StockImportId")
                        .IsRequired()
                        .HasConstraintName("FK__stock_imp__stock__75A278F5");

                    b.Navigation("Book");

                    b.Navigation("StockImport");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.User", b =>
                {
                    b.HasOne("BookStore.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK__users__role_id__4BAC3F29");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Book", b =>
                {
                    b.Navigation("CartDetails");

                    b.Navigation("OrderDetails");

                    b.Navigation("StockImportDetails");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Cart", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("StockImports");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.StockImport", b =>
                {
                    b.Navigation("StockImportDetails");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Supplier", b =>
                {
                    b.Navigation("StockImports");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.User", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}