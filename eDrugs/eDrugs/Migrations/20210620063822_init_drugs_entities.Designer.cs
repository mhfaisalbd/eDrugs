// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eDrugs.DbAccess;

namespace eDrugs.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210620063822_init_drugs_entities")]
    partial class init_drugs_entities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eDrugs.ApplicationCore.Drug", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BatchNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenericName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("eDrugs.ApplicationCore.DrugMfgInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DrugId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MfgDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Mrp")
                        .HasColumnType("float");

                    b.Property<int>("TypeOfDrugs")
                        .HasColumnType("int");

                    b.Property<string>("UnitAmount")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DrugId");

                    b.ToTable("DrugMfgInfos");
                });

            modelBuilder.Entity("eDrugs.ApplicationCore.DrugMfgInfo", b =>
                {
                    b.HasOne("eDrugs.ApplicationCore.Drug", "Drug")
                        .WithMany("DrugMfgInfos")
                        .HasForeignKey("DrugId");

                    b.Navigation("Drug");
                });

            modelBuilder.Entity("eDrugs.ApplicationCore.Drug", b =>
                {
                    b.Navigation("DrugMfgInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
