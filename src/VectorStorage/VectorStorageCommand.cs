using Microsoft.Extensions.VectorData;
using VectorStorage.Models;

namespace VectorStorage;

public class VectorStorageCommand(VectorStore vectorStore)
{
    public async Task StoreEntitiesAsync<T>(StoreRequest<T> storeRequest, CancellationToken cancellationToken) where T: VectorEntity
    {
        string collectionName = storeRequest.CollectionName;
        IEnumerable<T> entities = storeRequest.Entities;
        VectorStoreCollection<string, T> collection = vectorStore.GetCollection<string, T>(collectionName);

        await collection.EnsureCollectionExistsAsync(cancellationToken);

        //todo - delta import

        foreach (T entity in entities)
        {
            await collection.UpsertAsync(entity, cancellationToken);
        }

        //todo return object with stats
    }
}