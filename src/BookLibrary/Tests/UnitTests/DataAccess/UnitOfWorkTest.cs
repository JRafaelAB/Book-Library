using Domain.UnitOfWork;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Contexts;
using Moq;
using Xunit;

namespace UnitTests.DataAccess;

public class UnitOfWorkTest
{
    private readonly Mock<LibraryContext> _libraryContext;
    private readonly IUnitOfWork _unitOfWork;
        
    public UnitOfWorkTest()
    {
        this._libraryContext = new Mock<LibraryContext>();
        this._unitOfWork = new UnitOfWork(this._libraryContext.Object);
    }
        
    [Fact]
    public async Task TestingSucess_ValidateSave()
    {
        await this._unitOfWork.Save();
        this._libraryContext.Verify(context => context.SaveChangesAsync(It.IsAny<CancellationToken>()));
    }
        
    [Fact]
    public void TestingSucess_ValidateDispose()
    {
        this._unitOfWork.Dispose();
        this._libraryContext.Verify(context => context.Dispose(), Times.Exactly(1));
        this._unitOfWork.Dispose();
        this._libraryContext.Verify(context => context.Dispose(), Times.Exactly(1));
    }
}
