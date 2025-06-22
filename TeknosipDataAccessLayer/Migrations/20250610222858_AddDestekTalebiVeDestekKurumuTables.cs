using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeknosipDataAccessLayer.Migrations
{
    public partial class AddDestekTalebiVeDestekKurumuTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DestekKurumlari",
                columns: table => new
                {
                    DestekKurumuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KurumAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestekKurumlari", x => x.DestekKurumuId);
                });

            migrationBuilder.CreateTable(
                name: "DestekTalepleri",
                columns: table => new
                {
                    DestekTalebiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProblemId = table.Column<int>(type: "int", nullable: false),
                    DestekKurumuId = table.Column<int>(type: "int", nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestekTalepleri", x => x.DestekTalebiId);
                    table.ForeignKey(
                        name: "FK_DestekTalepleri_DestekKurumlari_DestekKurumuId",
                        column: x => x.DestekKurumuId,
                        principalTable: "DestekKurumlari",
                        principalColumn: "DestekKurumuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestekTalepleri_Problems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Problems",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestekTalepleri_DestekKurumuId",
                table: "DestekTalepleri",
                column: "DestekKurumuId");

            migrationBuilder.CreateIndex(
                name: "IX_DestekTalepleri_ProblemId",
                table: "DestekTalepleri",
                column: "ProblemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestekTalepleri");

            migrationBuilder.DropTable(
                name: "DestekKurumlari");
        }
    }
}
