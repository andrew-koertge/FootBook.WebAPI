using FootBook.Data;
using FootBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBook.Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    Text = model.Text,
                    Post = model.CommentPost
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.Author.OwnerId == _userId)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    //CommentId = e.CommentId,
                                    Text = e.Text
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
