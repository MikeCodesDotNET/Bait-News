using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadlineManager.Models
{
    public class Headline : EntityData
    {
        public string Text { get; set; }
        public string Source { get; set; }
        public string Url { get; set; }
        public bool IsTrue { get; set; }
    }
}
