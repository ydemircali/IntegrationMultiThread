using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Common
{
    public class Item
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            return $"{Id}:{Content}";
        }
    }
}
