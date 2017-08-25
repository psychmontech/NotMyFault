using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.UserRelated
{
    public class Review
    {
        public string Comments { get; set; }
        public DateTime Date { get; set; }
        public string Stars { get; set; }
        public Developer MyReviewee { get; set; }
        public Developer MyReviewer { get; set; }
    }
}
