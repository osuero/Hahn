using Hahn_OctavioSueroBackEnd.Application.Services;
using Hahn_OctavioSueroBackEnd.Core.Interfaces;
using Hahn_OctavioSueroBackEnd.Core.Repositories;
using Hahn_OctavioSueroBackEnd.Infrastructure.Data;
using HahnWorkerService;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")));

     
        services.AddScoped<IUpsertJobService, UpsertJobService>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
   
        services.AddHangfire(config => config.UseSqlServerStorage(hostContext.Configuration.GetConnectionString("DefaultConnection")));
        services.AddHangfireServer();

       
        services.AddHostedService<Worker>();
    })
    .Build();

    using (var serviceScope = host.Services.CreateScope())
    {
        var services = serviceScope.ServiceProvider;

        RecurringJob.AddOrUpdate<IUpsertJobService>(
            "UpsertJob",
            service => service.ExecuteUpsertAsync(),
            Cron.Hourly);
    }

    await host.RunAsync();