using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hiscox.RaterApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "business_size_definitions",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    coverage_type = table.Column<int>(type: "integer", nullable: false),
                    size = table.Column<int>(type: "integer", nullable: false),
                    revenue = table.Column<decimal>(type: "numeric(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_business_size_definitions", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "data_validations",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    peril = table.Column<string>(type: "varchar(55)", nullable: false),
                    data_validation_to_use = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_data_validations", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "displayed_default_perils",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    default_peril = table.Column<string>(type: "varchar(55)", nullable: false),
                    is_switched_on_by_default = table.Column<bool>(type: "boolean", nullable: false),
                    default_value_when_switched_on = table.Column<string>(type: "varchar(55)", nullable: false),
                    applicable_to = table.Column<string>(type: "varchar(55)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_displayed_default_perils", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "form_info_lookups",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    form_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    line_of_business = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    line_of_business_short = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    default_claim_basis = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    coverage_enhancements = table.Column<string>(type: "varchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_form_info_lookups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "forms",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_forms", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "geographic_mods",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    zip = table.Column<string>(type: "varchar(5)", nullable: false),
                    msa_number = table.Column<string>(type: "varchar(5)", nullable: false),
                    state = table.Column<string>(type: "varchar(2)", nullable: false),
                    fips = table.Column<string>(type: "varchar(2)", nullable: false),
                    county_number = table.Column<string>(type: "varchar(3)", nullable: false),
                    msa_name = table.Column<string>(type: "varchar(100)", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    tech = table.Column<decimal>(type: "numeric(20,15)", nullable: false),
                    ahc = table.Column<decimal>(type: "numeric(20,15)", nullable: false),
                    mpl = table.Column<decimal>(type: "numeric(20,15)", nullable: false),
                    ae = table.Column<decimal>(type: "numeric(20,15)", nullable: false),
                    gl_prem_ops = table.Column<decimal>(type: "numeric(20,15)", nullable: false),
                    gl_products = table.Column<decimal>(type: "numeric", nullable: false),
                    med = table.Column<decimal>(type: "numeric(20,15)", nullable: false),
                    cyber = table.Column<decimal>(type: "numeric(20,15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_geographic_mods", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "included_coverage_enhancements",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    form = table.Column<string>(type: "varchar(55)", nullable: false),
                    line_of_business = table.Column<string>(type: "varchar(55)", nullable: false),
                    shortened_line_of_business = table.Column<string>(type: "varchar(10)", nullable: false),
                    claims_mode = table.Column<string>(type: "varchar(50)", nullable: false),
                    coverage_enhancements = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_included_coverage_enhancements", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "industry_modifiers",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    specialty = table.Column<string>(type: "varchar(100)", nullable: false),
                    naics_modifier = table.Column<decimal>(type: "numeric(18,15)", nullable: false),
                    eo_minimum_premium = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_industry_modifiers", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "industry_sectors",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_industry_sectors", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "limit_retention_factors",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    limit_retention_option = table.Column<long>(type: "bigint", nullable: true),
                    eo_low = table.Column<decimal>(type: "numeric(18,4)", nullable: true),
                    eo_medium = table.Column<decimal>(type: "numeric(18,4)", nullable: true),
                    eo_high = table.Column<decimal>(type: "numeric(18,4)", nullable: true),
                    factor_gl_premises_operations = table.Column<decimal>(type: "numeric(18,4)", nullable: true),
                    factor_gl_products_operations = table.Column<decimal>(type: "numeric(18,4)", nullable: true),
                    factor_cyber = table.Column<decimal>(type: "numeric(18,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_limit_retention_factors", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "opt_cov_table1",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    optional_coverage = table.Column<string>(type: "varchar(55)", nullable: false),
                    applicable_to_coverage_or_gtc = table.Column<string>(type: "varchar(15)", nullable: false),
                    applicable_to_form_or_endorsement = table.Column<string>(type: "varchar(25)", nullable: false),
                    e_number = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_opt_cov_table1", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "optional_additional_coverage_factors",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    coverage = table.Column<string>(type: "varchar(100)", nullable: false),
                    yes_factor = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    minimal_factor = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    material_factor = table.Column<decimal>(type: "numeric(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_optional_additional_coverage_factors", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "optional_coverage_factors",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    percent_of_occ_limit = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    type = table.Column<string>(type: "varchar(100)", nullable: false),
                    factor = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_optional_coverage_factors", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "optional_coverages_table1",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    optional_additional_coverage = table.Column<string>(type: "varchar(55)", nullable: false),
                    value_of_insurance = table.Column<string>(type: "varchar(55)", nullable: false),
                    premium = table.Column<string>(type: "varchar(55)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_optional_coverages_table1", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "optional_coverages_table2",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    coverage = table.Column<string>(type: "varchar(55)", nullable: false),
                    differential = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_optional_coverages_table2", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "policies",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    puid = table.Column<string>(type: "varchar(50)", nullable: true),
                    policy_no = table.Column<string>(type: "varchar(50)", nullable: true),
                    name_descr = table.Column<string>(type: "varchar(200)", nullable: true),
                    zip = table.Column<string>(type: "varchar(5)", nullable: true),
                    timestamp_effective_policy = table.Column<DateTime>(type: "timestamp", nullable: false),
                    timestamp_expiration_policy = table.Column<DateTime>(type: "timestamp", nullable: false),
                    exposure_base = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    eo_gwp = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    eo__retention = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    eo__occ_limit = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    eo__agg_limit = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    eo_2_gwp = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    eo_2__retention = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    eo_2__occ_limit = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    eo_2__agg_limit = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    gl_gwp = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    gl__retention = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    gl__occ_limit = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    gl__agg_limit = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    cyb_gwp = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    cyb__retention = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    cyb__occ_limit = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    cyb__agg_limit = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_policies", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "project_type_factors",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    project_type = table.Column<string>(type: "varchar(100)", nullable: false),
                    factor = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_project_type_factors", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "rating_factor_master",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    section_id = table.Column<int>(type: "integer", nullable: false),
                    question_id = table.Column<int>(type: "integer", nullable: false),
                    answer = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    factor = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    low = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    high = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    degree_of_concern = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rating_factor_master", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "rating_factor_section_enabilities",
                columns: table => new
                {
                    version = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    section = table.Column<int>(type: "integer", maxLength: 200, nullable: false),
                    size = table.Column<int>(type: "integer", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rating_factor_section_enabilities", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "retained_value_factor_matrix",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    retained_value = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    factor_eo = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    factor_gl = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    factor_cyber = table.Column<decimal>(type: "numeric(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_retained_value_factor_matrix", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "retained_value_factors",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    retained_value_percent = table.Column<int>(type: "int", nullable: false),
                    factor = table.Column<decimal>(type: "numeric(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_retained_value_factors", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "revenue_base_rates",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    revenue = table.Column<int>(type: "integer", nullable: true),
                    base_rate_eo = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    gl_premises_operations1 = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    gl_premises_operations2 = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    base_rate_cyber = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    base_rate_tech_eo = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    base_rate_ahc = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    base_rate_home_healthcare = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    base_rate_spas = table.Column<decimal>(type: "numeric(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_revenue_base_rates", x => new { x.version, x.id });
                });

            migrationBuilder.CreateTable(
                name: "industry_sub_sectors",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    industry_sector_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_industry_sub_sectors", x => new { x.version, x.id });
                    table.ForeignKey(
                        name: "fk_industry_sub_sectors_industry_sectors_version_industry_sect~",
                        columns: x => new { x.version, x.industry_sector_id },
                        principalTable: "industry_sectors",
                        principalColumns: new[] { "version", "id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "industry_specialties",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    industry_sub_sector_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_industry_specialties", x => new { x.version, x.id });
                    table.ForeignKey(
                        name: "fk_industry_specialties__industry_sub_sectors_version_industry_su~",
                        columns: x => new { x.version, x.industry_sub_sector_id },
                        principalTable: "industry_sub_sectors",
                        principalColumns: new[] { "version", "id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "form_eligibilities",
                columns: table => new
                {
                    version = table.Column<string>(type: "varchar(10)", nullable: false),
                    industry_specialty_id = table.Column<int>(type: "integer", nullable: false),
                    form_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_form_eligibilities", x => new { x.version, x.industry_specialty_id, x.form_id });
                    table.ForeignKey(
                        name: "fk_form_eligibilities__industry_specialties_version_industry_spe~",
                        columns: x => new { x.version, x.industry_specialty_id },
                        principalTable: "industry_specialties",
                        principalColumns: new[] { "version", "id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_form_eligibilities_forms_version_form_id",
                        columns: x => new { x.version, x.form_id },
                        principalTable: "forms",
                        principalColumns: new[] { "version", "id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_form_eligibilities_version_form_id",
                table: "form_eligibilities",
                columns: new[] { "version", "form_id" });

            migrationBuilder.CreateIndex(
                name: "ix_industry_specialties_version_industry_sub_sector_id",
                table: "industry_specialties",
                columns: new[] { "version", "industry_sub_sector_id" });

            migrationBuilder.CreateIndex(
                name: "ix_industry_sub_sectors_version_industry_sector_id",
                table: "industry_sub_sectors",
                columns: new[] { "version", "industry_sector_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "business_size_definitions");

            migrationBuilder.DropTable(
                name: "data_validations");

            migrationBuilder.DropTable(
                name: "displayed_default_perils");

            migrationBuilder.DropTable(
                name: "form_eligibilities");

            migrationBuilder.DropTable(
                name: "form_info_lookups");

            migrationBuilder.DropTable(
                name: "geographic_mods");

            migrationBuilder.DropTable(
                name: "included_coverage_enhancements");

            migrationBuilder.DropTable(
                name: "industry_modifiers");

            migrationBuilder.DropTable(
                name: "limit_retention_factors");

            migrationBuilder.DropTable(
                name: "opt_cov_table1");

            migrationBuilder.DropTable(
                name: "optional_additional_coverage_factors");

            migrationBuilder.DropTable(
                name: "optional_coverage_factors");

            migrationBuilder.DropTable(
                name: "optional_coverages_table1");

            migrationBuilder.DropTable(
                name: "optional_coverages_table2");

            migrationBuilder.DropTable(
                name: "policies");

            migrationBuilder.DropTable(
                name: "project_type_factors");

            migrationBuilder.DropTable(
                name: "rating_factor_master");

            migrationBuilder.DropTable(
                name: "rating_factor_section_enabilities");

            migrationBuilder.DropTable(
                name: "retained_value_factor_matrix");

            migrationBuilder.DropTable(
                name: "retained_value_factors");

            migrationBuilder.DropTable(
                name: "revenue_base_rates");

            migrationBuilder.DropTable(
                name: "industry_specialties");

            migrationBuilder.DropTable(
                name: "forms");

            migrationBuilder.DropTable(
                name: "industry_sub_sectors");

            migrationBuilder.DropTable(
                name: "industry_sectors");
        }
    }
}
