using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivallWeb.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groupe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artiste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instrument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artiste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artiste_Groupe_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artiste",
                columns: new[] { "Id", "GroupeId", "Instrument", "Nom", "Prenom" },
                values: new object[] { 2, 0, "Guitare", "Requier", "Thomas" });

            migrationBuilder.InsertData(
                table: "Groupe",
                columns: new[] { "Id", "DateCreation", "Nom" },
                values: new object[] { 1, new DateTime(1977, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Queen" });

            migrationBuilder.InsertData(
                table: "Artiste",
                columns: new[] { "Id", "GroupeId", "Instrument", "Nom", "Prenom" },
                values: new object[] { 1, 1, "Piano", "Mercury", "Freddy" });

            migrationBuilder.CreateIndex(
                name: "IX_Artiste_GroupeId",
                table: "Artiste",
                column: "GroupeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artiste");

            migrationBuilder.DropTable(
                name: "Groupe");
        }
    }
}
