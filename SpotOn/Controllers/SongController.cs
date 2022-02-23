using Microsoft.AspNet.Identity;
using SpotOn.Models;
using SpotOn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpotOn.Controllers
{
    public class SongController : ApiController
    {
        public IHttpActionResult Get()
        {
            SongService songService = CreateSongService();
            var posts = songService.GetSongs();
            return Ok(posts);
        }

        private SongService CreateSongService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new SongService(userId);
            return postService;
        }

        public IHttpActionResult Post(SongCreate song)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.CreateSong(song))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(SongEdit song)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.UpdateSong(song))
                return InternalServerError();

            return Ok(); 
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateSongService();

            if (!service.DeleteSong(id))
                return InternalServerError();

            return Ok();
        }
    }
}
