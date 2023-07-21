using Firma.Data;
using Firma.Managers;
using Firma.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Firma;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services
    .AddDbContext<AppDbContext>(options =>
    options
        .UseSnakeCaseNamingConvention()
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddScoped<IReceitaFederalClient, ReceitaFederalClient>()
    .AddScoped<IReceitaFederalService, ReceitaFederalService>()
    .AddScoped<ICsvParserService, CsvParserService>()
    .AddScoped<IManager, CadastralSituationReasonManager>()
    .AddScoped<IManager, CityManager>()
    .AddScoped<IManager, CnaeManager>()
    .AddScoped<IManager, CompanyManager>()
    .AddScoped<IManager, CountryManager>()
    .AddScoped<IManager, EstablishmentsManager>()
    .AddScoped<IManager, LegalNatureManager>()
    .AddScoped<IManager, PartnersManager>()
    .AddScoped<IManager, QualificationManager>()
    .AddScoped<IManager, SimplesManager>()
    .AddScoped<IManager, TaxRegimeManager>()
    .AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MigrateDatabase();
app.Run();
