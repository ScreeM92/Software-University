using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using GoblinFreelancer.Repository;
using GoblinFreelancer.Models;
using System.Data.Entity;
using GoblinFreelancer.ViewModels;
using System.Web.Script.Serialization;

namespace GoblinFreelancer.Hubs
{
    public class Chat : Hub
    {
        public Chat()
        {
            this.UnitOfWork = new UowData();
        }
        private UowData UnitOfWork { get; set; }
        public void SendMessage(string message, int projectId, string senderId)
        {            
            var user = this.UnitOfWork.Users.All().FirstOrDefault(u => u.Id == senderId);
            var project = this.UnitOfWork.Projects.GetById(projectId);

            var msg = new SendedMessageViewModel 
            {
                SenderName = user.UserName,
                PostDate = DateTime.Now.ToLongTimeString(),
                Message = message
            };

            Message dbMessage = new Message
            {
                DateSend = DateTime.Now,
                Body = message,
                Project = project,
                Sender = user
            };
            this.UnitOfWork.Messages.Add(dbMessage);
            this.UnitOfWork.SaveChanges();

            Clients.Group(projectId.ToString()).addMessage(msg);
        }

        public void JoinRoom(string room)
        {
            Groups.Add(Context.ConnectionId, room);
        }

        public void LoadMessages(int projectId)
        {
            var messages = this.UnitOfWork
                .Messages
                .All()
                .OrderByDescending(message => message.DateSend)
                .Take(10)
                .OrderBy(message => message.DateSend)
                .Where(msg => msg.Project.Id == projectId)
                .ToList()
                .Select(SendedMessageViewModel.FromMessage);

            Clients.Group(projectId.ToString()).loadMessages(messages);
        }
    }
}