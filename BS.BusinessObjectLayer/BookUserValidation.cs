using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BS.BusinessObjectLayer
{
    public class BookUserValidation
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        [IgnoreDataMember]
        public string Password { get; set; }
        public int RoleId { get; set; }
        [IgnoreDataMember]
        public virtual ICollection<BookOrder> BookOrders { get; set; }
        [IgnoreDataMember]
        public virtual BookRole BookRole { get; set; }
    }
    [MetadataType(typeof(BookUserValidation))]
    public partial class BookUser
    {

    }
}
