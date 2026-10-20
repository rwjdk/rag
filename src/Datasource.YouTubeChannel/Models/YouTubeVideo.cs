namespace Datasource.YouTubeChannel.Models;

public record YouTubeVideo(
    string VideoId,
    string Title,
    string Description,
    string Transcript,
    string Tags,
    DateTime ReleaseDate,
    YouTubePlaylist[] Playlists)
{
    public YouTubeVideoVectorEntity ToVectorEntity()
    {
        return new YouTubeVideoVectorEntity
        {
            Title = this.Title,
            Description = this.Description,
            Transcript = this.Transcript,
            Tags = this.Tags,
            Playlists = string.Join(';', this.Playlists.Select(x => x.Title)),
            Id = VideoId,
            IngestionDate = DateTime.UtcNow,
            ReleaseDate = this.ReleaseDate
        };

    }
}