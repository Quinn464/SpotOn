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
    }
}
