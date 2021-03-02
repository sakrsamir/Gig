using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gighub.Models
{
    public class Genre
    {
        // we don't have more than 255 genres
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

    }
}