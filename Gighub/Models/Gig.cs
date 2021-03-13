using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Gighub.Models
{
    public class Gig
    {
        public int Id { get; set; }
        public bool IsCanceled { get; private set; }

        // who use it
        [Required]
        public string ArtistId { get; set; }

        public ApplicationUser Artist { get; set; }

        // when this going to happen
        public DateTime DateTime { get; set; }

        //  where this going to happen
        [Required]
        [StringLength(255)]
        public String Venue { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }

        public ICollection<Attendance> Attendances { get; private set; }
        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }
        public void Cancel()
        {
            IsCanceled = true;


            var notification = new Notification(this, NotificationType.GigCanceled);
            foreach (var attendee in Attendances.Select(g => g.Attendee))
            {
                // refactoring code
                attendee.Notify(notification);

            }
        }

    }

    
}