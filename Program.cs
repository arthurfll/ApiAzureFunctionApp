using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ApiAzureFunctionApp.Data;
using ApiAzureFunctionApp.Repositories;
using ApiAzureFunctionApp.Services;



var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("data source=C:/projects/data.db"));

builder.Services.AddScoped<AlunoRepository>();
builder.Services.AddScoped<AlunoService>();

builder.Build().Run();
