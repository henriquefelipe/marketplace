using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain.Review
{
    public class reviewss
    {
        public reviewss()
        {
            reviews = new List<review>();
        }

        public int page { get; set; }
        public int size { get; set; }
        public List<review> reviews { get; set; }
    }
}
