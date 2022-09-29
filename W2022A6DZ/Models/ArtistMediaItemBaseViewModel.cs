using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A6DZ.Models
{
    public class ArtistMediaItemBaseViewModel
    {
        [Required, StringLength(100)]
        public string Caption { get; set; }

        public int Id { get; set; }

        [Required, StringLength(100)]
        public string StringId { get; set; }

        public DateTime Timestamp { get; set; }

        [StringLength(200)]
        public string ContentType { get; set; }

    }
}