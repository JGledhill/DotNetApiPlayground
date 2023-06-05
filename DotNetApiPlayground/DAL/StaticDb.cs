using DotNetApiPlayground.Models;

namespace DotNetApiPlayground.DAL
{
    public static class StaticDb
    {
        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "The C Programming Language", Author = "Brian Kernighan" },
            new Book { Id = 2, Title = "Dracula", Author = "Bram Stoker" },
            new Book { Id = 3, Title = "The Lord of the Rings", Author = "J. R. R. Tolkien" },
            new Book { Id = 4, Title = "Harry Potter and the Philosopher's Stone", Author = "J. K. Rowling" },
        };

        public static List<Book> Books
        {
            get { return _books; }
            set { _books = value; }
        }        
    }
}
