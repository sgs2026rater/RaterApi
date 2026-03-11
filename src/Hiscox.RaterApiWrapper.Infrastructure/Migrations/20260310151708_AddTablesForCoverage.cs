using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hiscox.RaterApiWrapper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesForCoverage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncludedCoverageEnhancements",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Form = table.Column<string>(type: "varchar(55)", nullable: false),
                    LineOfBusiness = table.Column<string>(type: "varchar(55)", nullable: false),
                    ShortenedLineOfBusiness = table.Column<string>(type: "varchar(10)", nullable: false),
                    ClaimsMode = table.Column<string>(type: "varchar(50)", nullable: false),
                    CoverageEnhancements = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncludedCoverageEnhancements", x => new { x.Version, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "OptCovTable1",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    OptionalCoverage = table.Column<string>(type: "varchar(55)", nullable: false),
                    ApplicableToCoverageOrGTC = table.Column<string>(type: "varchar(15)", nullable: false),
                    ApplicableToFormOrEndorsement = table.Column<string>(type: "varchar(25)", nullable: false),
                    ENumber = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptCovTable1", x => new { x.Version, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "OptionalCoverageTable1",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    OptionalAdditionalCoverage = table.Column<string>(type: "varchar(55)", nullable: false),
                    ValueOfInsurance = table.Column<string>(type: "varchar(55)", nullable: false),
                    Premium = table.Column<string>(type: "varchar(55)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionalCoverageTable1", x => new { x.Version, x.Id });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncludedCoverageEnhancements");

            migrationBuilder.DropTable(
                name: "OptCovTable1");

            migrationBuilder.DropTable(
                name: "OptionalCoverageTable1");
        }
    }
}
