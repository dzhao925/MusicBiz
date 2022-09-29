using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W2022A6DZ.Models
{
    public class ArtistWithMediaInfoViewModel : ArtistBaseViewModel
    {
        public ArtistWithMediaInfoViewModel()
        {
            ArtistMediaItems = new List<ArtistMediaItemBaseViewModel>();
        }
        public IEnumerable<ArtistMediaItemBaseViewModel> ArtistMediaItems { get; set; }
    }
}