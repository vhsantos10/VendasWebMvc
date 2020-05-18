using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMvc.Migrations
{
    public partial class DepartamentFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedores_Departamentos_departamentosId",
                table: "Vendedores");

            migrationBuilder.RenameColumn(
                name: "departamentosId",
                table: "Vendedores",
                newName: "DepartamentosId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendedores_departamentosId",
                table: "Vendedores",
                newName: "IX_Vendedores_DepartamentosId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentosId",
                table: "Vendedores",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedores_Departamentos_DepartamentosId",
                table: "Vendedores",
                column: "DepartamentosId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedores_Departamentos_DepartamentosId",
                table: "Vendedores");

            migrationBuilder.RenameColumn(
                name: "DepartamentosId",
                table: "Vendedores",
                newName: "departamentosId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendedores_DepartamentosId",
                table: "Vendedores",
                newName: "IX_Vendedores_departamentosId");

            migrationBuilder.AlterColumn<int>(
                name: "departamentosId",
                table: "Vendedores",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedores_Departamentos_departamentosId",
                table: "Vendedores",
                column: "departamentosId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
