using BS.BusinessObjectLayer;
using BS.DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.BusinessLogicLayer
{
    public class BookBL
    {
        private readonly BookDB BookDA = null;
        private BookPagedListBL BookPaged = null;
        public BookBL()
        {
            BookDA = new BookDB();
        }

        public BookPagedListBL GetAll(PagingParameter pagingParameter)
        {
            BookPaged = new BookPagedListBL(false, pagingParameter);
            return BookPaged;
        }

        public BookPagedListBL GetSaleBooks(PagingParameter pagingParameter)
        {
            BookPaged = new BookPagedListBL(true, pagingParameter);
            return BookPaged;
        }

        public BookPagedListBL GetBookByGenre(int GenreId, PagingParameter pagingParameter)
        {
            BookPaged = new BookPagedListBL(GenreId, pagingParameter);
            return BookPaged;
        }

        public BookPagedListBL GetBooksByName(string BookName, PagingParameter pagingParameter)
        {
            BookPaged = new BookPagedListBL(BookName, pagingParameter);
            return BookPaged;
        }

        public Book GetBook(int BookId)
        {
            return BookDA.GetById(BookId);
        }

        public Book InsertBook(Book book)
        {
            return BookDA.Insert(book);
        }

        public void UpdateBook(Book book)
        {
            BookDA.Update(book);
        }

        public void DeleteBook(Book book)
        {
            BookDA.Delete(book);
        }
    }
}
