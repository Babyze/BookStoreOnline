using BS.BusinessObjectLayer;
using BS.DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.BusinessLogicLayer
{
    public class BookOrderBL
    {
        private readonly BookOrderDB BookOrderDB = null;

        public BookOrderBL()
        {
            BookOrderDB = new BookOrderDB();
        }

        public IEnumerable<BookOrder> GetOrders()
        {
            return BookOrderDB.GetAll();
        }

        public BookOrder GetOrder(int OrderID)
        {
            return BookOrderDB.GetById(OrderID);
        }

        public IEnumerable<BookOrder> GetOrdersByUser(int UserId)
        {
            return BookOrderDB.GetAll(UserId);
        }
    }
}
