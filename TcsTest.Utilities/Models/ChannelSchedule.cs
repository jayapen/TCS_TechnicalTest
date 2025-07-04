using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcsTest.Utilities.Models
{
    public class ChannelSchedule
    {
        public Guid ScheduleId { get; set; }
        public Guid ChannelId { get; set; }
        public Guid ContentId { get; set; }
        public DateTime AirTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
