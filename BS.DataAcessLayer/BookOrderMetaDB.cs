using BS.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DataAcessLayer
{
    public class BookOrderMetaDB : IDisposable
    {
        private readonly BookStoreOnlineEntities bsoe = null;
        public BookOrderMetaDB()
        {
            bsoe = new BookStoreOnlineEntities();
        }

        public void Insert(BookOrderMeta[] bookorder)
        {
            bsoe.BookOrderMetas.AddRange(bookorder);
            Save();
        }

        public void DeleteOrderMetaByBookId(int BookId)
        {
            var items = bsoe.BookOrderMetas.Where(i => i.BookId == BookId).ToList();
            bsoe.BookOrderMetas.RemoveRange(items);
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
