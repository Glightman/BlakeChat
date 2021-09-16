using BlakeChat.Data;
using BlakeChat.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlakeChat.Hubs
{
    public class ChatHub : Hub
    {
        Context _context;
        public ChatHub(Context context)
        {
            _context = context;
        }
        public async Task SendMessage(Message m)
        {
            m.DateTime = DateTime.Now;
            if (m.userName != Context.User.Identity.Name) return;
            var user = _context.Users.FirstOrDefault(u => u.UserName == m.userName);

            if (user == null) return;

            m.userId = user.Id;
            _context.Message.Add(m);
            _context.SaveChanges();

            Message returnMessage = new Message
            {
                userName = m.userName,
                text = m.text,
                DateTime = m.DateTime
            };
            await Clients.All.SendAsync("ReceiveMessage", returnMessage);
        }
    }
}
