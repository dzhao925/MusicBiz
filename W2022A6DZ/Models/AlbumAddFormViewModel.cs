using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W2022A6DZ.Models
{
    public class AlbumAddFormViewModel
    {
        public AlbumAddFormViewModel()
        {
            ReleaseDate = DateTime.Now;
        }

        public int Id { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Album name")]
        public string Name { get; set; }

        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Required, StringLength(512)]
        [Display(Name = "URL to album image (cover art)")]
        public string UrlAlbum { get; set; }

        [Required]
        [Display(Name = "Album primary genre")]
        public SelectList Genre { get; set; }

        [StringLength(10000)]
        [Display(Name = "Album background")]
        [DataType(DataType.MultilineText)]
        public string Background { get; set; }

        public string ArtistName { get; set; }
        public int ArtistId { get; set; }

    }
}