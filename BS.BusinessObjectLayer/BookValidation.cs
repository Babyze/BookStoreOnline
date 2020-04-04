using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BS.BusinessObjectLayer
{
    public class BookValidation
    {
        public int? BookId { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public string BookImage { get; set; }
        public Nullable<decimal> BookPrice { get; set; }
        public Nullable<int> BookDiscount { get; set; }
        public int GenreId { get; set; }
        [IgnoreDataMember]
        public virtual ICollection<BookOrderMeta> BookOrderMetas { get; set; }
        [IgnoreDataMember]
        public virtual BookGenre BookGenre { get; set; }
    }

    [MetadataType(typeof(BookValidation))]
    public partial class Book
    {

    }
}
