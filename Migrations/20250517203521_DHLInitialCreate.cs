using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHL.Server.Migrations
{
    /// <inheritdoc />
    public partial class DHLInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Klics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kurzs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdjezdZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmerKurzu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ridic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RZ = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurzs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KurzyDispatch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CisloKurzu = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    DatumOdjezdu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanovanyCasOdjezdu = table.Column<TimeSpan>(type: "time", nullable: true),
                    RozdilCasuOdjezdu = table.Column<int>(type: "int", nullable: true),
                    PlanovanyCasPrijezdu = table.Column<TimeSpan>(type: "time", nullable: true),
                    RozdilCasuPrijezdu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KurzyDispatch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KurzyPEs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AP = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    NazevKurzu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PSCzastavky = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Zastavka = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Prijezd = table.Column<TimeSpan>(type: "time", nullable: false),
                    Odjezd = table.Column<TimeSpan>(type: "time", nullable: false),
                    DatumZ = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumU = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KurzyPEs", x => x.Id);
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
                name: "MimKurzs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdjezdTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ridic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duvod = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MimKurzs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Obals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Identifier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SourceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prepravces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prepravces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PripojVozidlos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RZ = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PripojVozidlos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Strojs",
                columns: table => new
                {
                    StrojId = table.Column<int>(type: "int", nullable: false),
                    StrojValue = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poznamka = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strojs", x => new { x.StrojId, x.StrojValue });
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
                name: "Vozidlos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RZ = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozidlos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VykonStrojes",
                columns: table => new
                {
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VykonStrojes", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "VykonStrojs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VykonStrojs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zastavkas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zastavkas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZatezAPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AP = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    UK = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    PocetKS = table.Column<int>(type: "int", nullable: false),
                    DatumU = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZatezAPs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZpozdeniKurzus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duvod = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZpozdeniKurzus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DispatchModels",
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
                    table.PrimaryKey("PK_DispatchModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DispatchModels_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LokaceStrojes",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    MachineValue = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LokaceStrojes", x => new { x.LocationId, x.MachineValue });
                    table.ForeignKey(
                        name: "FK_LokaceStrojes_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegionalReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateFor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Network = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    LocationZip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opatreni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KurzCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KurzPlanovanyPrijezd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KurzSkutecnyPrijezd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KurzZpozdeniEnumId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KurzZpozdeniName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Poznamka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedByFullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionalReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegionalReports_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zbyteks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Popis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Pocet = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zbyteks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zbyteks_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_TechnologicalGroupCrates_TechnologicalGroups_TechnologicalGroupValue",
                        column: x => x.TechnologicalGroupValue,
                        principalTable: "TechnologicalGroups",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prilohys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionalReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prilohys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prilohys_RegionalReports_RegionalReportId",
                        column: x => x.RegionalReportId,
                        principalTable: "RegionalReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DispatchModels_LocationId",
                table: "DispatchModels",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Prilohys_RegionalReportId",
                table: "Prilohys",
                column: "RegionalReportId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionalReports_LocationId",
                table: "RegionalReports",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Zbyteks_LocationId",
                table: "Zbyteks",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DispatchKeys");

            migrationBuilder.DropTable(
                name: "DispatchModels");

            migrationBuilder.DropTable(
                name: "DispatchTypes");

            migrationBuilder.DropTable(
                name: "Klics");

            migrationBuilder.DropTable(
                name: "Kurzs");

            migrationBuilder.DropTable(
                name: "KurzyDispatch");

            migrationBuilder.DropTable(
                name: "KurzyPEs");

            migrationBuilder.DropTable(
                name: "LokaceStrojes");

            migrationBuilder.DropTable(
                name: "MimKurzs");

            migrationBuilder.DropTable(
                name: "Obals");

            migrationBuilder.DropTable(
                name: "Prepravces");

            migrationBuilder.DropTable(
                name: "Prilohys");

            migrationBuilder.DropTable(
                name: "PripojVozidlos");

            migrationBuilder.DropTable(
                name: "Strojs");

            migrationBuilder.DropTable(
                name: "TechnologicalGroupCrates");

            migrationBuilder.DropTable(
                name: "Vozidlos");

            migrationBuilder.DropTable(
                name: "VykonStrojes");

            migrationBuilder.DropTable(
                name: "VykonStrojs");

            migrationBuilder.DropTable(
                name: "Zastavkas");

            migrationBuilder.DropTable(
                name: "ZatezAPs");

            migrationBuilder.DropTable(
                name: "Zbyteks");

            migrationBuilder.DropTable(
                name: "ZpozdeniKurzus");

            migrationBuilder.DropTable(
                name: "RegionalReports");

            migrationBuilder.DropTable(
                name: "TechnologicalGroups");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
