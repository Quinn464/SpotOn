
using SpotOn.Data;
using SpotOn.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotOn.Services
{
    public class PodcastService
  
        {
            private readonly Guid _authorId;

            public PodcastService(Guid authorId)
            {
                _authorId = authorId;
            }

            public bool CreatePodcast(PodcastCreate model)
            {
                var entity = new Podcast()
                {
                    AuthorId = _authorId,
                    Name = model.Name,
                    Genre = model.Genre,
                    CreatedUtc = DateTimeOffset.Now,
                    ArtistId = model.ArtistId,
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Podcasts.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }

            public IEnumerable<PodcastListItem> GetPodcasts()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                        .Podcasts
                        .Where(e => e.AuthorId == _authorId)
                        .Select(
                            e =>
                            new PodcastListItem
                            {
                                PodcastId = e.PodcastId,
                                Name = e.Name,
                                CreatedUtc = e.CreatedUtc,
                            });
                    return query.ToArray();
                }
            }

            public bool UpdatePodcast(PodcastEdit model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity = ctx
                                .Podcasts
                                .Single(e => e.PodcastId == model.PodcastId && e.AuthorId == _authorId);
                    entity.Name = model.Name;
                    entity.Genre = model.Genre;
                    entity.ModifiedUtc = DateTimeOffset.UtcNow;

                    return ctx.SaveChanges() == 1;
                }
            }

            public bool DeletePodcast(int PodcastId)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .Podcasts
                        .Single(e => e.PodcastId == PodcastId && e.AuthorId == _authorId);
                    ctx.Podcasts.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
            }
        }
    }

