using BS.BusinessObjectLayer;
using BS.DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.BusinessLogicLayer
{
    public class BookCartBL
    {
        private readonly BookOrderDB BookOrderDB = null;
        private readonly BookUserDB BookUserDB = null;
        private readonly BookOrderMetaDB BookOrderMetaDB = null;
        private readonly BookBL BookBL = null;
        public BookCartBL()
        {
            BookOrderDB = new BookOrderDB();
            BookUserDB = new BookUserDB();
            BookOrderMetaDB = new BookOrderMetaDB();
            BookBL = new BookBL();
        }

        public bool InsertItem(List<BookOrderMeta> carts, int BookId)
        {
            Book book = BookBL.GetBook(BookId);
            if(book == null)
            {
                return false;
            }
            BookOrderMeta item = new BookOrderMeta() {
                BookId = BookId,
                BookQuantity = 1
            };
            carts.Add(item);
            return true;
        }

        public bool UpdateItem(List<BookOrderMeta> carts, int BookId)
        {
            BookOrderMeta currentItem = carts.FirstOrDefault(i => i.BookId == BookId);
            if(currentItem == null)
            {
                return false;
            }
            currentItem.BookQuantity++;
            return true;
        }

        public bool DeleteItem(List<BookOrderMeta> carts, int BookId)
        {
            BookOrderMeta currentItem = carts.FirstOrDefault(i => i.BookId == BookId);
            if(currentItem == null)
            {
                return false;
            }
            carts.Remove(currentItem);
            return true;
        }

        public bool CheckOut(string username, List<BookOrderMeta> carts)
        {
            BookOrderMeta[] orderDetails = carts.ToArray();
            orderDetails = Array.FindAll(orderDetails, IsNullBook).ToArray();
            if (orderDetails.Length == 0)
            {
                return false;
            }
            int userId = BookUserDB.GetUser(username).UserId;
            BookOrder order = BookOrderDB.Insert(new BookOrder(userId, DateTime.Now));
            float total = 0;
            foreach (var item in orderDetails)
            {
                item.OrderId = order.OrderId;
                Book book = BookBL.GetBook(item.BookId);
                total += (float)(book.BookPrice * (100 - book.BookDiscount) / 100 * item.BookQuantity);
            }
            order.Total = total;
            BookOrderDB.Update(order);
            BookOrderMetaDB.Insert(orderDetails);
            return true;
        }

        private bool IsNullBook(BookOrderMeta BookOrderMeta)
        {
            int BookID = (int)BookOrderMeta.BookId;
            BookBL BookBL = new BookBL();
            if (BookBL.GetBook(BookID) != null)
            {
                return true;
            }
            return false;
        }

        public bool ItemExist(List<BookOrderMeta> carts, int BookId)
        {
            BookOrderMeta currentItem = carts.FirstOrDefault(i => i.BookId == BookId);
            if(currentItem != null)
            {
                return true;
            }
            return false;
        }
    }
}
