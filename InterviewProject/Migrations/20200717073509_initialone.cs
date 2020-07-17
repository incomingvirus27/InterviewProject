using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InterviewProject.Migrations
{
    public partial class initialone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatchTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Batch = table.Column<string>(nullable: true),
                    Year = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    CoursesID = table.Column<int>(nullable: false),
                    BatchesID = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationTable_BatchTable_BatchesID",
                        column: x => x.BatchesID,
                        principalTable: "BatchTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistrationTable_CourseTable_CoursesID",
                        column: x => x.CoursesID,
                        principalTable: "CourseTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationTable_BatchesID",
                table: "RegistrationTable",
                column: "BatchesID");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationTable_CoursesID",
                table: "RegistrationTable",
                column: "CoursesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrationTable");

            migrationBuilder.DropTable(
                name: "UserTable");

            migrationBuilder.DropTable(
                name: "BatchTable");

            migrationBuilder.DropTable(
                name: "CourseTable");
        }
    }
}
