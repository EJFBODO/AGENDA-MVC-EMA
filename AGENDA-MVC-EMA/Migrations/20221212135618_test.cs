using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGENDA_MVC_EMA.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "idUser",
                table: "Contactos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_idUser",
                table: "Contactos",
                column: "idUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Contactos_AspNetUsers_idUser",
                table: "Contactos",
                column: "idUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contactos_AspNetUsers_idUser",
                table: "Contactos");

            migrationBuilder.DropIndex(
                name: "IX_Contactos_idUser",
                table: "Contactos");

            migrationBuilder.DropColumn(
                name: "idUser",
                table: "Contactos");
        }
    }
}
