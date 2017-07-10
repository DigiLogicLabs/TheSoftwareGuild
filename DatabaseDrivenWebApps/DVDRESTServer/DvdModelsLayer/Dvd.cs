using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdModelsLayer
{
    public class Dvd
    {
        public int DvdId { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public int ReleaseYear { get; set; }
        public int? RatingId { get; set; }
        public int? DirectorId { get; set; }

        

        public virtual Director Director { get; set; }
        public virtual Rating Rating { get; set; }
    }
}