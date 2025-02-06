using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entities
{
    [Table("booking")]
    public class Booking
    {
        [Key][Column("booking_id")]
        public int Id { get; set; }

        [Column("booking_date")]
        public DateTime Date { get; set; }

        [Column("customer_id")]
        public int CustomerId { get; set; }


        [Column("room_id")]
        public int RoomId { get; set; }


        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [Column("status")]
        public StatusType Status { get; set; }

        [Column("discount")]
        public double? Discount { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }  

        [ForeignKey(nameof(RoomId))]
        public Room Room { get; set; }
    }
}
