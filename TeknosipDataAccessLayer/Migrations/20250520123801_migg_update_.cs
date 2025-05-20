using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeknosipDataAccessLayer.Migrations
{
    public partial class migg_update_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Problems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Problems");
        }
    }
}
