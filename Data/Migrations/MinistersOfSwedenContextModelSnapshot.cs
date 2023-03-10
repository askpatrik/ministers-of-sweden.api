// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ministers_of_sweden.api.Data;

#nullable disable

namespace ministers_of_sweden.api.Data.Migrations
{
    [DbContext(typeof(MinistersOfSwedenContext))]
    partial class MinistersOfSwedenContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("ministers_of_sweden.api.Entities.AcademicField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AcademicFields");
                });

            modelBuilder.Entity("ministers_of_sweden.api.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ministers_of_sweden.api.Entities.Minister", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AcademicFieldId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Born")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasAcademicDegree")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("PartyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sex")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AcademicFieldId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("PartyId");

                    b.ToTable("Ministers");
                });

            modelBuilder.Entity("ministers_of_sweden.api.Entities.Party", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Parties");
                });

            modelBuilder.Entity("ministers_of_sweden.api.Entities.Minister", b =>
                {
                    b.HasOne("ministers_of_sweden.api.Entities.AcademicField", "academicField")
                        .WithMany("Ministers")
                        .HasForeignKey("AcademicFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ministers_of_sweden.api.Entities.Department", "department")
                        .WithMany("Ministers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ministers_of_sweden.api.Entities.Party", "party")
                        .WithMany("Ministers")
                        .HasForeignKey("PartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("academicField");

                    b.Navigation("department");

                    b.Navigation("party");
                });

            modelBuilder.Entity("ministers_of_sweden.api.Entities.AcademicField", b =>
                {
                    b.Navigation("Ministers");
                });

            modelBuilder.Entity("ministers_of_sweden.api.Entities.Department", b =>
                {
                    b.Navigation("Ministers");
                });

            modelBuilder.Entity("ministers_of_sweden.api.Entities.Party", b =>
                {
                    b.Navigation("Ministers");
                });
#pragma warning restore 612, 618
        }
    }
}
