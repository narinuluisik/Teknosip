using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeknosipDataAccessLayer.Migrations
{
    public partial class CozumTablosuEkle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cozums",
                columns: table => new
                {
                    CozumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProblemId = table.Column<int>(type: "int", nullable: false),
                    DestekKurumuId = table.Column<int>(type: "int", nullable: false),
                    CozumMetni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KurumAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KurumEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KurumTelefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cozums", x => x.CozumId);
                    table.ForeignKey(
                        name: "FK_Cozums_DestekKurumlari_DestekKurumuId",
                        column: x => x.DestekKurumuId,
                        principalTable: "DestekKurumlari",
                        principalColumn: "DestekKurumuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cozums_Problems_ProblemId",
                        column: x => x.ProblemId,
                        principalTable: "Problems",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cozums_DestekKurumuId",
                table: "Cozums",
                column: "DestekKurumuId");

            migrationBuilder.CreateIndex(
                name: "IX_Cozums_ProblemId",
                table: "Cozums",
                column: "ProblemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cozums");
        }
    }
}
