using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Models
{
    public class ThemeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<PostModel> Posts { get; set; }
    }
}
