using System;
using System.ComponentModel.DataAnnotations;

namespace Gighub.Models
{
    public class Gig
    {
        public int Id { get; set; }

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

    }

    
}