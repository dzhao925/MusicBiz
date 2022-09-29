using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A6DZ.Models
{
    public class ArtistMediaItemContentViewModel
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}