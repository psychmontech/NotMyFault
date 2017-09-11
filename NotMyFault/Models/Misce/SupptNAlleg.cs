using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Misce
{
    public class SupptNAlleg
    {
        public int SupptNAllegId { get; set; }
        public virtual User MyUser { get; set; }
        public virtual List<SNAEntry> MyEntries { get; set; }
    }

    public class SNAEntry
    {
        public DateTime Timestamp { get; set; }
        public virtual SupptNAlleg MySNA { get; set; }
        public Administrator MyAdmin { get; set; }
        public string Text { get; set; }
    }
}
