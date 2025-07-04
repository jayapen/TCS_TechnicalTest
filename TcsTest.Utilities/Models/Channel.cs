using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcsTest.Utilities.Models
{
    public class Channel
    {
        public Guid ChannelId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public string Region { get; set; }
    }
}
