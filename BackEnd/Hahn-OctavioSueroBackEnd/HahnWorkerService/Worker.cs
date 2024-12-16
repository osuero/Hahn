using Hahn_OctavioSueroBackEnd.Core.Interfaces;

namespace HahnWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IUpsertJobService _upsertJobService;

        public Worker(ILogger<Worker> logger, IUpsertJobService upsertJobService)
        {
            _logger = logger;
            _upsertJobService = upsertJobService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Executing Upsert Job at: {time}", DateTimeOffset.Now);

                await _upsertJobService.ExecuteUpsertAsync();

                await Task.Delay(3600000, stoppingToken);
            }
        }
    }
}
