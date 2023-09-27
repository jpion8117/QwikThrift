using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QwikThrift.Migrations
{
    public partial class messageReadStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MessageRead",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 4,
                column: "ListingTime",
                value: new DateTime(2023, 9, 26, 6, 39, 49, 240, DateTimeKind.Local).AddTicks(3744));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageRead",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 4,
                column: "ListingTime",
                value: new DateTime(2023, 9, 25, 17, 13, 0, 548, DateTimeKind.Local).AddTicks(2840));
        }
    }
}
