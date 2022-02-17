using SpotOn.Data;
using SpotOn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Services
{
    public class AlbumService
    {
        private readonly Guid _authorId;

        public AlbumService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreateAlbum(AlbumCreate model)
        {
            var entity = new Album()
            {
                AuthorId = _authorId,
                Name = model.Name,
                Genre = model.Genre,
                CreatedUtc = DateTimeOffset.Now,
                ArtistId = model.ArtistId,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Albums.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AlbumListItem> GetAlbums()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Albums
                    .Where(e => e.AuthorId == _authorId)
                    .Select(
                        e =>
                        new AlbumListItem
                        {
                            AlbumId = e.AlbumId,
                            Name = e.Name,
                            CreatedUtc = e.CreatedUtc,
                        });
                return query.ToArray();
            }
        }

        public bool UpdateAlbum(AlbumEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                            .Albums
                            .Single(e => e.AlbumId == model.AlbumId && e.AuthorId == _authorId);
                entity.Name = model.Name;
                entity.Genre = model.Genre;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAlbum(int albumId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Albums
                    .Single(e => e.AlbumId == albumId && e.AuthorId == _authorId);
                ctx.Albums.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
