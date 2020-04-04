using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BS.BusinessObjectLayer;

namespace BS.DataAcessLayer
{
    public class BookOrderDB : IDisposable
    {
        private readonly BookStoreOnlineEntities bsoe = null;
        public BookOrderDB()
        {
            bsoe = new BookStoreOnlineEntities();
        }

        public IEnumerable<BookOrder> GetAll()
        {
            return bsoe.BookOrders.ToList();
        }

        public BookOrder GetById(int Id)
        {
            return bsoe.BookOrders.Find(Id);
        }

        public IEnumerable<BookOrder> GetAll(int UserId)
        {
            return bsoe.BookOrders.Where(o => o.UserId == UserId).ToList();
        }

        public BookOrder Insert(BookOrder bookorder)
        {
            BookOrder order = bsoe.BookOrders.Add(bookorder);
            Save();
            return order;
        }

        public void Update(BookOrder bookOrder)
        {
            BookOrder order = bsoe.BookOrders.FirstOrDefault(o => o.OrderId == bookOrder.OrderId);
            order.Total = bookOrder.Total;
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
