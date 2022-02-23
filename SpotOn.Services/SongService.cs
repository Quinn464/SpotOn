using SpotOn.Data;
using SpotOn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Services
{
    public class SongService
    {
        private readonly Guid _authorId;

        public SongService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreateSong(SongCreate model)
        {
            var entity = new Song()
            {
                AuthorId = _authorId,
                Name = model.Name,
                Genre = model.Genre,
                CreatedUtc = DateTimeOffset.Now,
                ArtistId = model.ArtistId,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Songs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SongListItem> GetSongs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Songs
                    .Where(e => e.AuthorId == _authorId)
                    .Select(
                        e =>
                        new SongListItem
                        {
                            SongId = e.SongId,
                            Name = e.Name,
                            CreatedUtc = e.CreatedUtc,
                        });
                return query.ToArray();
            }
        }

        public bool UpdateSong(SongEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                            .Songs
                            .Single(e => e.SongId == model.SongId && e.AuthorId == _authorId);
                entity.Name = model.Name;
                entity.Genre = model.Genre;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSong(int songId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Songs
                    .Single(e => e.SongId == songId && e.AuthorId == _authorId);
                ctx.Songs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
