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
    public class PlaylistController : ApiController
    {
        public IHttpActionResult Get()
        {
            PlaylistService PlaylistService = CreatePlaylistService();
            var posts = PlaylistService.GetPlaylist();
            return Ok(posts);
        }

        private PlaylistService CreatePlaylistService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PlaylistService(userId);
            return postService;
        }

        public IHttpActionResult Post(PlaylistCreate Playlist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePlaylistService();

            if (!service.CreatePlaylist(Playlist))
                return InternalServerError();

            return Ok();
        }

        //public IHttpActionResult Put(PlaylistEdit Playlist)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var service = CreatePlaylistService();

        //    if (!service.UpdatePlaylist(Playlist))
        //        return InternalServerError();

        //    return Ok();
        //}

        public IHttpActionResult Delete(int id)
        {
            var service = CreatePlaylistService();

            if (!service.DeletePlaylist(id))
                return InternalServerError();

            return Ok();
        }
    }
}