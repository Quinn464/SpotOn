using SpotOn.Data;
using SpotOn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotOn.Services
{
    public class UserService
    {
        private readonly Guid _authorId;

        public UserService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreateUser(UserCreate model)
        {
            var entity = new User()
            {
                AuthorId = _authorId,

                UserName = model.UserName,

                Email = model.Email,
                CreatedUtc = DateTimeOffset.Now,
               
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Users
                    .Where(e => e.AuthorId == _authorId)
                    .Select(
                        e =>
                        new UserListItem
                        {
                            UserId = e.UserId,

                            UserName = e.UserName,

                            CreatedUtc = e.CreatedUtc,
                        });
                return query.ToArray();
            }
        }

        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                            .Users
                            .Single(e => e.UserId == model.UserId && e.AuthorId == _authorId);
                
                entity.UserName = model.UserName; 

                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUser(int UserId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .Single(e => e.UserId == UserId && e.AuthorId == _authorId);
                ctx.Users.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
