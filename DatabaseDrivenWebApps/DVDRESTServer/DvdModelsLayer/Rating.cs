using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdModelsLayer
{
    public class Rating
    {
        public int RatingId { get; set; }
        public string MovieRating { get; set; }
        public List<Dvd> Dvds { get; set; }
    }
}