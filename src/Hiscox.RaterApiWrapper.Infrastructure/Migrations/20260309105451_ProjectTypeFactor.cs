using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hiscox.RaterApiWrapper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProjectTypeFactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectTypeFactor",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProjectType = table.Column<string>(type: "varchar(100)", nullable: false),
                    Factor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypeFactor", x => new { x.Version, x.Id });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTypeFactor");
        }
    }
}
