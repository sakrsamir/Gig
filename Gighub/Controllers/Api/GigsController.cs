﻿using Gighub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace Gighub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs.Single(g => g.Id == id && g.ArtistId == userId);

            if (gig.IsCanceled)
                return NotFound();

            gig.IsCanceled = true;


            var notification = new Notification(gig, NotificationType.GigCanceled);
            //{
            //    DateTime = DateTime.Now,
            //    Gig = gig,
            //    Type = NotificationType.GigCanceled
            //};
            _context.Notifications.Add(notification);

            var attendees = _context.Attendances
                .Where(a => a.GigId == gig.Id)
                .Select(s => s.Attendee)
                .ToList();

            foreach (var attendee in attendees)
            {
                // refactoring code
                attendee.Notify(notification);
                
            } 

            _context.SaveChanges();
            return Ok();
        }
    }
}
