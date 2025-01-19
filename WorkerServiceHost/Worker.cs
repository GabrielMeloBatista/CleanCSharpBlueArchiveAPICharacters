using Application.Services;

namespace WorkerServiceHost
{
    public class Worker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public Worker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();
                var dataUpsertJob = scope.ServiceProvider.GetRequiredService<DataUpsertJob>();
                var characterService = scope.ServiceProvider.GetRequiredService<CharacterService>();

                try
                {
                    // Fetch characters from the API
                    var characters = await dataUpsertJob.FetchCharactersFromApi();

                    // Upsert characters into the database
                    foreach (var character in characters)
                    {
                        await characterService.UpsertCharacter(character);
                    }
                }
                catch (Exception ex)
                {
                    // Log the error (not implemented here)
                    Console.WriteLine($"Error: {ex.Message}");
                }

                // Wait before the next execution (e.g., 1 hour)
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
