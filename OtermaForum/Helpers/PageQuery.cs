using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtermaForum.Api.Helpers
{
    public class PageQuery
    {
        public int Top { get; set; }
        public int Skip { get; set; }

        public PageQuery()
        {
            Top = 20;
            Skip = 0;
        }
    }
}
