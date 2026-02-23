using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hiscox.RaterApiWrapper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FormInfoLookup : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormInfoLookup");
        }
    }
}
