using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.UserRelated
{
    public class Review
    {
        public string Comments { get; set; }
        public DateTime Timestamp { get; set; }
        public int Stars { get; set; }
        public virtual Developer MyReviewee { get; set; }
        public virtual Developer MyReviewer { get; set; }

    }
}
