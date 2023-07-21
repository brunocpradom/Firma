using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Models.Entities;
using Firma.Models.Values;
using Firma.Models.Values.Companies;
using Firma.Models.Values.Contact;
using Firma.Models.Values.Legal;
using Firma.Models.Values.Partner;
using Firma.Models.Values.TaxationModel;
using Microsoft.EntityFrameworkCore;

namespace Firma.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cnae> Cnae => Set<Cnae>();
        public DbSet<Establishment> Establishment => Set<Establishment>();
        public DbSet<Company> Company => Set<Company>();
        public DbSet<Partner> Partner => Set<Partner>();
        public DbSet<Address> Adress => Set<Address>();
        public DbSet<City> City => Set<City>();
        public DbSet<Country> Country => Set<Country>();
        public DbSet<Email> Email => Set<Email>();
        public DbSet<Cnae> Characters => Set<Cnae>();
        public DbSet<Telephone> Telephone => Set<Telephone>();
        public DbSet<CadastralSituation> CadastralSituation => Set<CadastralSituation>();
        public DbSet<LegalNature> LegalNature => Set<LegalNature>();
        public DbSet<Lucro> Lucro => Set<Lucro>();
        public DbSet<Mei> Mei => Set<Mei>();
        public DbSet<Simples> Simples => Set<Simples>();
        public DbSet<TaxRegime> TaxRegime => Set<TaxRegime>();
        public DbSet<MainCnae> MainCnae => Set<MainCnae>();
        public DbSet<SecondaryCnaes> SecondaryCnaes => Set<SecondaryCnaes>();
        public DbSet<CadastralSituationReason> CadastralSituationReason => Set<CadastralSituationReason>();
        public DbSet<Qualification> Qualification => Set<Qualification>();

    }
}