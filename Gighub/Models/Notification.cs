using System;
using System.ComponentModel.DataAnnotations;

namespace Gighub.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private  set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        [Required]
        public Gig Gig { get; private set; }

        private Notification(Gig gig, NotificationType type)
        {
            if (gig == null)
                throw new ArgumentNullException("Gig");

            Gig = gig;
            Type = type;
            DateTime = DateTime.Now;
        }
        protected Notification()
        {

        }

        public static Notification GigCreated(Gig gig)
        {
            return new Notification(gig, NotificationType.Gigcreated);
        }
        public static Notification GigUpdated(Gig NewGig,DateTime OriginalDateTime,string OriginalVenue)
        {
            var notification= new Notification(NewGig, NotificationType.Gigupdated);
            notification.OriginalDateTime = OriginalDateTime;
            notification.OriginalVenue = OriginalVenue;
            return notification;
        }
        public static Notification GigCanceled(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCanceled);
        }
    }
}