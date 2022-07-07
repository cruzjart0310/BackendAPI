using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Talent.Backend.DataAccessEF.Migrations
{
    public partial class ColunAddTableAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "687bcabd-2ea9-46bf-b566-29a2c35e1bd6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1580891-56ed-4db2-8aea-a8bebee68ecd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca18a0e8-2cde-48c1-a9b2-2a13a75389dc");

            migrationBuilder.AddColumn<byte>(
                name: "IsCorrect",
                table: "Answers",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6eeddfbb-8d48-407d-b2fd-fedd123e138d", null, "Administrator", "Administrator" },
                    { "bb9802cd-c060-4aff-ab12-d1883ce0472d", null, "SuperUser", "SuperUser" },
                    { "ca8a9422-e5ac-4e17-ae5b-22eeadb3af7c", null, "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5dbc387-eed6-42fb-b9d8-525094a171b0",
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 11, 11, 23, 494, DateTimeKind.Local).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 11, 11, 23, 537, DateTimeKind.Local).AddTicks(5916));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 11, 11, 23, 537, DateTimeKind.Local).AddTicks(7908));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 11, 11, 23, 537, DateTimeKind.Local).AddTicks(7935));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 11, 11, 23, 537, DateTimeKind.Local).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "UserProfile",
                keyColumn: "UserId",
                keyValue: "b5dbc387-eed6-42fb-b9d8-525094a171b0",
                column: "Id",
                value: "39c210b1-97db-41ec-857b-78a437bd1737");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6eeddfbb-8d48-407d-b2fd-fedd123e138d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb9802cd-c060-4aff-ab12-d1883ce0472d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca8a9422-e5ac-4e17-ae5b-22eeadb3af7c");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "Answers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b1580891-56ed-4db2-8aea-a8bebee68ecd", null, "Administrator", "Administrator" },
                    { "ca18a0e8-2cde-48c1-a9b2-2a13a75389dc", null, "SuperUser", "SuperUser" },
                    { "687bcabd-2ea9-46bf-b566-29a2c35e1bd6", null, "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5dbc387-eed6-42fb-b9d8-525094a171b0",
                column: "CreatedAt",
                value: new DateTime(2022, 6, 29, 18, 34, 24, 141, DateTimeKind.Local).AddTicks(8789));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 6, 29, 18, 34, 24, 172, DateTimeKind.Local).AddTicks(3949));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 6, 29, 18, 34, 24, 172, DateTimeKind.Local).AddTicks(5464));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 6, 29, 18, 34, 24, 172, DateTimeKind.Local).AddTicks(5691));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 6, 29, 18, 34, 24, 172, DateTimeKind.Local).AddTicks(5760));

            migrationBuilder.UpdateData(
                table: "UserProfile",
                keyColumn: "UserId",
                keyValue: "b5dbc387-eed6-42fb-b9d8-525094a171b0",
                column: "Id",
                value: "14486bf4-abec-4e29-8a09-b9aae2ba376c");
        }
    }
}
