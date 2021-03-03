using Gighub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gighub.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }


        // controller is manager cordante what should we do next only 
        // in oop we have a principle called information expert that should do this
        public DateTime GetDatetime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}