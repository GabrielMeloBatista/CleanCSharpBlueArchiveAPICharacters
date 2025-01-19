using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using WorkerServiceHost;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var connectionString = hostContext.Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));
        services.AddScoped<ICharacterRepository, CharacterRepository>();
        services.AddScoped<CharacterService>();
        services.AddHttpClient<DataUpsertJob>();
        services.AddScoped<DataUpsertJob>();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
