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
    [Authorize]
    public class ArtistController : ApiController
    {
        private ArtistService CreateArtistService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var artistService = new ArtistService(userId);
            return artistService;
        }
        public IHttpActionResult Get()
        {
            ArtistService artistService = CreateArtistService();
            var artists = artistService.GetArtist();
            return Ok(artists);

        }
        public IHttpActionResult Artist(ArtistCreate artist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateArtistService();
            if (!service.CreateArtist(artist))
                return InternalServerError();
            return Ok();


        }
        public IHttpActionResult Get(int id)
        {
            ArtistService artistService = CreateArtistService();
            var artist = artistService.GetArtistById(id);
            return Ok(artist);

        }
        public IHttpActionResult Put(ArtistEdit artist)
        {

            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var service = CreateArtistService();

                if (!service.UpdateArtist(artist))

                    return InternalServerError();

                return Ok();

            }
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateArtistService();
            if (!service.DeleteArtist(id))

            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}