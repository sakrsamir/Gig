using Gighub.Models;
using System;
using System.Collections.Generic;

namespace Gighub.ViewModels
{
    public class GigFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }


        // controller is manager cordante what should we do next only 
        // in oop we have a principle called information expert that should do this
        public DateTime GetDatetime
        {
            get
            {
                return DateTime.Parse(string.Format("{0} {1}", Date, Time));
            }
        }
    }
}