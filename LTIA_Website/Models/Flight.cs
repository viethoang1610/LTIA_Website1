using System;
using System.ComponentModel.DataAnnotations;

namespace LTIA_website.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Required, Display(Name = "Giờ dự kiến"), DataType(DataType.Time)]
        public DateTime ScheduledTime { get; set; }

        [Required, Display(Name = "Điểm khởi hành")]
        public string Origin { get; set; } = default!;

        [Required, Display(Name = "Điểm đến")]
        public string Destination { get; set; } = default!;

        [Required, Display(Name = "Hãng hàng không")]
        public string AirlineName { get; set; } = default!;

        [Display(Name = "Logo hãng")]
        public string AirlineLogoUrl { get; set; } = default!;

        [Required, Display(Name = "Số hiệu chuyến bay")]
        public string FlightNumber { get; set; } = default!;

        [Display(Name = "Nhà ga")]
        public string Terminal { get; set; } = default!;

        [Display(Name = "Băng chuyền")]
        public string Belt { get; set; } = default!;

        [Display(Name = "Trạng thái")]
        public string Status { get; set; } = default!;
    }
}
