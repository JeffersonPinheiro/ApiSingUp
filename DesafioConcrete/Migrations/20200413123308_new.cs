using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioConcrete.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DDD",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "TelefonesId",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DDD = table.Column<int>(nullable: false),
                    numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TelefonesId",
                table: "Usuarios",
                column: "TelefonesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Telefones_TelefonesId",
                table: "Usuarios",
                column: "TelefonesId",
                principalTable: "Telefones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Telefones_TelefonesId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_TelefonesId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TelefonesId",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "DDD",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Telefone",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0);
        }
    }
}
