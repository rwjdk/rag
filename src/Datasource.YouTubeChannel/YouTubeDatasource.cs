using Datasource.YouTubeChannel.Models;

namespace Datasource.YouTubeChannel;

public class YouTubeDatasource
{
    public YouTubeVideo[] GetVideosAsync()
    {
        //todo
        YouTubePlaylist[] playlist = [new YouTubePlaylist("p42", "MyPlaylist", "Playlist with all the cool videos")];
        return [new YouTubeVideo("42", "Hello world", "This is a dummy video", "Hello, and welcome to this video...", "AI;RAG;Hello", DateTime.Today, playlist)];
    }
}