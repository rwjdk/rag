using Datasource.YouTubeChannel;
using Datasource.YouTubeChannel.Models;
using JetBrains.Annotations;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using VectorStorage;
using VectorStorage.Models;

namespace Backend.Ingestion;

[UsedImplicitly]
public class YouTubeScheduledFunction(ILoggerFactory loggerFactory, YouTubeDatasource datasource, VectorStorageCommand vectorStorageCommand)
{
    private readonly ILogger _logger = loggerFactory.CreateLogger<YouTubeScheduledFunction>();

    [Function("YouTubeScheduledFunction")]
    public async Task Run([TimerTrigger(CronPatterns.Every5Minutes)] TimerInfo myTimer, CancellationToken cancellationToken)
    {
        YouTubeVideo[] videos = datasource.GetVideosAsync();

        await vectorStorageCommand.StoreEntitiesAsync(new StoreRequest<YouTubeVideoVectorEntity>
        {
            CollectionName = CollectionNames.RwjYouTubeChannel,
            Entities = videos.Select(x => x.ToVectorEntity())
        }, cancellationToken);

        _logger.LogInformation("C# Timer trigger function executed at: {executionTime}", DateTime.Now);
        
        if (myTimer.ScheduleStatus is not null)
        {
            _logger.LogInformation("Next timer schedule at: {nextSchedule}", myTimer.ScheduleStatus.Next);
        }
    }
}