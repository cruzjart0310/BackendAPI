using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Talent.Backend.DataAccessEF.Migrations
{
    public partial class AddTableUserAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserAnswerId",
                table: "Answer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AnswerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnswer_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_UserAnswerId",
                table: "Answer",
                column: "UserAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_UserId",
                table: "UserAnswer",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_UserAnswer_UserAnswerId",
                table: "Answer",
                column: "UserAnswerId",
                principalTable: "UserAnswer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_UserAnswer_UserAnswerId",
                table: "Answer");

            migrationBuilder.DropTable(
                name: "UserAnswer");

            migrationBuilder.DropIndex(
                name: "IX_Answer_UserAnswerId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "UserAnswerId",
                table: "Answer");
        }
    }
}
