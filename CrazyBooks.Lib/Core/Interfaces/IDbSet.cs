namespace CrazyBooks.Lib.Core
{
    public interface IDbSet<T> : ICrudEntity<T> where T : Entity
    {
        
    }
}
