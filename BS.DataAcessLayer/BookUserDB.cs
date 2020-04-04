using BS.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DataAcessLayer
{
    public class BookUserDB : IDisposable
    {
        private readonly BookStoreOnlineEntities bsoe = null;
        public BookUserDB()
        {
            bsoe = new BookStoreOnlineEntities();
        }

        public IEnumerable<BookUser> GetAll()
        {
            return bsoe.BookUsers.ToList();
        }

        public BookUser GetUser(int Id)
        {
            return bsoe.BookUsers.Find(Id);
        }

        public BookUser GetUser(string username)
        {
            return bsoe.BookUsers.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public BookUser GetUser(string username, string password)
        {
            return bsoe.BookUsers.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                                                u.Password == password);
        }

        public void Insert(BookUser user)
        {
            bsoe.BookUsers.Add(user);
            Save();
        }

        public void Delete(BookUser user)
        {
            BookUser userInData = GetUser(user.UserId);
            bsoe.BookUsers.Remove(userInData);
            Save();
        }

        public void Update(BookUser user)
        {
            BookUser userInData = bsoe.BookUsers.Find(user.UserId);
            userInData.Password = user.Password;
            userInData.RoleId = user.RoleId;
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
