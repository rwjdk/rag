namespace VectorStorage.Models;

public class StoreRequest<T> where T : VectorEntity
{
    public required string CollectionName { get; set; }
    public required IEnumerable<T> Entities { get; set; }
}