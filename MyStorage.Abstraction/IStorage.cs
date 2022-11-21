namespace MyStorage.Abstraction;

public interface IStorage
{
    Task<bool> TryAddAsync(I2DWithName item);

    Task<bool> TryRemoveAsync(string name);

    Task PrintAsync();
}