using BS.BusinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DataAcessLayer
{
    public class BookRoleDB : IDisposable
    {
        private readonly BookStoreOnlineEntities bsoe = null;
        public BookRoleDB()
        {
            bsoe = new BookStoreOnlineEntities();
        }

        public IEnumerable<BookRole> GetRole()
        {
            return bsoe.BookRoles.ToList();
        }

        public BookRole GetRole(int RoleID)
        {
            return bsoe.BookRoles.FirstOrDefault(r => r.RoleId == RoleID);
        }

        public void Dispose()
        {
            bsoe.Dispose();
        }
    }
}
