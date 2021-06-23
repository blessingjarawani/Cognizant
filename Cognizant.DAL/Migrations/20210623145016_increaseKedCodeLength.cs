using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cognizant.DAL.Migrations
{
    public partial class increaseKedCodeLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "KeyCode",
                table: "ProgrammingLanguages",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 6, 23, 16, 50, 15, 526, DateTimeKind.Local).AddTicks(989), new DateTime(2021, 6, 23, 16, 50, 15, 532, DateTimeKind.Local).AddTicks(4097) });

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 6, 23, 16, 50, 15, 532, DateTimeKind.Local).AddTicks(5660), new DateTime(2021, 6, 23, 16, 50, 15, 532, DateTimeKind.Local).AddTicks(5680) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 6, 23, 16, 50, 15, 534, DateTimeKind.Local).AddTicks(7032), new DateTime(2021, 6, 23, 16, 50, 15, 534, DateTimeKind.Local).AddTicks(7077) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 6, 23, 16, 50, 15, 534, DateTimeKind.Local).AddTicks(7086), new DateTime(2021, 6, 23, 16, 50, 15, 534, DateTimeKind.Local).AddTicks(7090) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "KeyCode",
                table: "ProgrammingLanguages",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 6, 18, 15, 6, 32, 849, DateTimeKind.Local).AddTicks(9748), new DateTime(2021, 6, 18, 15, 6, 32, 861, DateTimeKind.Local).AddTicks(1837) });

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 6, 18, 15, 6, 32, 861, DateTimeKind.Local).AddTicks(5084), new DateTime(2021, 6, 18, 15, 6, 32, 861, DateTimeKind.Local).AddTicks(5133) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 6, 18, 15, 6, 32, 865, DateTimeKind.Local).AddTicks(7580), new DateTime(2021, 6, 18, 15, 6, 32, 865, DateTimeKind.Local).AddTicks(7676) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 6, 18, 15, 6, 32, 865, DateTimeKind.Local).AddTicks(7689), new DateTime(2021, 6, 18, 15, 6, 32, 865, DateTimeKind.Local).AddTicks(7702) });
        }
    }
}
