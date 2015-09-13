using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Messages.Data;
using Messages.Data.Models;
using Messages.RestServices.ViewModels;

namespace Messages.RestServices.Controllers
{
    public class ChannelsController : ApiController
    {
        private MessagesDbContext db = new MessagesDbContext();

        // GET: api/Channels
        public IQueryable<ChannelViewModel> GetChannels()
        {
            return db.Channels.OrderBy(ch => ch.Name).Select(ch => new ChannelViewModel
            {
                Id = ch.Id,
                Name = ch.Name
            });
        }

        // GET: api/Channels/5
        [ResponseType(typeof(ChannelViewModel))]
        public IHttpActionResult GetChannel(int id)
        {
            Channel channel = db.Channels.Find(id);
            if (channel == null)
            {
                return NotFound();
            }

            return Ok(new ChannelViewModel()
            {
                Id = channel.Id,
                Name = channel.Name
            });
        }

        // PUT: api/Channels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChannel(int id, Channel channel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (channel == null)
            {
                return BadRequest();
            }

            var dbChannel = db.Channels.Find(id);

            if (dbChannel == null)
            {
                return NotFound();
            }

            if (db.Channels.Any(ch => ch.Name == channel.Name && ch.Id != id))
            {
                return Conflict();
            }

            dbChannel.Name = channel.Name;
            db.SaveChanges();

            return this.Ok(new
            {
                Message = "Channel #" + id + " edited succesfully."
            });
        }

        // POST: api/Channels
        [ResponseType(typeof(ChannelViewModel))]
        public IHttpActionResult PostChannel(Channel channel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(channel == null)
            {
                return BadRequest();
            }

            if(db.Channels.Any(ch => ch.Name == channel.Name))
            {
                return Conflict();
            }

            db.Channels.Add(channel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = channel.Id }, new ChannelViewModel()
            {
                Id = channel.Id,
                Name = channel.Name
            });
        }

        // DELETE: api/Channels/5
        [ResponseType(typeof(Channel))]
        public IHttpActionResult DeleteChannel(int id)
        {
            Channel channel = db.Channels.Find(id);
            if (channel == null)
            {
                return NotFound();
            }

            db.Channels.Remove(channel);
            db.SaveChanges();

            return this.Ok(new
            {
                Message = "Channel #" + id + " deleted."
            });
        }

        private bool ChannelExists(int id)
        {
            return db.Channels.Count(e => e.Id == id) > 0;
        }
    }
}