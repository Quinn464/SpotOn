using SpotOn.Data;
using SpotOn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Services
{
  public class PlaylistService
        {
          private readonly Guid _userId;
    public PlaylistService(Guid userId)
    {
        _userId = userId;
    }
    public bool CreatePlaylist(PlaylistCreate model)
    {
        var entity =
            new Playlist()
            {
                AuthorId = _userId,
                Name = model.Name,
                CreatedUtc = DateTimeOffset.Now
            };
        using (var ctx = new ApplicationDbContext())
        {
            ctx.Playlists.Add(entity);
            return ctx.SaveChanges() == 1;
        }
    }
    public IEnumerable<PlaylistListItem> GetPlaylist()
    {
        using (var ctx = new ApplicationDbContext())
        {
            var query =
                ctx
                .Playlists
                .Where(e => e.AuthorId == _userId)
                .Select(
                    e =>
                   new PlaylistListItem
                   {
                       PlaylistId = e.PlaylistId,
                       Name = e.Name,
                       CreatedUtc = e.CreatedUtc
                   }
                 );
            return query.ToArray();
        }
    }
    public PlaylistDetail GetPlaylistById(int id)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                .Playlists
                .Single(e => e.PlaylistId == id && e.AuthorId == _userId);
            return
                new PlaylistDetail
                {
                    PlaylistId = entity.PlaylistId,
                    Name = entity.Name,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
        }
    }
    public bool UpdatePlaylist(PlaylistEdit model)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                .Playlists
                .Single(e => e.PlaylistId == model.PlaylistId && e.AuthorId == _userId);
            entity.Name = model.Name;
            entity.ModifiedUtc = DateTimeOffset.UtcNow;

            return ctx.SaveChanges() == 1;

        }

    }
    public bool DeletePlaylist(int PlaylistId)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                .Playlists
                .Single(e => e.PlaylistId == PlaylistId && e.AuthorId == _userId);
            ctx.Playlists.Remove(entity);
            return ctx.SaveChanges() == 1;
        }
    }

}

}
