using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using DvdModelsLayer.Models.Interface;
using DvdModelsLayer.Models;
using DvdModelsLayer.Models.DvdRequests;

namespace DvdModelsLayer.Controllers
{
    public class DvdController : ApiController
    {
        //// GET: api/DVD
        //private IDvdRepository _repo;

        //public DvdController(IDvdRepository repo)
        //{
        //    _repo = repo;
        //}

            

            
        //Get all Dvds
        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            return Ok(_repo.GetAll());
        }

        //Get Dvd by Id
        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetById(string id)
        {
            return Ok(_repo.Get(id));
        }

        //Get Dvd by title
        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
//            List<Dvd> dvds = _repo.FindAll(title);
//            if (dvds == null)
//            {
//                return NotFound();
//            }


            return Ok(_repo.Get(title));
        }

        //Get Dvd by ReleaseYear
        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByReleaseYear(int releaseyear)
        {


//            return Ok(_repo.Get(int.Parse(releaseyear)));
            return Ok();
        }

        //Get Dvd by Directorname
        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByDirectorName(string name)
        {

                        return Ok(_repo.Get(name));
        }


        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRating(string rating)
        {
            return Ok(_repo.Get(rating));
        }

        //attempted to create a POST method, can't get the Rating and director to work... Do I use LINQ??

        [Route("dvd")]
        [AcceptVerbs("POST")]
        // GET: api/DVD/5
        public IHttpActionResult AddDvd(AddingDvd request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            Dvd dvd = new Dvd()
            {
                Title = request.Title,
                ReleaseYear = request.ReleaseYear,
//                Rating = request.Rating,
//                Director = request.Director,
                Notes = request.Notes

            };
            _repo.Add(dvd);
            return Created($"movies/get/{dvd.DvdId}", dvd);
        }



        // PUT: api/DVD/5
        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult UpdateExisting(string id)
        {
            Dvd found = _repo.Get(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (found == null)
            {
                return NotFound();
            }

//            found.Title = 

            _repo.Edit(found);
            return Ok();

        }

        // DELETE: api/DVD/5
        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(string id)
        {
            Dvd found = _repo.Get(id);

            if (found == null)
            {
                return NotFound();
            }

            _repo.Delete(int.Parse(id));
            return Ok();
        }


}
    //            [Route("dvd/{dvdId}")]
    //            [AcceptVerbs("GET")]
    //        public IHttpActionResult GetDvdById(int dvdId)
    //        {
    //            return Ok(new ViewModel[]
    //            {   
    //                
    //                new ViewModel()
    //                {
    //                    dvdId = 0,
    //                    title = "A Great Tale",
    //                    releaseYear = 2015,
    //                    director = "Sam Jones",
    //                    rating = "PG",
    //                    notes = "This is a really great tale!"
    //                },
    //
    //                new ViewModel()
    //                {
    //                    dvdId = 1,
    //                    title = "A Good Tale",
    //                    releaseYear = 2012,
    //                    director = "Joe Smith",
    //                    rating = "PG-13",
    //                    notes = "This is a good tale!"
    //                }
    //            });
    //        }
    //
    //        [Route("dvds")]
    //        [AcceptVerbs("GET")]
    //        public IHttpActionResult ListofDvds()
    //        {
    //            
    //            return Ok(new ViewModel[]
    //            {
    //                new ViewModel()
    //                {
    //                    dvdId = 0,
    //                    title = "A Great Tale",
    //                    releaseYear = 2015,
    //                    director = "Sam Jones",
    //                    rating = "PG",
    //                    notes = "This is a really great tale!"
    //                },
    //
    //                new ViewModel()
    //                {
    //                    dvdId = 1,
    //                    title = "A Good Tale",
    //                    releaseYear = 2012,
    //                    director = "Joe Smith",
    //                    rating = "PG-13",
    //                    notes = "This is a good tale!"
    //                }
    //            });
    //        }
}
