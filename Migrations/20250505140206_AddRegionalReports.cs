using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHL.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddRegionalReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_RegionalReportId",
                table: "Attachments",
                column: "RegionalReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "RegionalReports");
        }
    }
}
