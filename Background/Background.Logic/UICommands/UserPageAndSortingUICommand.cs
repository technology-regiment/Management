using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Background.Logic.UICommands
{
    public class UserPageAndSortingUICommand
    {
        public int PageNumber { get; set; }
        public string OrderProperty { get; set; }
        public bool Ascending { get; set; }
        public int PageSize { get; set; }
        public FilterUserUICommand Filter { get; set; }
    }
}
