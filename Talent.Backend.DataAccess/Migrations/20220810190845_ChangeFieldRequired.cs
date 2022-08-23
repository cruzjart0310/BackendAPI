using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Talent.Backend.DataAccessEF.Migrations
{
    public partial class ChangeFieldRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a8de072-fc91-4091-b28d-176c70208792");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aafe83dd-45ee-49a3-b1ce-d8d7c829d7b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5c89e90-65cb-4b61-a3bb-61fd29b65482");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Surveys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "033262f3-2b31-4354-a7f4-d019c2f513a6", null, "Administrator", "Administrator" },
                    { "b42b2e52-0fa1-420b-bec3-30e75b82ae7b", null, "SuperUser", "SuperUser" },
                    { "50c17233-5784-4948-b60e-62e29dfcafd3", null, "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5dbc387-eed6-42fb-b9d8-525094a171b0",
                column: "CreatedAt",
                value: new DateTime(2022, 8, 10, 14, 8, 44, 488, DateTimeKind.Local).AddTicks(5530));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 10, 14, 8, 44, 518, DateTimeKind.Local).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 10, 14, 8, 44, 519, DateTimeKind.Local).AddTicks(641));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 10, 14, 8, 44, 519, DateTimeKind.Local).AddTicks(664));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 8, 10, 14, 8, 44, 519, DateTimeKind.Local).AddTicks(671));

            migrationBuilder.UpdateData(
                table: "UserProfile",
                keyColumn: "UserId",
                keyValue: "b5dbc387-eed6-42fb-b9d8-525094a171b0",
                column: "Id",
                value: "25d214e7-1dd5-441f-aed9-d8121022eabb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "033262f3-2b31-4354-a7f4-d019c2f513a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50c17233-5784-4948-b60e-62e29dfcafd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b42b2e52-0fa1-420b-bec3-30e75b82ae7b");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Surveys",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e5c89e90-65cb-4b61-a3bb-61fd29b65482", null, "Administrator", "Administrator" },
                    { "aafe83dd-45ee-49a3-b1ce-d8d7c829d7b5", null, "SuperUser", "SuperUser" },
                    { "9a8de072-fc91-4091-b28d-176c70208792", null, "User", "User" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5dbc387-eed6-42fb-b9d8-525094a171b0",
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 15, 49, 7, 550, DateTimeKind.Local).AddTicks(8402));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 15, 49, 7, 573, DateTimeKind.Local).AddTicks(7476));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 15, 49, 7, 573, DateTimeKind.Local).AddTicks(8103));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 15, 49, 7, 573, DateTimeKind.Local).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 7, 7, 15, 49, 7, 573, DateTimeKind.Local).AddTicks(8123));

            migrationBuilder.UpdateData(
                table: "UserProfile",
                keyColumn: "UserId",
                keyValue: "b5dbc387-eed6-42fb-b9d8-525094a171b0",
                column: "Id",
                value: "55ba9f68-e158-41ed-bf88-46b437897273");
        }
    }
}
