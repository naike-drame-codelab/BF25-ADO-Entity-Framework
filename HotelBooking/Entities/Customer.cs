using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entities
{
    [Table("customer")]
    public class Customer
    {
        [Key][Column("customer_id")]
        public int Id { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone_number")]
        public string? Phone { get; set; }

        [ForeignKey(nameof(Id))]
        public Login LoginId { get; set; }    
    }
}
