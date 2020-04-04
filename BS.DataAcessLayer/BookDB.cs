using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BS.BusinessObjectLayer;

namespace BS.DataAcessLayer
{
    public class BookDB : IDisposable
    {
        private readonly BookStoreOnlineEntities bsoe = null;
        public BookDB()
        {
            bsoe = new BookStoreOnlineEntities();
        }

        public IEnumerable<Book> GetAll(int currentPage, int pageSize)
        {
            return bsoe.Books.ToList().OrderByDescending(b => b.BookId)
                    .Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public IEnumerable<Book> GetAll(int GenreId, int currentPage, int pageSize)
        {
            return bsoe.Books
                    .Where(b => b.GenreId == GenreId).OrderByDescending(b => b.BookId)
                    .ToList().Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public IEnumerable<Book> GetBookByName(string BookName, int currentPage, int pageSize)
        {
            return bsoe.Books
                    .Where(b => b.BookName.Contains(BookName)).OrderByDescending(b => b.BookId)
                    .ToList().Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        } 

        public IEnumerable<Book> GetAllBookSale(int currentPage, int pageSize)
        {
            return bsoe.Books.Where(b => b.BookDiscount > 0).OrderByDescending(b => b.BookId)
                    .ToList().Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public Book GetById(int Id)
        {
            return bsoe.Books.Find(Id);
        }

        public Book Insert(Book book)
        {
            Book currentBook = bsoe.Books.Add(book);
            Save();
            return currentBook;
        }

        public void Update(Book book)
        {
            Book currentBook = bsoe.Books.FirstOrDefault(b => b.BookId == book.BookId);
            if(currentBook != null)
            {
                bsoe.Entry(currentBook).CurrentValues.SetValues(book);
            }
            Save();
        }

        public void Delete(Book book)
        {
            new BookOrderMetaDB().DeleteOrderMetaByBookId(book.BookId);
            bsoe.Books.Remove(book);
            Save();
        }

        public void DeleteBookByGenre(BookGenre genre)
        {
            var books = bsoe.Books.Where(b => b.GenreId == genre.GenreId).ToList();
            foreach(var book in books)
            {
                Delete(book);
            }
            Save();
        }

        public int TotalBook(bool sale)
        {
            int totalBook = sale == true ? 
                bsoe.Books.Where(b => b.BookDiscount > 0).ToList().Count() : bsoe.Books.Count();
            return totalBook;
        }

        public int TotalBook(int GenreId)
        {
            return bsoe.Books.Where(b => b.GenreId == GenreId).Count();
        }

        public int TotalBook(string BookName)
        {
            return bsoe.Books.Where(b => b.BookName.Contains(BookName)).Count();
        }

        public void Save()
        {
            bsoe.SaveChanges();
        }

        public void Dispose()
        {
            bsoe.Dispose();
        }
    }
}
