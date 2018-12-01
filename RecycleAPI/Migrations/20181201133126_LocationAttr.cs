using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecycleAPI.Migrations
{
    public partial class LocationAttr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<SqlBytes>(
                name: "Location",
                table: "Recycles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Recycles");
        }
    }
}
