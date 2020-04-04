using BS.BusinessObjectLayer;
using BS.DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.BusinessLogicLayer
{
    public class BookGenreBL
    {
        private readonly BookGenreDB GenreDA = null;
        public BookGenreBL()
        {
            GenreDA = new BookGenreDB();
        }

        public IEnumerable<BookGenre> GetAll()
        {
            return GenreDA.GetAll();
        }

        public BookGenre GetById(int Id)
        {
            return GenreDA.GetById(Id);
        }

        public void InsertGenre(BookGenre genre)
        {
            GenreDA.Insert(genre);
        }

        public void UpdateGenre(BookGenre genre)
        {
            GenreDA.Update(genre);
        }

        public bool DeleteGenre(BookGenre genre)
        {
            BookGenre currentGenre = GenreDA.GetById(genre.GenreId);
            if(currentGenre != null)
            {
                GenreDA.Delete(currentGenre);
                return true;
            } else
            {
                return false;
            }
        }
    }
}
