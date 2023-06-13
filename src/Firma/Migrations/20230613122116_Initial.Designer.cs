﻿// <auto-generated />
using System;
using Firma.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Firma.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230613122116_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Firma.Models.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BasicTaxId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("basic_tax_id");

                    b.Property<int>("CompanySize")
                        .HasColumnType("integer")
                        .HasColumnName("company_size");

                    b.Property<int>("LegalNatureId")
                        .HasColumnType("integer")
                        .HasColumnName("legal_nature_id");

                    b.Property<int?>("QualificationOfPersonInCharge")
                        .HasColumnType("integer")
                        .HasColumnName("qualification_of_person_in_charge");

                    b.Property<string>("RegisteredName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("registered_name");

                    b.Property<string>("ResponsibleFederalEntity")
                        .HasColumnType("text")
                        .HasColumnName("responsible_federal_entity");

                    b.Property<int>("ShareCapital")
                        .HasColumnType("integer")
                        .HasColumnName("share_capital");

                    b.HasKey("Id")
                        .HasName("pk_company");

                    b.HasIndex("LegalNatureId")
                        .HasDatabaseName("ix_company_legal_nature_id");

                    b.ToTable("company", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Entities.Establishment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("ActivityStartDate")
                        .HasColumnType("date")
                        .HasColumnName("activity_start_date");

                    b.Property<int>("AdressId")
                        .HasColumnType("integer")
                        .HasColumnName("adress_id");

                    b.Property<int>("CadastralSituationId")
                        .HasColumnType("integer")
                        .HasColumnName("cadastral_situation_id");

                    b.Property<int?>("CnaeId")
                        .HasColumnType("integer")
                        .HasColumnName("cnae_id");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer")
                        .HasColumnName("company_id");

                    b.Property<int>("Identifier")
                        .HasColumnType("integer")
                        .HasColumnName("identifier");

                    b.Property<int>("MainCnaeId")
                        .HasColumnType("integer")
                        .HasColumnName("main_cnae_id");

                    b.Property<int?>("SecondaryCnaesId")
                        .HasColumnType("integer")
                        .HasColumnName("secondary_cnaes_id");

                    b.Property<string>("TaxId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("tax_id");

                    b.Property<string>("TradeName")
                        .HasColumnType("text")
                        .HasColumnName("trade_name");

                    b.HasKey("Id")
                        .HasName("pk_establishment");

                    b.HasIndex("AdressId")
                        .HasDatabaseName("ix_establishment_adress_id");

                    b.HasIndex("CadastralSituationId")
                        .HasDatabaseName("ix_establishment_cadastral_situation_id");

                    b.HasIndex("CnaeId")
                        .HasDatabaseName("ix_establishment_cnae_id");

                    b.HasIndex("CompanyId")
                        .HasDatabaseName("ix_establishment_company_id");

                    b.HasIndex("MainCnaeId")
                        .HasDatabaseName("ix_establishment_main_cnae_id");

                    b.HasIndex("SecondaryCnaesId")
                        .HasDatabaseName("ix_establishment_secondary_cnaes_id");

                    b.ToTable("establishment", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Entities.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AgeGroupId")
                        .HasColumnType("integer")
                        .HasColumnName("age_group_id");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer")
                        .HasColumnName("company_id");

                    b.Property<DateOnly>("CompanyJoiningDate")
                        .HasColumnType("date")
                        .HasColumnName("company_joining_date");

                    b.Property<int?>("CountryId")
                        .HasColumnType("integer")
                        .HasColumnName("country_id");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("document_number");

                    b.Property<int>("Identifier")
                        .HasColumnType("integer")
                        .HasColumnName("identifier");

                    b.Property<string>("LegalRepresentative")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("legal_representative");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int?>("QualificationId")
                        .HasColumnType("integer")
                        .HasColumnName("qualification_id");

                    b.Property<string>("RepresentativeName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("representative_name");

                    b.Property<string>("RepresentativeQualification")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("representative_qualification");

                    b.HasKey("Id")
                        .HasName("pk_partner");

                    b.HasIndex("AgeGroupId")
                        .HasDatabaseName("ix_partner_age_group_id");

                    b.HasIndex("CompanyId")
                        .HasDatabaseName("ix_partner_company_id");

                    b.HasIndex("CountryId")
                        .HasDatabaseName("ix_partner_country_id");

                    b.HasIndex("QualificationId")
                        .HasDatabaseName("ix_partner_qualification_id");

                    b.ToTable("partner", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Values.Contact.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("integer")
                        .HasColumnName("city_id");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("complement");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer")
                        .HasColumnName("country_id");

                    b.Property<string>("ForeignCityName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("foreign_city_name");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("neighborhood");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("number");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("state");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("street_address");

                    b.Property<string>("StreetType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("street_type");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("zip_code");

                    b.HasKey("Id")
                        .HasName("pk_adress");

                    b.HasIndex("CityId")
                        .HasDatabaseName("ix_adress_city_id");

                    b.HasIndex("CountryId")
                        .HasDatabaseName("ix_adress_country_id");

                    b.ToTable("adress", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Values.Contact.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_city");

                    b.ToTable("city", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Values.Contact.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_country");

                    b.ToTable("country", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Values.Contact.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<int?>("EstablishmentId")
                        .HasColumnType("integer")
                        .HasColumnName("establishment_id");

                    b.HasKey("Id")
                        .HasName("pk_email");

                    b.HasIndex("EstablishmentId")
                        .HasDatabaseName("ix_email_establishment_id");

                    b.ToTable("email", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Values.Contact.Telephone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ddd");

                    b.Property<int?>("EstablishmentId")
                        .HasColumnType("integer")
                        .HasColumnName("establishment_id");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("number");

                    b.HasKey("Id")
                        .HasName("pk_telephone");

                    b.HasIndex("EstablishmentId")
                        .HasDatabaseName("ix_telephone_establishment_id");

                    b.ToTable("telephone", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Values.Legal.CadastralSituation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("CadastralSituationDate")
                        .HasColumnType("date")
                        .HasColumnName("cadastral_situation_date");

                    b.Property<string>("CadastralSituationReason")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cadastral_situation_reason");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<int>("Situation")
                        .HasColumnType("integer")
                        .HasColumnName("situation");

                    b.Property<string>("SpecialSituation")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("special_situation");

                    b.Property<DateOnly>("SpecialSituationDate")
                        .HasColumnType("date")
                        .HasColumnName("special_situation_date");

                    b.HasKey("Id")
                        .HasName("pk_cadastral_situation");

                    b.ToTable("cadastral_situation", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Values.Legal.Cnae", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int?>("SecondaryCnaesId")
                        .HasColumnType("integer")
                        .HasColumnName("secondary_cnaes_id");

                    b.HasKey("Id")
                        .HasName("pk_cnae");

                    b.HasIndex("SecondaryCnaesId")
                        .HasDatabaseName("ix_cnae_secondary_cnaes_id");

                    b.ToTable("cnae", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Values.Legal.LegalNature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.HasKey("Id")
                        .HasName("pk_legal_nature");

                    b.ToTable("legal_nature", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Values.Legal.MainCnae", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CnaeId")
                        .HasColumnType("integer")
                        .HasColumnName("cnae_id");

                    b.HasKey("Id")
                        .HasName("pk_main_cnae");

                    b.HasIndex("CnaeId")
                        .HasDatabaseName("ix_main_cnae_cnae_id");

                    b.ToTable("main_cnae", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Values.Legal.SecondaryCnaes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id")
                        .HasName("pk_secondary_cnaes");

                    b.ToTable("secondary_cnaes", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Values.Partner.AgeGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.HasKey("Id")
                        .HasName("pk_age_group");

                    b.ToTable("age_group", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Values.Partner.Qualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.HasKey("Id")
                        .HasName("pk_qualification");

                    b.ToTable("qualification", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Values.TaxationModel.Lucro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AmountOfBookKeeping")
                        .HasColumnType("integer")
                        .HasColumnName("amount_of_book_keeping");

                    b.Property<string>("FormOfTaxation")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("form_of_taxation");

                    b.Property<string>("ScpTaxId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("scp_tax_id");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id")
                        .HasName("pk_lucro");

                    b.ToTable("lucro", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Values.TaxationModel.Mei", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("ExclusionDate")
                        .HasColumnType("date")
                        .HasColumnName("exclusion_date");

                    b.Property<DateOnly>("InclusionDate")
                        .HasColumnType("date")
                        .HasColumnName("inclusion_date");

                    b.Property<bool>("Opting")
                        .HasColumnType("boolean")
                        .HasColumnName("opting");

                    b.HasKey("Id")
                        .HasName("pk_mei");

                    b.ToTable("mei", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Values.TaxationModel.Simples", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("ExclusionDate")
                        .HasColumnType("date")
                        .HasColumnName("exclusion_date");

                    b.Property<DateOnly>("InclusionDate")
                        .HasColumnType("date")
                        .HasColumnName("inclusion_date");

                    b.Property<bool>("Opting")
                        .HasColumnType("boolean")
                        .HasColumnName("opting");

                    b.HasKey("Id")
                        .HasName("pk_simples");

                    b.ToTable("simples", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Values.TaxationModel.TaxRegime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer")
                        .HasColumnName("company_id");

                    b.Property<int?>("LucroId")
                        .HasColumnType("integer")
                        .HasColumnName("lucro_id");

                    b.Property<int?>("MeiId")
                        .HasColumnType("integer")
                        .HasColumnName("mei_id");

                    b.Property<int?>("SimplesId")
                        .HasColumnType("integer")
                        .HasColumnName("simples_id");

                    b.HasKey("Id")
                        .HasName("pk_tax_regime");

                    b.HasIndex("CompanyId")
                        .IsUnique()
                        .HasDatabaseName("ix_tax_regime_company_id");

                    b.HasIndex("LucroId")
                        .HasDatabaseName("ix_tax_regime_lucro_id");

                    b.HasIndex("MeiId")
                        .HasDatabaseName("ix_tax_regime_mei_id");

                    b.HasIndex("SimplesId")
                        .HasDatabaseName("ix_tax_regime_simples_id");

                    b.ToTable("tax_regime", (string)null);
                });

            modelBuilder.Entity("Firma.Models.Entities.Company", b =>
                {
                    b.HasOne("Firma.Models.Values.Legal.LegalNature", "LegalNature")
                        .WithMany()
                        .HasForeignKey("LegalNatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_company_legal_nature_legal_nature_id");

                    b.Navigation("LegalNature");
                });

            modelBuilder.Entity("Firma.Models.Entities.Establishment", b =>
                {
                    b.HasOne("Firma.Models.Values.Contact.Adress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_establishment_adress_adress_id");

                    b.HasOne("Firma.Models.Values.Legal.CadastralSituation", "CadastralSituation")
                        .WithMany()
                        .HasForeignKey("CadastralSituationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_establishment_cadastral_situation_cadastral_situation_id");

                    b.HasOne("Firma.Models.Values.Legal.Cnae", null)
                        .WithMany("Estabelecimentos")
                        .HasForeignKey("CnaeId")
                        .HasConstraintName("fk_establishment_cnae_cnae_id");

                    b.HasOne("Firma.Models.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_establishment_company_company_id");

                    b.HasOne("Firma.Models.Values.Legal.MainCnae", "MainCnae")
                        .WithMany()
                        .HasForeignKey("MainCnaeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_establishment_main_cnae_main_cnae_id");

                    b.HasOne("Firma.Models.Values.Legal.SecondaryCnaes", "SecondaryCnaes")
                        .WithMany()
                        .HasForeignKey("SecondaryCnaesId")
                        .HasConstraintName("fk_establishment_secondary_cnaes_secondary_cnaes_id");

                    b.Navigation("Adress");

                    b.Navigation("CadastralSituation");

                    b.Navigation("Company");

                    b.Navigation("MainCnae");

                    b.Navigation("SecondaryCnaes");
                });

            modelBuilder.Entity("Firma.Models.Entities.Partner", b =>
                {
                    b.HasOne("Firma.Models.Values.Partner.AgeGroup", "AgeGroup")
                        .WithMany()
                        .HasForeignKey("AgeGroupId")
                        .HasConstraintName("fk_partner_age_group_age_group_id");

                    b.HasOne("Firma.Models.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_partner_company_company_id");

                    b.HasOne("Firma.Models.Values.Contact.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .HasConstraintName("fk_partner_country_country_id");

                    b.HasOne("Firma.Models.Values.Partner.Qualification", "Qualification")
                        .WithMany()
                        .HasForeignKey("QualificationId")
                        .HasConstraintName("fk_partner_qualification_qualification_id");

                    b.Navigation("AgeGroup");

                    b.Navigation("Company");

                    b.Navigation("Country");

                    b.Navigation("Qualification");
                });

            modelBuilder.Entity("Firma.Models.Values.Contact.Adress", b =>
                {
                    b.HasOne("Firma.Models.Values.Contact.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_adress_city_city_id");

                    b.HasOne("Firma.Models.Values.Contact.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_adress_country_country_id");

                    b.Navigation("City");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Firma.Models.Values.Contact.Email", b =>
                {
                    b.HasOne("Firma.Models.Entities.Establishment", null)
                        .WithMany("Email")
                        .HasForeignKey("EstablishmentId")
                        .HasConstraintName("fk_email_establishment_establishment_id");
                });

            modelBuilder.Entity("Firma.Models.Values.Contact.Telephone", b =>
                {
                    b.HasOne("Firma.Models.Entities.Establishment", null)
                        .WithMany("Telephone")
                        .HasForeignKey("EstablishmentId")
                        .HasConstraintName("fk_telephone_establishment_establishment_id");
                });

            modelBuilder.Entity("Firma.Models.Values.Legal.Cnae", b =>
                {
                    b.HasOne("Firma.Models.Values.Legal.SecondaryCnaes", null)
                        .WithMany("Cnaes")
                        .HasForeignKey("SecondaryCnaesId")
                        .HasConstraintName("fk_cnae_secondary_cnaes_secondary_cnaes_id");
                });

            modelBuilder.Entity("Firma.Models.Values.Legal.MainCnae", b =>
                {
                    b.HasOne("Firma.Models.Values.Legal.Cnae", "Cnae")
                        .WithMany()
                        .HasForeignKey("CnaeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_main_cnae_cnae_cnae_id");

                    b.Navigation("Cnae");
                });

            modelBuilder.Entity("Firma.Models.Values.TaxationModel.TaxRegime", b =>
                {
                    b.HasOne("Firma.Models.Entities.Company", "Company")
                        .WithOne("TaxRegime")
                        .HasForeignKey("Firma.Models.Values.TaxationModel.TaxRegime", "CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tax_regime_company_company_id");

                    b.HasOne("Firma.Models.Values.TaxationModel.Lucro", "Lucro")
                        .WithMany()
                        .HasForeignKey("LucroId")
                        .HasConstraintName("fk_tax_regime_lucro_lucro_id");

                    b.HasOne("Firma.Models.Values.TaxationModel.Mei", "Mei")
                        .WithMany()
                        .HasForeignKey("MeiId")
                        .HasConstraintName("fk_tax_regime_mei_mei_id");

                    b.HasOne("Firma.Models.Values.TaxationModel.Simples", "Simples")
                        .WithMany()
                        .HasForeignKey("SimplesId")
                        .HasConstraintName("fk_tax_regime_simples_simples_id");

                    b.Navigation("Company");

                    b.Navigation("Lucro");

                    b.Navigation("Mei");

                    b.Navigation("Simples");
                });

            modelBuilder.Entity("Firma.Models.Entities.Company", b =>
                {
                    b.Navigation("TaxRegime")
                        .IsRequired();
                });

            modelBuilder.Entity("Firma.Models.Entities.Establishment", b =>
                {
                    b.Navigation("Email");

                    b.Navigation("Telephone");
                });

            modelBuilder.Entity("Firma.Models.Values.Legal.Cnae", b =>
                {
                    b.Navigation("Estabelecimentos");
                });

            modelBuilder.Entity("Firma.Models.Values.Legal.SecondaryCnaes", b =>
                {
                    b.Navigation("Cnaes");
                });
#pragma warning restore 612, 618
        }
    }
}
