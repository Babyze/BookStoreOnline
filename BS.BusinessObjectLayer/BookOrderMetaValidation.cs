using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BS.BusinessObjectLayer
{
    public class BookOrderMetaValidation
    {
        public int OrderMetaId { get; set; }
        public int BookId { get; set; }
        public int BookQuantity { get; set; }
        public int OrderId { get; set; }
        [IgnoreDataMember]
        public virtual Book Book { get; set; }
        [IgnoreDataMember]
        public virtual BookOrder BookOrder { get; set; }
    }
    [MetadataType(typeof(BookOrderMetaValidation))]
    public partial class BookOrderMeta
    {

    }
}
