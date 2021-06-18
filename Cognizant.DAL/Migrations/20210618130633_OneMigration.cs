using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cognizant.DAL.Migrations
{
    public partial class OneMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammingLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    KeyCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BaseSolutionCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InputParameter = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ExpectedOutPut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameStats_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "BaseSolutionCode", "CreatedDate", "IsActive", "KeyCode", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "public class MyClass {  public static void main(String args[]) {                }}", new DateTime(2021, 6, 18, 15, 6, 32, 849, DateTimeKind.Local).AddTicks(9748), true, "java", "JAVA", new DateTime(2021, 6, 18, 15, 6, 32, 861, DateTimeKind.Local).AddTicks(1837) },
                    { 2, "<?php ,         \r\n                                          \r\n                                             ?> ", new DateTime(2021, 6, 18, 15, 6, 32, 861, DateTimeKind.Local).AddTicks(5084), true, "php", "PHP", new DateTime(2021, 6, 18, 15, 6, 32, 861, DateTimeKind.Local).AddTicks(5133) }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedDate", "Description", "ExpectedOutPut", "InputParameter", "IsActive", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 18, 15, 6, 32, 865, DateTimeKind.Local).AddTicks(7580), "Given a number n, print n-th Fibonacci Number.", "34", "9", true, "Fibonacci Series", new DateTime(2021, 6, 18, 15, 6, 32, 865, DateTimeKind.Local).AddTicks(7676) },
                    { 2, new DateTime(2021, 6, 18, 15, 6, 32, 865, DateTimeKind.Local).AddTicks(7689), "Program to find sum of elements in a given array elements InputArray 12,3,4,15", "34", "0", true, "Sum of elements array", new DateTime(2021, 6, 18, 15, 6, 32, 865, DateTimeKind.Local).AddTicks(7702) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameStats_TaskId",
                table: "GameStats",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameStats");

            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
