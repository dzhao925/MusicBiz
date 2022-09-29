using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A6DZ.Models
{
    public class ArtistMediaItemAddFormViewModel
    {
        public int ArtistId { get; set; }

        public string ArtistName { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Description")]
        public string Caption { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Media item")]
        public string ContentUpload { get; set; }
    }
}