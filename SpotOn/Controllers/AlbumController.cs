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
    public class AlbumController : ApiController
    {
        public IHttpActionResult Get()
        {
            AlbumService albumService = CreateAlbumService();
            var posts = albumService.GetAlbums();
            return Ok(posts);
        }

        private AlbumService CreateAlbumService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var albumService = new AlbumService(userId);
            return albumService;
        }

        public IHttpActionResult Post(AlbumCreate album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumService();

            if (!service.CreateAlbum(album))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(AlbumEdit album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumService();

            if (!service.UpdateAlbum(album))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAlbumService();

            if (!service.DeleteAlbum(id))
                return InternalServerError();

            return Ok();
        }
    }
}
