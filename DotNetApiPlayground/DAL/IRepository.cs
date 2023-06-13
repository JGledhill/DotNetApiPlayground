using System.Linq.Expressions;

namespace DotNetApiPlayground.DAL
{
    /*
     * This is an interface that defines a contract for a class to implement.
     * Naming convention is typically: I{ClassName}.
     * https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/interfaces
     */
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null,
                             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        T? GetById(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(object id);
        void Delete(T entity);
    }
}
