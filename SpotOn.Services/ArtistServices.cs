using SpotOn.Data;
using SpotOn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Services
{
    public class ArtistService
    {
        private readonly Guid _userId;
        public ArtistService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateArtist(ArtistCreate model)
        {
            var entity =
                new Artist()
                {
                    AuthorId = _userId,
                    Name = model.Name,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ArtistListItem> GetArtist()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Artists
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                        e =>
                       new ArtistListItem
                       {
                           ArtistId = e.ArtistId,
                           Name = e.Name,
                           CreatedUtc = e.CreatedUtc
                       }
                     );
                return query.ToArray();
            }
        }
        public ArtistDetail GetArtistById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artists
                    .Single(e => e.ArtistId == id && e.AuthorId == _userId);
                return
                    new ArtistDetail
                    {
                        ArtistId = entity.ArtistId,
                        Name = entity.Name,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateArtist(ArtistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artists
                    .Single(e => e.ArtistId == model.ArtistId && e.AuthorId == _userId);
                entity.Name = model.Name;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;

            }

        }
        public bool DeleteArtist(int ArtistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artists
                    .Single(e => e.ArtistId == ArtistId && e.AuthorId == _userId);
                ctx.Artists.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
