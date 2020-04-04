using BS.BusinessObjectLayer;
using BS.DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.BusinessLogicLayer
{
    public class BookRoleBL
    {
        private readonly BookRoleDB BookRoleDB = null;
        public BookRoleBL()
        {
            BookRoleDB = new BookRoleDB();
        }

        public IEnumerable<BookRole> GetRole()
        {
            return BookRoleDB.GetRole();
        }

        public BookRole GetRole(int RoleId)
        {
            return BookRoleDB.GetRole(RoleId);
        }
    }
}
