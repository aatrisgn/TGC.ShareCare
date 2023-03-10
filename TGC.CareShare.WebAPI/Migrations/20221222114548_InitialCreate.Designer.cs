// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TGC.CareShare.WebAPI.Repositories;

#nullable disable

namespace TGC.CareShare.WebAPI.Migrations
{
    [DbContext(typeof(CareShareDBContext))]
    [Migration("20221222114548_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TGC.CareShare.WebAPI.Models.DataModels.Expense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ExpenseGroupMemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastEdited")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseGroupMemberId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("TGC.CareShare.WebAPI.Models.DataModels.ExpenseGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastEdited")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("ExpenseGroups");
                });

            modelBuilder.Entity("TGC.CareShare.WebAPI.Models.DataModels.ExpenseGroupMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<decimal>("Balance")
                        .HasColumnType("money");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ExpenseGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastEdited")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Paid")
                        .HasColumnType("money");

                    b.Property<Guid?>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseGroupId");

                    b.HasIndex("ProfileId");

                    b.ToTable("ExpenseGroupMembers");
                });

            modelBuilder.Entity("TGC.CareShare.WebAPI.Models.DataModels.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastEdited")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("TGC.CareShare.WebAPI.Models.DataModels.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<Guid>("AzureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GivenName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastEdited")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TGC.CareShare.WebAPI.Models.DataModels.Expense", b =>
                {
                    b.HasOne("TGC.CareShare.WebAPI.Models.DataModels.ExpenseGroupMember", null)
                        .WithMany("Expenses")
                        .HasForeignKey("ExpenseGroupMemberId");
                });

            modelBuilder.Entity("TGC.CareShare.WebAPI.Models.DataModels.ExpenseGroupMember", b =>
                {
                    b.HasOne("TGC.CareShare.WebAPI.Models.DataModels.ExpenseGroup", null)
                        .WithMany("ExpenseGroupMembers")
                        .HasForeignKey("ExpenseGroupId");

                    b.HasOne("TGC.CareShare.WebAPI.Models.DataModels.Profile", null)
                        .WithMany("Memberships")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("TGC.CareShare.WebAPI.Models.DataModels.Profile", b =>
                {
                    b.HasOne("TGC.CareShare.WebAPI.Models.DataModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TGC.CareShare.WebAPI.Models.DataModels.ExpenseGroup", b =>
                {
                    b.Navigation("ExpenseGroupMembers");
                });

            modelBuilder.Entity("TGC.CareShare.WebAPI.Models.DataModels.ExpenseGroupMember", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("TGC.CareShare.WebAPI.Models.DataModels.Profile", b =>
                {
                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
