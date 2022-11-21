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
    [Fact]
    public async Task OneItem_ShouldPrintOnce_Test()
    {
        //arrange
        await _storage.TryAddAsync(_2d);
        A.CallTo(() => _2d.Name).Returns("abc");
        //act
        await _storage.PrintAsync();
        //assert
        A.CallTo(() => _printer.PrintAsync("abc"))
            .MustHaveHappenedOnceExactly();
    }
    [Fact]
    public async Task OneItem_ShouldRemove_Test()
    {
        //arrange
        A.CallTo(() => _2d.Name).Returns("abc");
        await _storage.TryAddAsync(_2d);
        //act
        bool flag = await _storage.TryRemoveAsync("abc");
        //assert
        Assert.True(flag);
    }
    [Fact]
    public async Task ZeroItems_ShouldThrow_Test()
    {
       //await _storage.TryAddAsync(_2d);
       await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async ()=> 
         await _storage.TryRemoveAsync("abc"));
    }


}