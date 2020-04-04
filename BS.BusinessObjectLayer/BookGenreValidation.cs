using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BS.BusinessObjectLayer
{
    public class BookGenreValidation
    {
        public int? GenreId { get; set; }
        [Required]
        public string GenreName { get; set; }
        [IgnoreDataMember]
        public virtual ICollection<Book> Books { get; set; }
    }

    [MetadataType(typeof(BookGenreValidation))]
    public partial class BookGenre {
    
    }
}
