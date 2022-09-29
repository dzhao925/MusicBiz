using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W2022A6DZ.Models
{
    public class TrackAudioViewModel
    {
        public int id { get; set; }
        public string AudioContentType { get; set; }
        public byte[] Audio { get; set; }
    }
}