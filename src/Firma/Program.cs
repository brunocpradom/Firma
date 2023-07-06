using Firma.Data;
using Firma.Managers;
using Firma.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services
    .AddDbContext<DataContext>(options =>
    options
        .UseSnakeCaseNamingConvention()
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IReceitaFederalClient, ReceitaFederalClient>();
builder.Services.AddScoped<IReceitaFederalService, ReceitaFederalService>();
builder.Services.AddScoped<ICsvParserService, CsvParserService>();
builder.Services.AddScoped<IManager, CadastralSituationReasonManager>();
builder.Services.AddScoped<IManager, CityManager>();
builder.Services.AddScoped<ICnaeManager, CnaeManager>();
builder.Services.AddScoped<IManager, CompanyManager>();
builder.Services.AddScoped<IManager, CountryManager>();
builder.Services.AddScoped<IManager, EstablishmentsManager>();
builder.Services.AddScoped<IManager, LegalNatureManager>();
builder.Services.AddScoped<IManager, PartnersManager>();
builder.Services.AddScoped<IManager, QualificationManager>();
builder.Services.AddScoped<IManager, SimplesManager>();
builder.Services.AddScoped<IManager, TaxRegimeManager>();
builder.Services.AddHttpClient();

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

app.Run();
