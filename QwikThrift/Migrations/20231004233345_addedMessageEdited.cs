using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QwikThrift.Migrations
{
    public partial class addedMessageEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MessageEdited",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 4,
                column: "ListingTime",
                value: new DateTime(2023, 10, 4, 19, 33, 45, 97, DateTimeKind.Local).AddTicks(686));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageEdited",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 4,
                column: "ListingTime",
                value: new DateTime(2023, 9, 28, 18, 54, 28, 243, DateTimeKind.Local).AddTicks(6174));
        }
    }
}
