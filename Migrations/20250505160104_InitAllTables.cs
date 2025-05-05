using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHL.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseDelayReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDelayReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromLocationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToLocationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Driver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehiclePlate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

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
                name: "IrregularCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Driver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehiclePlate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrregularCourses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KurzyPE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TC = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AP = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Zastavka = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Odjez = table.Column<TimeSpan>(type: "time", nullable: false),
                    DatumZ = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumU = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KurzyPE", x => x.Id);
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
                    MachineType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machinings", x => x.Id);
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
                    LocationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationZip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionTaken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoursePlannedArrival = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CourseRealArrival = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CourseDelayEnumId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseDelayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedByFullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionalReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Remainders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remainders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stops",
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
                    table.PrimaryKey("PK_Stops", x => x.Id);
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
                name: "Trailers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trailers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transporters",
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
                    table.PrimaryKey("PK_Transporters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZatezAP",
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
                    table.PrimaryKey("PK_ZatezAP", x => x.Id);
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
                name: "Attachments",
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
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_RegionalReports_RegionalReportId",
                        column: x => x.RegionalReportId,
                        principalTable: "RegionalReports",
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
                name: "IX_Attachments_RegionalReportId",
                table: "Attachments",
                column: "RegionalReportId");

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
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "CourseDelayReasons");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Dispatches");

            migrationBuilder.DropTable(
                name: "DispatchKeys");

            migrationBuilder.DropTable(
                name: "DispatchTypes");

            migrationBuilder.DropTable(
                name: "IrregularCourses");

            migrationBuilder.DropTable(
                name: "KurzyPE");

            migrationBuilder.DropTable(
                name: "LocationMachines");

            migrationBuilder.DropTable(
                name: "MachiningMachines");

            migrationBuilder.DropTable(
                name: "Remainders");

            migrationBuilder.DropTable(
                name: "Stops");

            migrationBuilder.DropTable(
                name: "TechnologicalGroupCrates");

            migrationBuilder.DropTable(
                name: "Trailers");

            migrationBuilder.DropTable(
                name: "Transporters");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "ZatezAP");

            migrationBuilder.DropTable(
                name: "RegionalReports");

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
