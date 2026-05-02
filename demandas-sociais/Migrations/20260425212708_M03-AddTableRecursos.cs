using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demandas_sociais.Migrations
{
    /// <inheritdoc />
    public partial class M03AddTableRecursos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recursos_Demandas_DemandaId",
                table: "Recursos");

            migrationBuilder.DropIndex(
                name: "IX_Recursos_DemandaId",
                table: "Recursos");

            migrationBuilder.AddColumn<int>(
                name: "Demandasid",
                table: "Recursos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recursos_Demandasid",
                table: "Recursos",
                column: "Demandasid");

            migrationBuilder.AddForeignKey(
                name: "FK_Recursos_Demandas_Demandasid",
                table: "Recursos",
                column: "Demandasid",
                principalTable: "Demandas",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recursos_Demandas_Demandasid",
                table: "Recursos");

            migrationBuilder.DropIndex(
                name: "IX_Recursos_Demandasid",
                table: "Recursos");

            migrationBuilder.DropColumn(
                name: "Demandasid",
                table: "Recursos");

            migrationBuilder.CreateIndex(
                name: "IX_Recursos_DemandaId",
                table: "Recursos",
                column: "DemandaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recursos_Demandas_DemandaId",
                table: "Recursos",
                column: "DemandaId",
                principalTable: "Demandas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
