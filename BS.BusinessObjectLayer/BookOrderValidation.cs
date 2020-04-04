using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BS.BusinessObjectLayer
{
    public class BookOrderValidation
    {
        public int? OrderId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public virtual ICollection<BookOrderMeta> BookOrderMetas { get; set; }
        [IgnoreDataMember]
        public virtual BookUser BookUser { get; set; }
    }
    [MetadataType(typeof(BookOrderValidation))]
    public partial class BookOrder
    {
        public BookOrder(int UserId, DateTime OrderDate)
        {
            this.UserId = UserId;
            this.OrderDate = OrderDate;
        }

    }
}
