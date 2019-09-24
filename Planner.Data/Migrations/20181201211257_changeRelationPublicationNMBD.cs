using Microsoft.EntityFrameworkCore.Migrations;

namespace Planner.Data.Migrations
{
    public partial class changeRelationPublicationNMBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicationNMBD_NMBD_NMBDId",
                table: "PublicationNMBD");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicationNMBD_Publication_PublicationId",
                table: "PublicationNMBD");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublicationNMBD",
                table: "PublicationNMBD");

            migrationBuilder.DropIndex(
                name: "IX_PublicationNMBD_PublicationId",
                table: "PublicationNMBD");

            migrationBuilder.DropColumn(
                name: "PublicationNMBDId",
                table: "PublicationNMBD");

            migrationBuilder.AlterColumn<string>(
                name: "PublicationId",
                table: "PublicationNMBD",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NMBDId",
                table: "PublicationNMBD",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublicationNMBD",
                table: "PublicationNMBD",
                columns: new[] { "PublicationId", "NMBDId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationNMBD_NMBD_NMBDId",
                table: "PublicationNMBD",
                column: "NMBDId",
                principalTable: "NMBD",
                principalColumn: "NMBDId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationNMBD_Publication_PublicationId",
                table: "PublicationNMBD",
                column: "PublicationId",
                principalTable: "Publication",
                principalColumn: "PublicationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicationNMBD_NMBD_NMBDId",
                table: "PublicationNMBD");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicationNMBD_Publication_PublicationId",
                table: "PublicationNMBD");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublicationNMBD",
                table: "PublicationNMBD");

            migrationBuilder.AlterColumn<string>(
                name: "NMBDId",
                table: "PublicationNMBD",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PublicationId",
                table: "PublicationNMBD",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "PublicationNMBDId",
                table: "PublicationNMBD",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublicationNMBD",
                table: "PublicationNMBD",
                column: "PublicationNMBDId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationNMBD_PublicationId",
                table: "PublicationNMBD",
                column: "PublicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationNMBD_NMBD_NMBDId",
                table: "PublicationNMBD",
                column: "NMBDId",
                principalTable: "NMBD",
                principalColumn: "NMBDId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationNMBD_Publication_PublicationId",
                table: "PublicationNMBD",
                column: "PublicationId",
                principalTable: "Publication",
                principalColumn: "PublicationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
