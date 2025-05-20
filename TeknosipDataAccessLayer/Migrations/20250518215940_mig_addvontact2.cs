using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeknosipDataAccessLayer.Migrations
{
    public partial class mig_addvontact2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ContactMessages",
                newName: "ContactMessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactMessageId",
                table: "ContactMessages",
                newName: "Id");
        }
    }
}
