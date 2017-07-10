using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdModelsLayer;
using DvdModelsLayer.Interface;


namespace DvdDataLayer
{
    public class DvdTESTRepo : IDvdRepository
    {
        public static List<Director> Directors = new List<Director>
        {
            new Director{DirectorId = 1, Name = "Conner Soligny"},
            new Director{DirectorId = 2, Name = "Willie Soligny"},
            new Director{DirectorId = 3, Name = "Jeremy Poppe"}
        };

        public static List<Rating> Ratings = new List<Rating>
        {
            new Rating{RatingId = 0, MovieRating = "G"},
            new Rating{RatingId = 1, MovieRating = "PG"},
            new Rating{RatingId = 2, MovieRating = "PG-13"},
            new Rating{RatingId = 3, MovieRating = "R"}
        };

        private List<Dvd> _dvds = new List<Dvd>
        {
            
            new Dvd{DvdId = 1, Title = "Doomsday", ReleaseYear = 2010, Notes = "This MOVIE is CRAZY!",RatingId = 1,   DirectorId =  1, Director = Directors.FirstOrDefault(i => i.DirectorId == 1), Rating =  Ratings.FirstOrDefault(i => i.RatingId == 1)},
            new Dvd{DvdId = 2, Title = "Broomsday", ReleaseYear = 2011, Notes = "This MOVIE is CLEAN!",RatingId = 2,   DirectorId =  2, Director = Directors.FirstOrDefault(i => i.DirectorId ==2), Rating = Ratings.FirstOrDefault(i => i.RatingId ==2)},
            new Dvd{DvdId = 3, Title = "Groomsday", ReleaseYear = 2012, Notes = "This MOVIE is HILARIOUS!",RatingId = 3,   DirectorId =  3, Director = Directors.FirstOrDefault(i => i.DirectorId == 3), Rating = Ratings.FirstOrDefault(i => i.RatingId == 3)}
//            Director.FirstOrDefault(i => i.DirectorId == 1)
        };
        public List<Dvd> GetAll()
        {
            return _dvds;
        }

        public Dvd Get(string id)
        {
            return _dvds.FirstOrDefault(i => i.DvdId == int.Parse(id));
        }

        public void Add(Dvd dvd)
        {
            dvd.DvdId = _dvds.Max(i => i.DvdId) + 1;
            _dvds.Add(dvd);
        }

        public void Edit(Dvd dvd)
        {
            var found = _dvds.FirstOrDefault(i => i.DvdId == dvd.DvdId);

            found.Title = dvd.Title;
            found.ReleaseYear = dvd.ReleaseYear;
            found.Rating = dvd.Rating;
            found.Notes = dvd.Notes;
//            found.DirectorId = Directors.FirstOrDefault(i => i.DirectorId == dvd.DirectorId)
            
            

            if (found != null)
            {
                found = dvd;
            }
        }

        public void Delete(int id)
        {
            _dvds.RemoveAll(i => i.DvdId == id);
        }

        public List<Dvd> FindAll(string category, string term)
        {
            List<Dvd> matchedDvds = new List<Dvd>();
            switch (category)
            {
                case "Title":
                    matchedDvds = _dvds.FindAll(i => i.Title == term);
                    break;
                case "ReleaseYear":
                    matchedDvds = _dvds.FindAll(i => i.ReleaseYear == int.Parse(term));
                    break;
                case "Director":
                    matchedDvds = _dvds.FindAll(i => i.Director.Name == term);
                    break;
                case "Rating":
                    matchedDvds = _dvds.FindAll(i => i.Rating.MovieRating == term);
                    break;
                    defualt:
                    matchedDvds = _dvds.FindAll(i => i.Title == term);
                    break;
            }
            return matchedDvds;
        }
    }
}
