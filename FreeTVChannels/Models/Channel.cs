using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeTVChannels.Models
{
    public class Channel
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Url { get; set; }
        public string Category { get; set; }
        public Language Language { get; set; }
        public Counrty Counrty { get; set; }
        public TVG TVG { get; set; }
    }
}
