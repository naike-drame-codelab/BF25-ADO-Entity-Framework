using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entities
{
    [Table("login")]
    public class Login
    {
        [Key][Column("login_id")]
        public int Id { get; set; }

        [Column("user_name")]
        public string Username { get; set; }

        [Column("password")]
        public byte[] Password { get; set; }

        [Column("role")]
        public RoleType Role { get; set; }

    }
}
