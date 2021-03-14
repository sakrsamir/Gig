﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Gighub.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private  set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }

        [Required]
        public Gig Gig { get; private set; }

        public Notification(Gig gig, NotificationType type)
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
    }
}