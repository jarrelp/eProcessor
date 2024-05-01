﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ecmanage.eProcessor.Services.FakeFetch.API.Infrastructure;

#nullable disable

namespace Ecmanage.eProcessor.Services.FakeFetch.API.Migrations
{
    [DbContext(typeof(OracleTestDbContext))]
    partial class OracleTestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailQueue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmailTemplateId")
                        .HasColumnType("int");

                    b.Property<string>("XslName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmailTemplateId");

                    b.ToTable("EmailQueue", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 11502,
                            Email = "aangepast@email.adr",
                            EmailTemplateId = 1,
                            XslName = "LOGIN"
                        },
                        new
                        {
                            Id = 11503,
                            Email = "dizzel@dizzel.dizz",
                            EmailTemplateId = 2,
                            XslName = "LOGIN"
                        },
                        new
                        {
                            Id = 11504,
                            Email = "aangepast@email.adr",
                            EmailTemplateId = 7,
                            XslName = "OVERDUE"
                        },
                        new
                        {
                            Id = 11505,
                            Email = "dizzel@dizzel.dizz",
                            EmailTemplateId = 8,
                            XslName = "OVERDUE"
                        },
                        new
                        {
                            Id = 11506,
                            Email = "aangepast@email.adr",
                            EmailTemplateId = 5,
                            XslName = "REPORT"
                        },
                        new
                        {
                            Id = 11507,
                            Email = "dizzel@dizzel.dizz",
                            EmailTemplateId = 6,
                            XslName = "REPORT"
                        },
                        new
                        {
                            Id = 11508,
                            Email = "aangepast@email.adr",
                            EmailTemplateId = 3,
                            XslName = "USER"
                        },
                        new
                        {
                            Id = 11509,
                            Email = "dizzel@dizzel.dizz",
                            EmailTemplateId = 4,
                            XslName = "USER"
                        });
                });

            modelBuilder.Entity("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("EmailTemplate");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplates.Login", b =>
                {
                    b.HasBaseType("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplate");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Environment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Login", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = "2024-05-01",
                            Environment = "Production",
                            FullName = "John Doe",
                            Time = "15:35:22"
                        },
                        new
                        {
                            Id = 2,
                            Date = "2024-05-01",
                            Environment = "Production",
                            FullName = "Gerrit Janssen",
                            Time = "15:35:22"
                        });
                });

            modelBuilder.Entity("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplates.Overdue", b =>
                {
                    b.HasBaseType("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OverdueDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Overdue", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 7,
                            Email = "john.doe@example.com",
                            FullName = "John Doe",
                            OrderCode = "ORDER1",
                            OrderDate = "2024-04-24",
                            OverdueDate = "2024-05-01",
                            ProductName = "Product X",
                            ProductNumber = "PROD1"
                        },
                        new
                        {
                            Id = 8,
                            Email = "gerrit.janssen@example.com",
                            FullName = "Gerrit Janssen",
                            OrderCode = "ORDER2",
                            OrderDate = "2024-04-24",
                            OverdueDate = "2024-05-01",
                            ProductName = "Product Y",
                            ProductNumber = "PROD2"
                        });
                });

            modelBuilder.Entity("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplates.Report", b =>
                {
                    b.HasBaseType("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplate");

                    b.Property<string>("PortalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Report", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 5,
                            PortalName = "Portal X",
                            ReportName = "Monthly Sales Report",
                            Url = "http://example.com/reports/monthly-sales"
                        },
                        new
                        {
                            Id = 6,
                            PortalName = "Portal Y",
                            ReportName = "Monthly Sales Report",
                            Url = "http://example.com/reports/monthly-sales"
                        });
                });

            modelBuilder.Entity("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplates.User", b =>
                {
                    b.HasBaseType("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplate");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageHeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Company = "Example Company",
                            Email = "john.doe@example.com",
                            FullName = "John Doe",
                            ImageHeader = "header.jpg",
                            Password = "password123",
                            Url = "http://example.com",
                            UserName = "johndoe"
                        },
                        new
                        {
                            Id = 4,
                            Company = "Example Company",
                            Email = "gerrit.janssen@example.com",
                            FullName = "Gerrit Janssen",
                            ImageHeader = "header.jpg",
                            Password = "password123",
                            Url = "http://example.com",
                            UserName = "gerritjanssen"
                        });
                });

            modelBuilder.Entity("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailQueue", b =>
                {
                    b.HasOne("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplate", "EmailTemplate")
                        .WithMany()
                        .HasForeignKey("EmailTemplateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EmailTemplate");
                });

            modelBuilder.Entity("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplates.Login", b =>
                {
                    b.HasOne("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplate", null)
                        .WithOne()
                        .HasForeignKey("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplates.Login", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplates.Overdue", b =>
                {
                    b.HasOne("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplate", null)
                        .WithOne()
                        .HasForeignKey("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplates.Overdue", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplates.Report", b =>
                {
                    b.HasOne("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplate", null)
                        .WithOne()
                        .HasForeignKey("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplates.Report", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplates.User", b =>
                {
                    b.HasOne("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplate", null)
                        .WithOne()
                        .HasForeignKey("Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplates.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
