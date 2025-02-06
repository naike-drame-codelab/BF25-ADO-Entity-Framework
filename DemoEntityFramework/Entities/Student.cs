using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEntityFramework.Entities
{
    // si ça correspond pas, on écrit; si ça correspond, pas obligatoire
    [Table("student")]
    public class Student
    {
        [Column("student_id")]
        public int Id { get; set; }

        [Column("last_name")]
        public string Name { get; set; } = null!;

        [Column("first_name")]
        public string FirstName { get; set; } = null!;

        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        public string Login { get; set; } = null!;

        [Column("section_id")]
        public int SectionId { get; set; }

        [Column("year_result")]
        public int Result { get; set; }

        [Column("course_id")]
        public string CourseId { get; set; } = null!;

        [ForeignKey(nameof(SectionId))]
        public Section Section { get; set; } = null!; // un Student a 1! Section mais une Section a plusieurs Students
    }
}
