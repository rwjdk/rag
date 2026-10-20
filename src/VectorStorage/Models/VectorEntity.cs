using Microsoft.Extensions.VectorData;

namespace VectorStorage.Models;

public abstract class VectorEntity
{
    [VectorStoreKey]
    public required string Id { get; set; }

    [VectorStoreData]
    public required DateTime IngestionDate { get; set; }

}