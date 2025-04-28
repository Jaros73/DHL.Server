using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHL.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crates",
                columns: table => new
                {
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crates", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Dispatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedByFullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeEnumId = table.Column<int>(type: "int", nullable: false),
                    TypeEnumName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    KeyEnumId = table.Column<int>(type: "int", nullable: false),
                    KeyEnumName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispatches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DispatchKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispatchKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DispatchTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispatchTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostOfficeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Psc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Machinings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machinings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnologicalGroups",
                columns: table => new
                {
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologicalGroups", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "LocationMachines",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    MachineValue = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationMachines", x => new { x.LocationId, x.MachineValue });
                    table.ForeignKey(
                        name: "FK_LocationMachines_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationMachines_Machines_MachineValue",
                        column: x => x.MachineValue,
                        principalTable: "Machines",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachiningMachines",
                columns: table => new
                {
                    MachiningId = table.Column<int>(type: "int", nullable: false),
                    MachineValue = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachiningMachines", x => new { x.MachiningId, x.MachineValue });
                    table.ForeignKey(
                        name: "FK_MachiningMachines_Machines_MachineValue",
                        column: x => x.MachineValue,
                        principalTable: "Machines",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachiningMachines_Machinings_MachiningId",
                        column: x => x.MachiningId,
                        principalTable: "Machinings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnologicalGroupCrates",
                columns: table => new
                {
                    TechnologicalGroupValue = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CrateValue = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologicalGroupCrates", x => new { x.TechnologicalGroupValue, x.CrateValue });
                    table.ForeignKey(
                        name: "FK_TechnologicalGroupCrates_Crates_CrateValue",
                        column: x => x.CrateValue,
                        principalTable: "Crates",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnologicalGroupCrates_TechnologicalGroups_TechnologicalGroupValue",
                        column: x => x.TechnologicalGroupValue,
                        principalTable: "TechnologicalGroups",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationMachines_MachineValue",
                table: "LocationMachines",
                column: "MachineValue");

            migrationBuilder.CreateIndex(
                name: "IX_MachiningMachines_MachineValue",
                table: "MachiningMachines",
                column: "MachineValue");

            migrationBuilder.CreateIndex(
                name: "IX_TechnologicalGroupCrates_CrateValue",
                table: "TechnologicalGroupCrates",
                column: "CrateValue");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dispatches");

            migrationBuilder.DropTable(
                name: "DispatchKeys");

            migrationBuilder.DropTable(
                name: "DispatchTypes");

            migrationBuilder.DropTable(
                name: "LocationMachines");

            migrationBuilder.DropTable(
                name: "MachiningMachines");

            migrationBuilder.DropTable(
                name: "TechnologicalGroupCrates");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Machinings");

            migrationBuilder.DropTable(
                name: "Crates");

            migrationBuilder.DropTable(
                name: "TechnologicalGroups");
        }
    }
}
