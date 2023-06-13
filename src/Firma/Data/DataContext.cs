using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Models.Entities;
using Firma.Models.Values.Companies;
using Firma.Models.Values.Contact;
using Firma.Models.Values.Legal;
using Firma.Models.Values.Partner;
using Firma.Models.Values.TaxationModel;
using Microsoft.EntityFrameworkCore;

namespace Firma.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Cnae> Cnae => Set<Cnae>();
        public DbSet<Establishment> Establishment => Set<Establishment>();
        public DbSet<Company> Company => Set<Company>();
        public DbSet<Partner> Partner => Set<Partner>();
        public DbSet<Adress> Adress => Set<Adress>();
        public DbSet<City> City => Set<City>();
        public DbSet<Country> Country => Set<Country>();
        public DbSet<Email> Email => Set<Email>();
        public DbSet<Cnae> Characters => Set<Cnae>();
        public DbSet<Telephone> Telephone => Set<Telephone>();
        public DbSet<CadastralSituation> CadastralSituation => Set<CadastralSituation>();  
        public DbSet<LegalNature> LegalNature => Set<LegalNature>(); 
        public DbSet<AgeGroup> AgeGroup => Set<AgeGroup>(); 
        public DbSet<Qualification> Qualification => Set<Qualification>(); 
        public DbSet<Lucro> Lucro => Set<Lucro>();
        public DbSet<Mei> Mei => Set<Mei>();
        public DbSet<Simples> Simples => Set<Simples>();
        public DbSet<TaxRegime> TaxRegime => Set<TaxRegime>();
    }
}