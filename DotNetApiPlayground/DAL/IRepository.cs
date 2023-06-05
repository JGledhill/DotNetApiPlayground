using System.Linq.Expressions;

namespace DotNetApiPlayground.DAL
{
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
