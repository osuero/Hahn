using Hahn_OctavioSueroBackEnd.Core.Interfaces;

namespace Hahn_OctavioSueroBackEnd.Application.Services
{
    public class UpsertJobService : IUpsertJobService
    {
        public async Task ExecuteUpsertAsync()
        {
            Console.WriteLine("Executing Upsert Job...");

            await Task.CompletedTask;
        }
    }
}
