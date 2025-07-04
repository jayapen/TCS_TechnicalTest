using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TcsTest.Utilities.Validators.DateTimeValidator;

namespace TcsTest.Utilities.DTO
{
    public class ChannelScheduleDto
    {
        [Required(ErrorMessage = "ChannelId is required.")]
        public Guid ChannelId { get; set; }

        [Required(ErrorMessage = "ContentId is required.")]
        public Guid ContentId { get; set; }

        [Required(ErrorMessage = "AirTime is required.")]
        public DateTime AirTime { get; set; }

        [Required(ErrorMessage = "EndTime is required.")]
        [DateGreaterThanAttribute("AirTime", ErrorMessage = "EndTime must be later than AirTime.")]
        public DateTime EndTime { get; set; }
    }
}
