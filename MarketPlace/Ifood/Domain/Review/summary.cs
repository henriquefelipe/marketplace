using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain.Review
{
    public class summary
    {
        public int totalReviewsCount { get; set; }
        public int validReviewsCount { get; set; }
        public decimal score { get; set; }
    }
}
