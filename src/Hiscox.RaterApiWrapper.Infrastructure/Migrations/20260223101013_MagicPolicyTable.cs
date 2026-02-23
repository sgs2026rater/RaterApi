using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hiscox.RaterApiWrapper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MagicPolicyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolicyDetails",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    PUID = table.Column<string>(type: "varchar(50)", nullable: true),
                    PolicyNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    NameDescr = table.Column<string>(type: "varchar(200)", nullable: true),
                    TimestampEffectivePolicy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimestampExpirationPolicy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Zip = table.Column<string>(type: "varchar(5)", nullable: true),
                    Revenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EO_GWP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EO_Retention = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EO_OccLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EO_AggLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EO_2_GWP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EO_2_Retention = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EO_2_OccLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EO_2_AggLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cyb_GWP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cyb_Retention = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cyb_OccLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cyb_AggLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GL_GWP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GL_Retention = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GL_OccLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GL_AggLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyDetails", x => new { x.Version, x.Id });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolicyDetails");
        }
    }
}
