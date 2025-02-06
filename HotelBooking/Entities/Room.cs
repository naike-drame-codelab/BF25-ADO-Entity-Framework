using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entities
{
    [Table("room")]
    public class Room
    {
        [Key][Column("room_id")]
        public int Id { get; set; }

        [Column("option_id")]
        public int OptionId { get; set; }

        [Column("room_number")]
        public int Number { get; set; }

        [Column("room_floor")]
        public int Floor { get; set; }

        [Column("room_surface")]
        public int Surface { get; set; }

        [Column("image_url")]
        public string? Image { get; set; }

        [Column("room_max_capacity")]
        public int MaxCapacity { get; set; }

        [Column("room_price")]
        public int Price { get; set; }

        [ForeignKey(nameof(OptionId))]
        public List<Option> Options { get; set; }

    }
}
