using FakeItEasy;

using MyStorage.Abstraction;

namespace MyStorage.Tests;

public class StorageTests
{
    private readonly IStorage _storage;
    private readonly IPrinter _printer = A.Fake<IPrinter>();
    private readonly I2DWithName _2d = A.Fake<I2DWithName>();

    public StorageTests()
    {
        _storage = new Storage(_printer);
    }

    [Fact]
    public async Task EmptyStorate_ShouldNotPrint_Test()
    {
        // act
        await _storage.PrintAsync();

        // assert
        A.CallTo(() => _printer.PrintAsync(A<string>.Ignored))
            .MustNotHaveHappened();
    }

}