namespace MyStorage.Abstraction;

public interface IPrinter
{
    Task PrintAsync(string data);
}