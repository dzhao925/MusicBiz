using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W2022A6DZ.Models
{
    public class TrackAddFormViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "Track name")]
        public string Name { get; set; }

        // Simple comma-separated string of all the track's composers
        [Required, StringLength(500)]
        [Display(Name = "Composer names(comma-separated)")]
        public string Composers { get; set; }

        [Required]
        [Display(Name = "Track genre")]
        public SelectList Genre { get; set; }

        // User name who added/edited the track
        [StringLength(200)]
        public string Clerk { get; set; }

        public string AlbumName { get; set; }
        public int AlbumId { get; set; }

        [Required]
        [Display(Name = "Sample clip")]
        [DataType(DataType.Upload)]
        public string AudioUpload { get; set; }
    }
}