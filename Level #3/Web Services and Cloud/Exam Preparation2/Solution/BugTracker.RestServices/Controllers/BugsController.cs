namespace BugTracker.RestServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using BugTracker.Data.Models;
    using BugTracker.Data.UnitOfWork;
    using BugTracker.RestServices.Models;

    using Microsoft.AspNet.Identity;

    [RoutePrefix("api/bugs")]
    public class BugsController : ApiController
    {
        private readonly IBugTrackerData db;

        public BugsController() : this(new BugTrackerData())
        {
        }

        public BugsController(IBugTrackerData data)
        {
            this.db = data;
        }

        // GET: api/bugs
        [HttpGet]
        public IQueryable<BugOutputModel> GetBugs()
        {
            var bugs = db.Bugs.All()
                .OrderByDescending(b => b.DateCreated)
                .ThenByDescending(b => b.Id)
                .Select(b => new BugOutputModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Status = b.Status.ToString(),
                    Author = b.Author != null ? b.Author.UserName : null,
                    DateCreated = b.DateCreated
                });
            return bugs;
        }

        // GET: api/bugs/{id}
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetBugById(int id)
        {
            var bugDetails = db.Bugs.All()
                .Where(b => b.Id == id)
                .Select(b => new BugDetailsOutputModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Status = b.Status.ToString(),
                    Author = b.Author != null ? b.Author.UserName : null,
                    DateCreated = b.DateCreated,
                    Comments = b.Comments
                        .OrderByDescending(c => c.DateCreated)
                        .ThenByDescending(c => c.Id)
                        .Select(c => new CommentOutputModel()
                        {
                            Id = c.Id,
                            Text = c.Text,
                            Author = c.Author != null ? c.Author.UserName : null,
                            DateCreated = c.DateCreated
                        })
                }).FirstOrDefault();

            if (bugDetails == null)
            {
                return this.NotFound();
            }

            return Ok(bugDetails);
        }

        // POST: api/bugs
        [HttpPost]
        public IHttpActionResult SubmitBug(SubmitBugInputModel bugData)
        {
            if (bugData == null)
            {
                return BadRequest("Missing bug data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUserId = User.Identity.GetUserId();

            var bug = new Bug()
            {
                Title = bugData.Title,
                Description = bugData.Description,
                Status = BugStatus.Open,
                AuthorId = currentUserId,
                DateCreated = DateTime.Now
            };
            db.Bugs.Add(bug);
            db.SaveChanges();

            if (currentUserId != null)
            {
                return this.CreatedAtRoute(
                    "DefaultApi",
                    new { id = bug.Id },
                    new { bug.Id, Author = User.Identity.GetUserName(), Message = "User bug submitted." });
            }

            return this.CreatedAtRoute(
                "DefaultApi", 
                new { id = bug.Id },
                new { bug.Id, Message = "Anonymous bug submitted." });
        }

        // PATCH: api/bugs/{id}
        [HttpPatch]
        [Route("{id}")]
        public IHttpActionResult EditBug(int id, EditBugInputModel bugData)
        {
            if (bugData == null)
            {
                return BadRequest("Missing bug data to patch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return NotFound();
            }

            if (bugData.Title != null)
            {
                bug.Title = bugData.Title;
            }
            if (bugData.Description != null)
            {
                bug.Description = bugData.Description;
            }
            if (bugData.Status != null)
            {
                bug.Status = bugData.Status.Value;
            }

            db.Bugs.Update(bug);
            db.SaveChanges();

            return this.Ok(
                new
                {
                    Message = "Bug #" + id + " patched."
                }
            );
        }

        // DELETE: api/bugs/{id}
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteBug(int id)
        {
            var bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return NotFound();
            }

            db.Bugs.Remove(bug);
            db.SaveChanges();

            return Ok(new
            {
                Message = "Bug #" + id + " deleted."
            });
        }

        // GET: api/bugs/filter
        [HttpGet]
        [Route("filter")]
        public IEnumerable<BugOutputModel> GetBugsByFilter(
            [FromUri] string keyword = null,
            [FromUri] string statuses = null,
            [FromUri] string author = null)
        {
            IQueryable<BugOutputModel> bugs = this.GetBugs();

            if (keyword != null)
            {
                bugs = bugs.Where(b => b.Title.Contains(keyword));
            }

            if (statuses != null)
            {
                string[] allowedStatuses = statuses.Split('|');
                bugs = bugs.Where(b => statuses.Contains(b.Status));
            }

            if (author != null)
            {
                bugs = bugs.Where(b => b.Author == author);
            }

            return bugs;
        }
    }
}
