using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A6DZ.Models
{
    public class AlbumAddViewModel
    {
        public AlbumAddViewModel()
        {
            ReleaseDate = DateTime.Now;
        }

        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Required, StringLength(512)]
        public string UrlAlbum { get; set; }

        [Required]
        public string Genre { get; set; }


        [StringLength(10000)]
        public string Background { get; set; }

        public string ArtistName { get; set; }
        public int ArtistId { get; set; }
    }
}