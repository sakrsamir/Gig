using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gighub.Models
{
    public class Attendance
    {
  
        public Gig Gig { get; set; }
        public ApplicationUser Attendee { get; set; }


        /* create composite key for this table*/
        [Key]
        [Column(Order =1)]
        public int GigId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }
    }
}