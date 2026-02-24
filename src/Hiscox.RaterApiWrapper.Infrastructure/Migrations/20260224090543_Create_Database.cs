using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hiscox.RaterApiWrapper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormInfoLookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LineOfBusiness = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LineOfBusinessShort = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DefaultClaimBasis = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CoverageEnhancements = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormInfoLookup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeographicMod",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Zip = table.Column<string>(type: "varchar(5)", nullable: false),
                    MsaNumber = table.Column<string>(type: "varchar(5)", nullable: false),
                    State = table.Column<string>(type: "varchar(2)", nullable: false),
                    Fips = table.Column<string>(type: "varchar(2)", nullable: false),
                    CountyNumber = table.Column<string>(type: "varchar(3)", nullable: false),
                    MsaName = table.Column<string>(type: "varchar(100)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Tech = table.Column<decimal>(type: "decimal(20,15)", nullable: false),
                    Ahc = table.Column<decimal>(type: "decimal(20,15)", nullable: false),
                    Mpl = table.Column<decimal>(type: "decimal(20,15)", nullable: false),
                    AE = table.Column<decimal>(type: "decimal(20,15)", nullable: false),
                    GlPremOps = table.Column<decimal>(type: "decimal(20,15)", nullable: false),
                    GlProducts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Med = table.Column<decimal>(type: "decimal(20,15)", nullable: false),
                    Cyber = table.Column<decimal>(type: "decimal(20,15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeographicMod", x => new { x.Version, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "IndustrySector",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustrySector", x => new { x.Version, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "PolicyDetails",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    PUID = table.Column<string>(type: "varchar(50)", nullable: true),
                    PolicyNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    NameDescr = table.Column<string>(type: "varchar(200)", nullable: true),
                    Zip = table.Column<string>(type: "varchar(5)", nullable: true),
                    TimestampEffectivePolicy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimestampExpirationPolicy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExposureBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EO_GWP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EO_Retention = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EO_OccLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EO_AggLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EO_2_GWP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EO_2_Retention = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EO_2_OccLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EO_2_AggLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GL_GWP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GL_Retention = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GL_OccLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GL_AggLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cyb_GWP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cyb_Retention = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cyb_OccLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cyb_AggLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyDetails", x => new { x.Version, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "IndustrySubSector",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IndustrySectorId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustrySubSector", x => new { x.Version, x.Id });
                    table.ForeignKey(
                        name: "FK_IndustrySubSector_IndustrySector_Version_IndustrySectorId",
                        columns: x => new { x.Version, x.IndustrySectorId },
                        principalTable: "IndustrySector",
                        principalColumns: new[] { "Version", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndustrySpecialty",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IndustrySubSectorId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustrySpecialty", x => new { x.Version, x.Id });
                    table.ForeignKey(
                        name: "FK_IndustrySpecialty_IndustrySubSector_Version_IndustrySubSectorId",
                        columns: x => new { x.Version, x.IndustrySubSectorId },
                        principalTable: "IndustrySubSector",
                        principalColumns: new[] { "Version", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndustrySpecialty_Version_IndustrySubSectorId",
                table: "IndustrySpecialty",
                columns: new[] { "Version", "IndustrySubSectorId" });

            migrationBuilder.CreateIndex(
                name: "IX_IndustrySubSector_Version_IndustrySectorId",
                table: "IndustrySubSector",
                columns: new[] { "Version", "IndustrySectorId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormInfoLookup");

            migrationBuilder.DropTable(
                name: "GeographicMod");

            migrationBuilder.DropTable(
                name: "IndustrySpecialty");

            migrationBuilder.DropTable(
                name: "PolicyDetails");

            migrationBuilder.DropTable(
                name: "IndustrySubSector");

            migrationBuilder.DropTable(
                name: "IndustrySector");
        }
    }
}
