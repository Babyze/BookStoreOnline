using BS.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DataAcessLayer
{
    public class BookGenreDB : IDisposable
    {
        private readonly BookStoreOnlineEntities bsoe = null;
        public BookGenreDB()
        {
            bsoe = new BookStoreOnlineEntities();
        }

        public IEnumerable<BookGenre> GetAll()
        {
            return bsoe.BookGenres.ToList();
        }

        public BookGenre GetById(int id)
        {
            return bsoe.BookGenres.Find(id);
        }

        public void Insert(BookGenre genre)
        {
            bsoe.BookGenres.Add(genre);
            Save();
        }

        public void Delete(BookGenre genre)
        {
            new BookDB().DeleteBookByGenre(genre);
            bsoe.BookGenres.Remove(genre);
            Save();
        }

        public void Update(BookGenre genre)
        {
            BookGenre currentGenre = bsoe.BookGenres.FirstOrDefault(g => g.GenreId == genre.GenreId);
            currentGenre.GenreName = genre.GenreName;
            Save();
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
