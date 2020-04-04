using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.BusinessObjectLayer
{
    public class PagingParameter
    {
        const int maxPageSize = 20;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 8;
        public int PageSizes
        {
            get { return PageSize; }
            set
            {
                PageSizes = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
