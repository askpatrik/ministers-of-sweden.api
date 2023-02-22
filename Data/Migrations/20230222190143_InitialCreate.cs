using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ministers_of_sweden.api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ministers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Born = table.Column<int>(type: "INTEGER", nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: true),
                    ImgUrl = table.Column<string>(type: "TEXT", nullable: true),
                    HasAcademicDegree = table.Column<bool>(type: "INTEGER", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    AcademicFieldId = table.Column<int>(type: "INTEGER", nullable: false),
                    UniversityDegreeId = table.Column<int>(type: "INTEGER", nullable: true),
                    PartyId = table.Column<int>(type: "INTEGER", nullable: false),
                    PartId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ministers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ministers_AcademicFields_UniversityDegreeId",
                        column: x => x.UniversityDegreeId,
                        principalTable: "AcademicFields",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ministers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ministers_Parties_PartId",
                        column: x => x.PartId,
                        principalTable: "Parties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ministers_DepartmentId",
                table: "Ministers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ministers_PartId",
                table: "Ministers",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Ministers_UniversityDegreeId",
                table: "Ministers",
                column: "UniversityDegreeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ministers");

            migrationBuilder.DropTable(
                name: "AcademicFields");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Parties");
        }
    }
}
