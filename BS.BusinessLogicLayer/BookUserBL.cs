using BS.BusinessObjectLayer;
using BS.DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.BusinessLogicLayer
{
    public class BookUserBL
    {
        private readonly BookUserDB BookUserDA = null;
        public BookUserBL()
        {
            BookUserDA = new BookUserDB();
        }

        public IEnumerable<BookUser> GetUsers()
        {
            return BookUserDA.GetAll();
        }

        public BookUser GetUser(int UserID)
        {
            return BookUserDA.GetUser(UserID);
        }

        public BookUser GetUser(string username, string password)
        {
            return BookUserDA.GetUser(username, password);
        }

        public BookUser GetUser(string username)
        {
            return BookUserDA.GetUser(username);
        }

        public void Insert(BookUser user)
        {
            BookUserDA.Insert(user);
        }

        public void Update(BookUser user)
        {
            BookUserDA.Update(user);
        }

        public void Delete(BookUser user)
        {
            BookUserDA.Delete(user);
        }
    }
}
