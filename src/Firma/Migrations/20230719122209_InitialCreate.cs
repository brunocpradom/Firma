using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Firma.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cadastral_situation_reason",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cadastral_situation_reason", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_city", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "legal_nature",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legal_nature", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lucro",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    year = table.Column<int>(type: "integer", nullable: false),
                    scp_tax_id = table.Column<string>(type: "text", nullable: false),
                    form_of_taxation = table.Column<string>(type: "text", nullable: false),
                    amount_of_book_keeping = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lucro", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mei",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    opting = table.Column<bool>(type: "boolean", nullable: false),
                    inclusion_date = table.Column<DateOnly>(type: "date", nullable: true),
                    exclusion_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mei", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "qualification",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_qualification", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "secondary_cnaes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_secondary_cnaes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "simples",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    opting = table.Column<bool>(type: "boolean", nullable: false),
                    inclusion_date = table.Column<DateOnly>(type: "date", nullable: true),
                    exclusion_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_simples", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "adress",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    foreign_city_name = table.Column<string>(type: "text", nullable: false),
                    country_id = table.Column<int>(type: "integer", nullable: false),
                    street_type = table.Column<string>(type: "text", nullable: false),
                    street_address = table.Column<string>(type: "text", nullable: false),
                    number = table.Column<string>(type: "text", nullable: false),
                    complement = table.Column<string>(type: "text", nullable: false),
                    neighborhood = table.Column<string>(type: "text", nullable: false),
                    zip_code = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    city_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_adress", x => x.id);
                    table.ForeignKey(
                        name: "fk_adress_city_city_id",
                        column: x => x.city_id,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_adress_country_country_id",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    basic_tax_id = table.Column<string>(type: "text", nullable: false),
                    registered_name = table.Column<string>(type: "text", nullable: false),
                    legal_nature_id = table.Column<int>(type: "integer", nullable: false),
                    share_capital = table.Column<int>(type: "integer", nullable: false),
                    company_size = table.Column<int>(type: "integer", nullable: false),
                    responsible_federal_entity = table.Column<string>(type: "text", nullable: true),
                    qualification_of_person_in_charge_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_company", x => x.id);
                    table.ForeignKey(
                        name: "fk_company_legal_nature_legal_nature_id",
                        column: x => x.legal_nature_id,
                        principalTable: "legal_nature",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_company_qualification_qualification_of_person_in_charge_id",
                        column: x => x.qualification_of_person_in_charge_id,
                        principalTable: "qualification",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "cnae",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    secondary_cnaes_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cnae", x => x.id);
                    table.ForeignKey(
                        name: "fk_cnae_secondary_cnaes_secondary_cnaes_id",
                        column: x => x.secondary_cnaes_id,
                        principalTable: "secondary_cnaes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "partner",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<int>(type: "integer", nullable: false),
                    identifier = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    document_number = table.Column<string>(type: "text", nullable: false),
                    qualification_id = table.Column<int>(type: "integer", nullable: true),
                    age_group = table.Column<int>(type: "integer", nullable: true),
                    company_joining_date = table.Column<DateOnly>(type: "date", nullable: false),
                    country_id = table.Column<int>(type: "integer", nullable: true),
                    legal_representative = table.Column<string>(type: "text", nullable: false),
                    representative_name = table.Column<string>(type: "text", nullable: false),
                    representative_qualification_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_partner", x => x.id);
                    table.ForeignKey(
                        name: "fk_partner_company_company_id",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_partner_country_country_id",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_partner_qualification_qualification_id",
                        column: x => x.qualification_id,
                        principalTable: "qualification",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_partner_qualification_representative_qualification_id",
                        column: x => x.representative_qualification_id,
                        principalTable: "qualification",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tax_regime",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<int>(type: "integer", nullable: false),
                    mei_id = table.Column<int>(type: "integer", nullable: true),
                    simples_id = table.Column<int>(type: "integer", nullable: true),
                    lucro_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tax_regime", x => x.id);
                    table.ForeignKey(
                        name: "fk_tax_regime_company_company_id",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tax_regime_lucro_lucro_id",
                        column: x => x.lucro_id,
                        principalTable: "lucro",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_tax_regime_mei_mei_id",
                        column: x => x.mei_id,
                        principalTable: "mei",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_tax_regime_simples_simples_id",
                        column: x => x.simples_id,
                        principalTable: "simples",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "main_cnae",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cnae_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_main_cnae", x => x.id);
                    table.ForeignKey(
                        name: "fk_main_cnae_cnae_cnae_id",
                        column: x => x.cnae_id,
                        principalTable: "cnae",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "establishment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<int>(type: "integer", nullable: false),
                    tax_id = table.Column<string>(type: "text", nullable: false),
                    identifier = table.Column<int>(type: "integer", nullable: false),
                    trade_name = table.Column<string>(type: "text", nullable: true),
                    activity_start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    main_cnae_id = table.Column<int>(type: "integer", nullable: false),
                    secondary_cnaes_id = table.Column<int>(type: "integer", nullable: true),
                    address_id = table.Column<int>(type: "integer", nullable: false),
                    cnae_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_establishment", x => x.id);
                    table.ForeignKey(
                        name: "fk_establishment_adress_address_id",
                        column: x => x.address_id,
                        principalTable: "adress",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_establishment_cnae_cnae_id",
                        column: x => x.cnae_id,
                        principalTable: "cnae",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_establishment_company_company_id",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_establishment_main_cnae_main_cnae_id",
                        column: x => x.main_cnae_id,
                        principalTable: "main_cnae",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_establishment_secondary_cnaes_secondary_cnaes_id",
                        column: x => x.secondary_cnaes_id,
                        principalTable: "secondary_cnaes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "cadastral_situation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    establishment_id = table.Column<int>(type: "integer", nullable: false),
                    situation = table.Column<int>(type: "integer", nullable: false),
                    cadastral_situation_date = table.Column<DateOnly>(type: "date", nullable: false),
                    cadastral_situation_reason_id = table.Column<int>(type: "integer", nullable: false),
                    special_situation = table.Column<string>(type: "text", nullable: false),
                    special_situation_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cadastral_situation", x => x.id);
                    table.ForeignKey(
                        name: "fk_cadastral_situation_cadastral_situation_reason_cadastral_sit",
                        column: x => x.cadastral_situation_reason_id,
                        principalTable: "cadastral_situation_reason",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cadastral_situation_establishment_establishment_id",
                        column: x => x.establishment_id,
                        principalTable: "establishment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "email",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    establishment_id = table.Column<int>(type: "integer", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_email", x => x.id);
                    table.ForeignKey(
                        name: "fk_email_establishment_establishment_id",
                        column: x => x.establishment_id,
                        principalTable: "establishment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "telephone",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    establishment_id = table.Column<int>(type: "integer", nullable: false),
                    ddd = table.Column<string>(type: "text", nullable: false),
                    number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_telephone", x => x.id);
                    table.ForeignKey(
                        name: "fk_telephone_establishment_establishment_id",
                        column: x => x.establishment_id,
                        principalTable: "establishment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_adress_city_id",
                table: "adress",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "ix_adress_country_id",
                table: "adress",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_cadastral_situation_cadastral_situation_reason_id",
                table: "cadastral_situation",
                column: "cadastral_situation_reason_id");

            migrationBuilder.CreateIndex(
                name: "ix_cadastral_situation_establishment_id",
                table: "cadastral_situation",
                column: "establishment_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_cnae_secondary_cnaes_id",
                table: "cnae",
                column: "secondary_cnaes_id");

            migrationBuilder.CreateIndex(
                name: "ix_company_legal_nature_id",
                table: "company",
                column: "legal_nature_id");

            migrationBuilder.CreateIndex(
                name: "ix_company_qualification_of_person_in_charge_id",
                table: "company",
                column: "qualification_of_person_in_charge_id");

            migrationBuilder.CreateIndex(
                name: "ix_email_establishment_id",
                table: "email",
                column: "establishment_id");

            migrationBuilder.CreateIndex(
                name: "ix_establishment_address_id",
                table: "establishment",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "ix_establishment_cnae_id",
                table: "establishment",
                column: "cnae_id");

            migrationBuilder.CreateIndex(
                name: "ix_establishment_company_id",
                table: "establishment",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_establishment_main_cnae_id",
                table: "establishment",
                column: "main_cnae_id");

            migrationBuilder.CreateIndex(
                name: "ix_establishment_secondary_cnaes_id",
                table: "establishment",
                column: "secondary_cnaes_id");

            migrationBuilder.CreateIndex(
                name: "ix_main_cnae_cnae_id",
                table: "main_cnae",
                column: "cnae_id");

            migrationBuilder.CreateIndex(
                name: "ix_partner_company_id",
                table: "partner",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_partner_country_id",
                table: "partner",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_partner_qualification_id",
                table: "partner",
                column: "qualification_id");

            migrationBuilder.CreateIndex(
                name: "ix_partner_representative_qualification_id",
                table: "partner",
                column: "representative_qualification_id");

            migrationBuilder.CreateIndex(
                name: "ix_tax_regime_company_id",
                table: "tax_regime",
                column: "company_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_tax_regime_lucro_id",
                table: "tax_regime",
                column: "lucro_id");

            migrationBuilder.CreateIndex(
                name: "ix_tax_regime_mei_id",
                table: "tax_regime",
                column: "mei_id");

            migrationBuilder.CreateIndex(
                name: "ix_tax_regime_simples_id",
                table: "tax_regime",
                column: "simples_id");

            migrationBuilder.CreateIndex(
                name: "ix_telephone_establishment_id",
                table: "telephone",
                column: "establishment_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cadastral_situation");

            migrationBuilder.DropTable(
                name: "email");

            migrationBuilder.DropTable(
                name: "partner");

            migrationBuilder.DropTable(
                name: "tax_regime");

            migrationBuilder.DropTable(
                name: "telephone");

            migrationBuilder.DropTable(
                name: "cadastral_situation_reason");

            migrationBuilder.DropTable(
                name: "lucro");

            migrationBuilder.DropTable(
                name: "mei");

            migrationBuilder.DropTable(
                name: "simples");

            migrationBuilder.DropTable(
                name: "establishment");

            migrationBuilder.DropTable(
                name: "adress");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "main_cnae");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "legal_nature");

            migrationBuilder.DropTable(
                name: "qualification");

            migrationBuilder.DropTable(
                name: "cnae");

            migrationBuilder.DropTable(
                name: "secondary_cnaes");
        }
    }
}
