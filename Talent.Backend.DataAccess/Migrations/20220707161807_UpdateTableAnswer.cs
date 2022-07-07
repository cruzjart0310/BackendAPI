using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Talent.Backend.DataAccessEF.Migrations
{
    public partial class UpdateTableAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_UserAnswer_UserAnswerId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswer_AspNetUsers_UserId",
                table: "UserAnswer");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswer_UserId",
                table: "UserAnswer");

            migrationBuilder.DropIndex(
                name: "IX_Answers_UserAnswerId",
                table: "Answers");

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
                name: "UserAnswerId",
                table: "Answers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserAnswer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserAnswer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserAnswerId",
                table: "Answers",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_UserId",
                table: "UserAnswer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_UserAnswerId",
                table: "Answers",
                column: "UserAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_UserAnswer_UserAnswerId",
                table: "Answers",
                column: "UserAnswerId",
                principalTable: "UserAnswer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_AspNetUsers_UserId",
                table: "UserAnswer",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
