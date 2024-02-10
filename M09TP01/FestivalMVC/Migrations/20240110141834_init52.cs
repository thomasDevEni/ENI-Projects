using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivallWeb.Migrations
{
    public partial class init52 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artiste_Groupe_GroupeId",
                table: "Artiste");

            migrationBuilder.AlterColumn<int>(
                name: "GroupeId",
                table: "Artiste",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Artiste",
                keyColumn: "Id",
                keyValue: 2,
                column: "GroupeId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Artiste_Groupe_GroupeId",
                table: "Artiste",
                column: "GroupeId",
                principalTable: "Groupe",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artiste_Groupe_GroupeId",
                table: "Artiste");

            migrationBuilder.AlterColumn<int>(
                name: "GroupeId",
                table: "Artiste",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Artiste",
                keyColumn: "Id",
                keyValue: 2,
                column: "GroupeId",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Artiste_Groupe_GroupeId",
                table: "Artiste",
                column: "GroupeId",
                principalTable: "Groupe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
