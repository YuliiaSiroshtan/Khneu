using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.Data.Migrations
{
    public partial class RemovePublicationNMBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicationNMBD");

            migrationBuilder.AddColumn<string>(
                name: "NMBDId",
                table: "Publication",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publication_NMBDId",
                table: "Publication",
                column: "NMBDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publication_NMBD_NMBDId",
                table: "Publication",
                column: "NMBDId",
                principalTable: "NMBD",
                principalColumn: "NMBDId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publication_NMBD_NMBDId",
                table: "Publication");

            migrationBuilder.DropIndex(
                name: "IX_Publication_NMBDId",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "NMBDId",
                table: "Publication");

            migrationBuilder.CreateTable(
                name: "PublicationNMBD",
                columns: table => new
                {
                    PublicationId = table.Column<string>(nullable: false),
                    NMBDId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationNMBD", x => new { x.PublicationId, x.NMBDId });
                    table.ForeignKey(
                        name: "FK_PublicationNMBD_NMBD_NMBDId",
                        column: x => x.NMBDId,
                        principalTable: "NMBD",
                        principalColumn: "NMBDId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicationNMBD_Publication_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publication",
                        principalColumn: "PublicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublicationNMBD_NMBDId",
                table: "PublicationNMBD",
                column: "NMBDId");
        }
    }
}
