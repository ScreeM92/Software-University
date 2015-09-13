namespace BugTracker.RestServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using BugTracker.Data.Models;
    using BugTracker.Data.UnitOfWork;
    using BugTracker.RestServices.Models;

    using Microsoft.AspNet.Identity;

    [RoutePrefix("api")]
    public class CommentsController : ApiController
    {
        private readonly IBugTrackerData db;

        public CommentsController() : this(new BugTrackerData())
        {
        }

        public CommentsController(IBugTrackerData data)
        {
            this.db = data;
        }

        // GET: api/comments
        [HttpGet]
        [Route("comments")]
        public IHttpActionResult GetComments()
        {
            var comments = db.Comments.All()
                .OrderByDescending(c => c.DateCreated)
                .ThenByDescending(c => c.Id)
                .Select(c => new CommentWithBugOutputModel()
                {
                    Id = c.Id,
                    Text = c.Text,
                    Author = c.Author != null ? c.Author.UserName : null,
                    DateCreated = c.DateCreated,
                    BugId = c.Bug.Id,
                    BugTitle = c.Bug.Title,
                });
            return this.Ok(comments);
        }

        // GET: api/bugs/{id}/comments
        [HttpGet]
        [Route("bugs/{id}/comments")]
        public IHttpActionResult GetBugComments(int id)
        {
            var bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            var bugDetails = bug.Comments
                .OrderByDescending(c => c.DateCreated)
                .ThenByDescending(c => c.Id)
                .Select(c => new CommentOutputModel()
                {
                    Id = c.Id,
                    Text = c.Text,
                    Author = c.Author != null ? c.Author.UserName : null,
                    DateCreated = c.DateCreated
                });

            return Ok(bugDetails);
        }

        // POST: api/bugs/{id}/comments
        [HttpPost]
        [Route("bugs/{id}/comments")]
        public IHttpActionResult AddComment(int id, CommentInputModel commentData)
        {
            if (commentData == null)
            {
                return BadRequest("Missing comment data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            var currentUserId = User.Identity.GetUserId();

            var comment = new Comment()
            {
                Text = commentData.Text,
                AuthorId = currentUserId,
                DateCreated = DateTime.Now,
                BugId = bug.Id
            };
            db.Comments.Add(comment);
            db.SaveChanges();

            if (currentUserId != null)
            {
                var currentUserName = User.Identity.GetUserName();
                return this.Ok(new
                {
                    comment.Id,
                    Author = currentUserName,
                    Message = "User comment added   for bug #" + id
                });
            }
        
            return this.Ok(new
            {
                comment.Id,
                Message = "Added anonymous comment for bug #" + id
            });
        }
    }
}
