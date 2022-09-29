using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A6DZ.Models
{
    public class TrackEditViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public HttpPostedFileBase AudioUpload { get; set; }
    }
}