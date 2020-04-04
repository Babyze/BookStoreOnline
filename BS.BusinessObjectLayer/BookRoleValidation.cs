using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BS.BusinessObjectLayer
{
    public class BookRoleValidation
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        [IgnoreDataMember]
        public virtual ICollection<BookUser> BookUsers { get; set; }
    }
    [MetadataType(typeof(BookRoleValidation))]
    public partial class BookRole
    {

    }
}
