using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QwikThrift.Migrations
{
    public partial class addedMessageDeleteFlags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RecipientDelete",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SenderDelete",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 4,
                column: "ListingTime",
                value: new DateTime(2023, 10, 4, 19, 38, 16, 413, DateTimeKind.Local).AddTicks(3955));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipientDelete",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderDelete",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 4,
                column: "ListingTime",
                value: new DateTime(2023, 10, 4, 19, 33, 45, 97, DateTimeKind.Local).AddTicks(686));
        }
    }
}
