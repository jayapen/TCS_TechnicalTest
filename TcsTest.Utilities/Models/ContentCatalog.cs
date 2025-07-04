using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcsTest.Utilities.Models
{
    public class ContentCatalog
    {
        public Guid ContentId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Genre { get; set; }
        public int DurationMinutes { get; set; }
        public string Rating { get; set; }
        public int Year { get; set; }
        public int? Season { get; set; }
        public int? Episode { get; set; }
    }
}
