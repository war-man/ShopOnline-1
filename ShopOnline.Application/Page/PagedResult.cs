using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Application.Page
{
    public class PagedResult<T> : PagedResultBase
    {

        public string NameCategory { get; set; }
        public List<T> Items { set; get; }
    }
}
