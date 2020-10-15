using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoponline.api.Models
{
    public class Brand
    {
        public string Name { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
