using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gighub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        // who use it
        [Required]
        public ApplicationUser Artist { get; set; }

        // when this going to happen
        public DateTime DateTime { get; set; }

        //  where this going to happen
        [Required]
        [StringLength(255)]
        public String Venue { get; set; }

        [Required]
        public Genre Genre { get; set; }

    }

    
}