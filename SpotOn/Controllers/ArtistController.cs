using Microsoft.AspNet.Identity;
using SpotOn.Models;
using SpotOn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SpotOn.Controllers
{
    public class ArtistController : ApiController
    {
        public IHttpActionResult Get()
        {
            ArtistService ArtistService = CreateArtistService();
            var posts = ArtistService.GetArtist();
            return Ok(posts);
        }

        private ArtistService CreateArtistService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new ArtistService(userId);
            return postService;
        }

        public IHttpActionResult Post(ArtistCreate Artist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateArtistService();

            if (!service.CreateArtist(Artist))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(ArtistEdit Artist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateArtistService();

            if (!service.UpdateArtist(Artist))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateArtistService();

            if (!service.DeleteArtist(id))
                return InternalServerError();

            return Ok();
        }
    }
}