using Microsoft.Extensions.VectorData;
using VectorStorage.Models;

namespace Datasource.YouTubeChannel.Models;

public class YouTubeVideoVectorEntity : VectorEntity
{
    [VectorStoreData]
    public required string Title { get; set; }

    [VectorStoreData]
    public required string Description { get; set; }

    [VectorStoreData]
    public required string Transcript { get; set; }

    [VectorStoreData]
    public required string Tags { get; set; }

    [VectorStoreData]
    public required string Playlists { get; set; }

    [VectorStoreData]
    public required DateTime ReleaseDate { get; set; }

    [VectorStoreVector(1536)]
    public string? Embedding => this.ToString();

    public override string ToString()
    {
        return $"""
                <video id="{Id}" title="{Title}" iso_release_date="{ReleaseDate:yyyy-MM-dd}">
                 <description>{Description}</description>
                 <tags>{Tags}</tags>
                 <playlists>{Playlists}</playlists>
                </video>
                """;
    }
}