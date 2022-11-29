using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsScraper
{
    public class Ad
    {
        public string Title { get; set; } = null!;

        public string Price { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
