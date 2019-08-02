namespace CrazyBooks.Lib.Services
{
    public interface ILendService
    {
        LendResponse RequestLend(LendRequest request);
    }
}
