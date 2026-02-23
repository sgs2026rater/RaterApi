using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hiscox.RaterApiWrapper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "GeographicMod");

            migrationBuilder.DropTable(
                name: "IndustrySpecialty");

            migrationBuilder.DropTable(
                name: "IndustrySubSector");

            migrationBuilder.DropTable(
                name: "IndustrySector");
        }
    }
}
