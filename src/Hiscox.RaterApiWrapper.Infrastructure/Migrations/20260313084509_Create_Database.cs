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
                name: "BusinessSizeDefinition",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CoverageType = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Revenue = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessSizeDefinition", x => new { x.Version, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "DataValidations",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Peril = table.Column<string>(type: "varchar(55)", nullable: false),
                    DataValidationToUse = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataValidations", x => new { x.Version, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "DisplayedDefaultPerils",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    DefaultPeril = table.Column<string>(type: "varchar(55)", nullable: false),
                    IsSwitchedOnByDefault = table.Column<bool>(type: "bit", nullable: false),
                    DefaultValueWhenSwitchedOn = table.Column<string>(type: "varchar(55)", nullable: false),
                    ApplicableTo = table.Column<string>(type: "varchar(55)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisplayedDefaultPerils", x => new { x.Version, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => new { x.Version, x.Id });
                });

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
                name: "IndustryModifier",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Specialty = table.Column<string>(type: "varchar(100)", nullable: false),
                    NAICSModifier = table.Column<decimal>(type: "decimal(18,15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustryModifier", x => new { x.Version, x.Id });
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
                name: "LimitRetentionFactor",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    LimitRetentionOption = table.Column<long>(type: "bigint", nullable: true),
                    EoLow = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    EoMedium = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    EoHigh = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    FactorGlPremisesOperations = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    FactorGlProductsOperations = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    FactorCyber = table.Column<decimal>(type: "decimal(18,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LimitRetentionFactor", x => new { x.Version, x.Id });
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
                name: "OptionalAdditionalCoverageFactor",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Coverage = table.Column<string>(type: "varchar(100)", nullable: false),
                    YesFactor = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MinimalFactor = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MaterialFactor = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionalAdditionalCoverageFactor", x => new { x.Version, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "OptionalCoverageFactor",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    PercentOfOccLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<string>(type: "varchar(100)", nullable: false),
                    Factor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionalCoverageFactor", x => new { x.Version, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "OptionalCoveragesTable2s",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Coverage = table.Column<string>(type: "varchar(55)", nullable: false),
                    Differential = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionalCoveragesTable2s", x => new { x.Version, x.Id });
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

            migrationBuilder.CreateTable(
                name: "RatingFactorMaster",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Factor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Low = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    High = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DegreeOfConcern = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingFactorMaster", x => new { x.Version, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "RatingFactorSectionEnability",
                columns: table => new
                {
                    Version = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Section = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingFactorSectionEnability", x => new { x.Version, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "RetainedValueFactor",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    RetainedValuePercent = table.Column<int>(type: "int", nullable: false),
                    Factor = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetainedValueFactor", x => new { x.Version, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "RetainedValueFactorMatrix",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    RetainedValue = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    FactorEO = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    FactorGL = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    FactorCyber = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetainedValueFactorMatrix", x => new { x.Version, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "RevenueBaseRate",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Revenue = table.Column<int>(type: "int", nullable: true),
                    BaseRateEO = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GLPremisesOperations1 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GLPremisesOperations2 = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    BaseRateCyber = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    BaseRateTechEO = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    BaseRateAHC = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    BaseRateHomeHealthcare = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    BaseRateSpas = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueBaseRate", x => new { x.Version, x.Id });
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

            migrationBuilder.CreateTable(
                name: "FormEligibility",
                columns: table => new
                {
                    Version = table.Column<string>(type: "varchar(10)", nullable: false),
                    IndustrySpecialtyId = table.Column<int>(type: "int", nullable: false),
                    FormId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormEligibility", x => new { x.Version, x.IndustrySpecialtyId, x.FormId });
                    table.ForeignKey(
                        name: "FK_FormEligibility_Form_Version_FormId",
                        columns: x => new { x.Version, x.FormId },
                        principalTable: "Form",
                        principalColumns: new[] { "Version", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormEligibility_IndustrySpecialty_Version_IndustrySpecialtyId",
                        columns: x => new { x.Version, x.IndustrySpecialtyId },
                        principalTable: "IndustrySpecialty",
                        principalColumns: new[] { "Version", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormEligibility_Version_FormId",
                table: "FormEligibility",
                columns: new[] { "Version", "FormId" });

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
                name: "BusinessSizeDefinition");

            migrationBuilder.DropTable(
                name: "DataValidations");

            migrationBuilder.DropTable(
                name: "DisplayedDefaultPerils");

            migrationBuilder.DropTable(
                name: "FormEligibility");

            migrationBuilder.DropTable(
                name: "FormInfoLookup");

            migrationBuilder.DropTable(
                name: "GeographicMod");

            migrationBuilder.DropTable(
                name: "IncludedCoverageEnhancements");

            migrationBuilder.DropTable(
                name: "IndustryModifier");

            migrationBuilder.DropTable(
                name: "LimitRetentionFactor");

            migrationBuilder.DropTable(
                name: "OptCovTable1");

            migrationBuilder.DropTable(
                name: "OptionalAdditionalCoverageFactor");

            migrationBuilder.DropTable(
                name: "OptionalCoverageFactor");

            migrationBuilder.DropTable(
                name: "OptionalCoveragesTable2s");

            migrationBuilder.DropTable(
                name: "OptionalCoverageTable1");

            migrationBuilder.DropTable(
                name: "PolicyDetails");

            migrationBuilder.DropTable(
                name: "ProjectTypeFactor");

            migrationBuilder.DropTable(
                name: "RatingFactorMaster");

            migrationBuilder.DropTable(
                name: "RatingFactorSectionEnability");

            migrationBuilder.DropTable(
                name: "RetainedValueFactor");

            migrationBuilder.DropTable(
                name: "RetainedValueFactorMatrix");

            migrationBuilder.DropTable(
                name: "RevenueBaseRate");

            migrationBuilder.DropTable(
                name: "Form");

            migrationBuilder.DropTable(
                name: "IndustrySpecialty");

            migrationBuilder.DropTable(
                name: "IndustrySubSector");

            migrationBuilder.DropTable(
                name: "IndustrySector");
        }
    }
}
