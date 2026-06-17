using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PredictorTarifa.Datos.Migrations
{
    /// <inheritdoc />
    public partial class CreacionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CodigoTarifa = table.Column<float>(type: "real", nullable: false),
                    NumeroPasajeros = table.Column<float>(type: "real", nullable: false),
                    DuracionSegundos = table.Column<float>(type: "real", nullable: false),
                    DistanciaMillas = table.Column<float>(type: "real", nullable: false),
                    TipoPago = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TarifaReal = table.Column<float>(type: "real", nullable: false),
                    TarifaPredicha = table.Column<float>(type: "real", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Viajes");
        }
    }
}
