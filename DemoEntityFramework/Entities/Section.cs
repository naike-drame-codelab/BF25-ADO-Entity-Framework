using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEntityFramework.Entities
{
    [Table("section")]
    public class Section
    {
        [Column("section_id")]
        public int Id { get; set; }

        [Column("section_name")]
        public string Name { get; set; } = null!;

        [Column("delegate_id")]
        public int? DelegateId { get; set; } // int? car colonne nullable dans db

        public List<Student> Students { get; set; } = null!; // un Student a 1! Section mais une Section a plusieurs Students

    }
}
