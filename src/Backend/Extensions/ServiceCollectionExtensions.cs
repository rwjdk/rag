using Azure.AI.OpenAI;
using CommunityToolkit.VectorData.SqlServer;
using Datasource.YouTubeChannel;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ClientModel;
using Microsoft.Extensions.VectorData;

namespace Backend.Extensions;

public static class ServiceCollectionExtensions
{
    public static void Foo(this IServiceCollection services, IConfiguration configuration)
    {
        string azureOpenAIEndpoint = configuration["azureOpenAIEndpoint"]
            ?? throw new InvalidOperationException("Configuration setting 'azureOpenAIEndpoint' is required.");
        string azureOpenAIApiKey = configuration["azureOpenAIApiKey"]
            ?? throw new InvalidOperationException("Configuration setting 'azureOpenAIApiKey' is required.");
        string embeddingModel = configuration["azureOpenAIEmbeddingModel"]
            ?? throw new InvalidOperationException("Configuration setting 'azureOpenAIEmbeddingModel' is required.");

        AzureOpenAIClient client = new(new Uri(azureOpenAIEndpoint), new ApiKeyCredential(azureOpenAIApiKey));

        IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator = client
            .GetEmbeddingClient(embeddingModel)
            .AsIEmbeddingGenerator();


        services.AddSingleton<YouTubeDatasource>();
        services.AddSingleton<VectorStore>(_ => new SqlServerVectorStore("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;", new SqlServerVectorStoreOptions
        {
            EmbeddingGenerator = embeddingGenerator
        }));
    }
}
