// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using the80by20.Modules.Solution.Infrastructure.EF;

#nullable disable

namespace the80by20.Modules.Solution.Infrastructure.EF.Migrations
{
    [DbContext(typeof(SolutionDbContext))]
    [Migration("20221109074654_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("solutions")
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("the80by20.Modules.Solution.App.ReadModel.SolutionToProblemReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRejected")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RequiredSolutionTypes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolutionElements")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolutionSummary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SolutionToProblemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("WorkingOnSolutionEnded")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("SolutionsToProblemsReadModel", "solutions");
                });

            modelBuilder.Entity("the80by20.Modules.Solution.Domain.Problem.Entities.ProblemAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Confirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("Rejected")
                        .HasColumnType("bit");

                    b.Property<string>("RequiredSolutionTypes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProblemsAggregates", "solutions");
                });

            modelBuilder.Entity("the80by20.Modules.Solution.Domain.Problem.Entities.ProblemCrudData", b =>
                {
                    b.Property<Guid>("AggregateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Category")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int");

                    b.HasKey("AggregateId");

                    b.ToTable("ProblemsCrudData", "solutions");
                });

            modelBuilder.Entity("the80by20.Modules.Solution.Domain.Solution.Entities.SolutionToProblemAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("AddtionalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("BasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("ProblemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RequiredSolutionTypes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolutionElements")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolutionSummary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("int");

                    b.Property<bool>("WorkingOnSolutionEnded")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("SolutionsToProblemsAggregates", "solutions");
                });
#pragma warning restore 612, 618
        }
    }
}
