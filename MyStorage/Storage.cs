using MyStorage.Abstraction;

namespace MyStorage;

public class Storage : IStorage
{
    private readonly IPrinter _printer;
    private readonly IDictionary<string, I2DWithName> _values = new Dictionary<string, I2DWithName>();

    public Storage(IPrinter printer)
    {
        _printer = printer;
    }

    async Task IStorage.PrintAsync()
    {
        foreach (var item in _values.Values)
        {
            await _printer.PrintAsync(item.Name);
        }
    }

    Task<bool> IStorage.TryAddAsync(I2DWithName item)
    {
        _values.Add(item.Name, item);
        return Task.FromResult(true);
    }

    Task<bool> IStorage.TryRemoveAsync(string name)
    {
        bool flag =_values.Remove(name);
        return Task<bool>.FromResult(flag);
    }
}