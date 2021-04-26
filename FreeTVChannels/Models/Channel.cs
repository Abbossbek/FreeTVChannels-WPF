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
        public Language[] Languages { get; set; }
        public Country[] Countries { get; set; }
        public TVG TVG { get; set; }
    }
}
