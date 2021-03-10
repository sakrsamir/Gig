using Gighub.Controllers;
using Gighub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;


namespace Gighub.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Heading { get; set; }
        public string Action {
            get
            {

                // change name of action dynamic if name is chaged this upadte names 
                Expression<System.Func<GigsController, ActionResult>> Update =
                    (c => c.Update(null));

                Expression<System.Func<GigsController, ActionResult>> Create =
                    (c => c.Create(null));

                var action = (Id != 0) ? Update : Create;
                var actionName = (action.Body as MethodCallExpression).Method.Name;

                //return (Id != 0) ? "Update" : "Create";
                return actionName;
            }
        }
        // controller is manager cordante what should we do next only 
        // in oop we have a principle called information expert that should do this
        public DateTime GetDatetime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}