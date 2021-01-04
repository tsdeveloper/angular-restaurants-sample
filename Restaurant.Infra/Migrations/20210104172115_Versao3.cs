using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Infra.Migrations
{
    public partial class Versao3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "RestaurantRating",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 4, 14, 21, 15, 24, DateTimeKind.Local).AddTicks(2410));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RestaurantRating");
        }
    }
}
