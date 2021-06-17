using Microsoft.EntityFrameworkCore.Migrations;

namespace Cognizant.DAL.Migrations
{
    public partial class addIsActiveinTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ProgrammingLanguages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "GameStats",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ProgrammingLanguages");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "GameStats");
        }
    }
}
