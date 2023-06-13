using DotNetApiPlayground.Models;
using System.Linq.Expressions;

namespace DotNetApiPlayground.DAL
{
    /* This is a repository class.
     * It is responsible for interacting with the database.
     * This class inherits from IRepository<Book> and must implement all of its methods: Add, Delete, etc.
     * https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design
     */
    public class StaticBookRepository : IRepository<Book>
    {
        public void Add(Book entity)
        {
            StaticDb.Books.Add(entity);
        }

        public void Delete(object id)
        {
            Book? book = StaticDb.Books.SingleOrDefault(b => b.Id == (int)id);
            if (book != null)
                Delete(book);
        }

        public void Delete(Book entity)
        {
            StaticDb.Books.Remove(entity);
        }
        
        public IQueryable<Book> GetAll(Expression<Func<Book, bool>> filter = null, Func<IQueryable<Book>, IOrderedQueryable<Book>> orderBy = null)
        {
            IQueryable<Book> books = StaticDb.Books.AsQueryable();
            
            if (filter != null)
                books = books.Where(filter);

            if (orderBy != null)
                return orderBy(books);
            else
                return books;
        }
        
        public Book? GetById(object id)
        {
            return StaticDb.Books.SingleOrDefault(b => b.Id == (int)id);
        }
        
        public void Update(Book entity)
        {
            Book? book = StaticDb.Books.SingleOrDefault(b => b.Id == entity.Id);
            if (book != null)
            {
                book.Title = entity.Title;
                book.Author = entity.Author;
            }
        }
    }
}
