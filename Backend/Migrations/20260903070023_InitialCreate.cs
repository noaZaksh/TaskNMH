using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PremiumMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MethodNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    PremiumPercent = table.Column<decimal>(type: "TEXT", nullable: false),
                    CalculationPeriod = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremiumMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Metrics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PremiumMethodId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    SourceType = table.Column<string>(type: "TEXT", nullable: false),
                    SourceName = table.Column<string>(type: "TEXT", nullable: false),
                    Frequency = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Metrics_PremiumMethods_PremiumMethodId",
                        column: x => x.PremiumMethodId,
                        principalTable: "PremiumMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MetricId = table.Column<int>(type: "INTEGER", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Period = table.Column<string>(type: "TEXT", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    ImportedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    RowsCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imports_Metrics_MetricId",
                        column: x => x.MetricId,
                        principalTable: "Metrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportSchemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MetricId = table.Column<int>(type: "INTEGER", nullable: false),
                    Version = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportSchemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportSchemas_Metrics_MetricId",
                        column: x => x.MetricId,
                        principalTable: "Metrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetricFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MetricId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DataType = table.Column<string>(type: "TEXT", nullable: false),
                    IsRelevant = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsRequired = table.Column<bool>(type: "INTEGER", nullable: false),
                    DisplayOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetricFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetricFields_Metrics_MetricId",
                        column: x => x.MetricId,
                        principalTable: "Metrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportRows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImportId = table.Column<int>(type: "INTEGER", nullable: false),
                    RowNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportRows_Imports_ImportId",
                        column: x => x.ImportId,
                        principalTable: "Imports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportSchemaFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImportSchemaId = table.Column<int>(type: "INTEGER", nullable: false),
                    MetricFieldId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExcelColumnName = table.Column<string>(type: "TEXT", nullable: false),
                    ExcelColumnIndex = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportSchemaFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportSchemaFields_ImportSchemas_ImportSchemaId",
                        column: x => x.ImportSchemaId,
                        principalTable: "ImportSchemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportSchemaFields_MetricFields_MetricFieldId",
                        column: x => x.MetricFieldId,
                        principalTable: "MetricFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImportRowId = table.Column<int>(type: "INTEGER", nullable: false),
                    MetricFieldId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportValues_ImportRows_ImportRowId",
                        column: x => x.ImportRowId,
                        principalTable: "ImportRows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportValues_MetricFields_MetricFieldId",
                        column: x => x.MetricFieldId,
                        principalTable: "MetricFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImportRows_ImportId_RowNumber",
                table: "ImportRows",
                columns: new[] { "ImportId", "RowNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imports_MetricId_Year_Period",
                table: "Imports",
                columns: new[] { "MetricId", "Year", "Period" });

            migrationBuilder.CreateIndex(
                name: "IX_ImportSchemaFields_ImportSchemaId",
                table: "ImportSchemaFields",
                column: "ImportSchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportSchemaFields_MetricFieldId",
                table: "ImportSchemaFields",
                column: "MetricFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportSchemas_MetricId",
                table: "ImportSchemas",
                column: "MetricId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportValues_ImportRowId_MetricFieldId",
                table: "ImportValues",
                columns: new[] { "ImportRowId", "MetricFieldId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImportValues_MetricFieldId",
                table: "ImportValues",
                column: "MetricFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_MetricFields_MetricId_Name",
                table: "MetricFields",
                columns: new[] { "MetricId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Metrics_PremiumMethodId",
                table: "Metrics",
                column: "PremiumMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PremiumMethods_MethodNumber",
                table: "PremiumMethods",
                column: "MethodNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportSchemaFields");

            migrationBuilder.DropTable(
                name: "ImportValues");

            migrationBuilder.DropTable(
                name: "ImportSchemas");

            migrationBuilder.DropTable(
                name: "ImportRows");

            migrationBuilder.DropTable(
                name: "MetricFields");

            migrationBuilder.DropTable(
                name: "Imports");

            migrationBuilder.DropTable(
                name: "Metrics");

            migrationBuilder.DropTable(
                name: "PremiumMethods");
        }
    }
}
