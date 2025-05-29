using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManager.Migrations
{
    /// <inheritdoc />
    public partial class Cambios2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Cargos_CargoIdCargo",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Departamentos_DepartamentoIdDepartamento",
                table: "Empleados");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoIdDepartamento",
                table: "Empleados",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CargoIdCargo",
                table: "Empleados",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Cargos_CargoIdCargo",
                table: "Empleados",
                column: "CargoIdCargo",
                principalTable: "Cargos",
                principalColumn: "IdCargo");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Departamentos_DepartamentoIdDepartamento",
                table: "Empleados",
                column: "DepartamentoIdDepartamento",
                principalTable: "Departamentos",
                principalColumn: "IdDepartamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Cargos_CargoIdCargo",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Departamentos_DepartamentoIdDepartamento",
                table: "Empleados");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoIdDepartamento",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CargoIdCargo",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Cargos_CargoIdCargo",
                table: "Empleados",
                column: "CargoIdCargo",
                principalTable: "Cargos",
                principalColumn: "IdCargo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Departamentos_DepartamentoIdDepartamento",
                table: "Empleados",
                column: "DepartamentoIdDepartamento",
                principalTable: "Departamentos",
                principalColumn: "IdDepartamento",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
