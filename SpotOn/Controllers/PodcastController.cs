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
    public class PodcastController : ApiController
    {
        public IHttpActionResult Get()
        {
            PodcastService podcastService = CreatePodcastService();
            var posts = podcastService.GetPodcasts();
            return Ok(posts);
        }
        private PodcastService CreatePodcastService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PodcastService(userId);
            return postService;
        }
        public IHttpActionResult Post(PodcastCreate podcast)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePodcastService();
            if (!service.CreatePodcast(podcast))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(PodcastEdit podcast)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePodcastService();
            if (!service.UpdatePodcast(podcast))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePodcastService();
            if (!service.DeletePodcast(id))
                return InternalServerError();
            return Ok();
        }
    }
}

