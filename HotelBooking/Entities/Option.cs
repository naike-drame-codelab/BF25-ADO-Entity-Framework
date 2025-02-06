using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entities
{
    [Table("Option")]
    public class Option
    {
        [Key][Column("option_id")]
        public int Id { get; set; }

        [ForeignKey(nameof(Id))]
        public Room RoomId { get; set; }

        [Column("option_name")]
        public string Name { get; set; }

        [Column("room_options")]
        public List<Room> Rooms { get; set; }

        
    }
}
