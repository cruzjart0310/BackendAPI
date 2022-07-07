using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Talent.Backend.DataAccessEF.Migrations
{
    public partial class RemoveFieldpointFronAnswerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29c8e09b-ba63-4dcc-87ea-1c2c13b107d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "382a9129-4071-42c6-8d4d-9f8a5fffcea0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "386d297c-817e-49db-9ac8-816faeb4bc2e");

            migrationBuilder.DropColumn(
                name: "Point",
                table: "Answers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48c139ce-6f89-4e45-bf08-54408f12e71c", null, "Administrator", "Administrator" },
                    { "a1d7aa5b-2343-4502-b8aa-02540df5acf9", null, "SuperUser", "SuperUser" },
                    { "00b8530d-2a51-414d-b74e-ba6c6a223072", null, "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5dbc387-eed6-42fb-b9d8-525094a171b0",
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 11, 27, 23, 555, DateTimeKind.Local).AddTicks(9915));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 11, 27, 23, 598, DateTimeKind.Local).AddTicks(3639));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 11, 27, 23, 598, DateTimeKind.Local).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 11, 27, 23, 598, DateTimeKind.Local).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 11, 27, 23, 598, DateTimeKind.Local).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "UserProfile",
                keyColumn: "UserId",
                keyValue: "b5dbc387-eed6-42fb-b9d8-525094a171b0",
                column: "Id",
                value: "2ae93bdf-2404-4707-8994-dc7050d79012");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00b8530d-2a51-414d-b74e-ba6c6a223072");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48c139ce-6f89-4e45-bf08-54408f12e71c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1d7aa5b-2343-4502-b8aa-02540df5acf9");

            migrationBuilder.AddColumn<int>(
                name: "Point",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "386d297c-817e-49db-9ac8-816faeb4bc2e", null, "Administrator", "Administrator" },
                    { "382a9129-4071-42c6-8d4d-9f8a5fffcea0", null, "SuperUser", "SuperUser" },
                    { "29c8e09b-ba63-4dcc-87ea-1c2c13b107d6", null, "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5dbc387-eed6-42fb-b9d8-525094a171b0",
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 11, 18, 6, 442, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 11, 18, 6, 476, DateTimeKind.Local).AddTicks(8990));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 11, 18, 6, 476, DateTimeKind.Local).AddTicks(9897));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 11, 18, 6, 476, DateTimeKind.Local).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 11, 18, 6, 476, DateTimeKind.Local).AddTicks(9927));

            migrationBuilder.UpdateData(
                table: "UserProfile",
                keyColumn: "UserId",
                keyValue: "b5dbc387-eed6-42fb-b9d8-525094a171b0",
                column: "Id",
                value: "ddb2c61c-a740-4fc2-98f2-dfcabceab08d");
        }
    }
}
