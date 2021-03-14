﻿using AutoMapper;
using Gighub.Dtos;
using Gighub.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Gighub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId&& !un.isRead)
                .Select(un => un.Notification)
                .Include(un => un.Gig.Artist)
                .ToList();

            

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);

            //return notifications.Select(n => new NotificationDto()
            //{
            //    DateTime = n.DateTime,
            //    Gig = new GigDto
            //    {
            //        Artist = new UserDto
            //        {
            //            Id = n.Gig.Artist.Id,
            //            Name = n.Gig.Artist.Name
                       
            //        },
            //        DateTime=n.Gig.DateTime,
            //        Id=n.Gig.Id,
            //        IsCanceled=n.Gig.IsCanceled,
            //        Venue = n.Gig.Venue
            //    },
            //    OriginalDateTime = n.OriginalDateTime,
            //    OriginalVenue=  n.OriginalVenue,
            //    Type = n.Type

            //});
        }
    }
}
