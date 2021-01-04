using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Infra.Migrations
{
    public partial class Versao4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RestaurantRating",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 4, 14, 25, 51, 770, DateTimeKind.Local).AddTicks(3445),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2021, 1, 4, 14, 21, 15, 24, DateTimeKind.Local).AddTicks(2410));

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "RestaurantRating",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantRating_RestaurantId",
                table: "RestaurantRating",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantRating_Restaurant_RestaurantId",
                table: "RestaurantRating",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantRating_Restaurant_RestaurantId",
                table: "RestaurantRating");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantRating_RestaurantId",
                table: "RestaurantRating");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "RestaurantRating");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RestaurantRating",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 4, 14, 21, 15, 24, DateTimeKind.Local).AddTicks(2410),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 1, 4, 14, 25, 51, 770, DateTimeKind.Local).AddTicks(3445));
        }
    }
}
