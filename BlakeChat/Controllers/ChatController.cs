using BlakeChat.Data;
using BlakeChat.Hubs;
using BlakeChat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlakeChat.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        public readonly UserManager<AppUser> _userManager;
        public readonly Context _context;
        public ChatController(UserManager<AppUser> userManeger, Context context)
        {
            _userManager = userManeger;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.CurrentUserName = currentUser.UserName;
            ViewBag.Messages = _context.Message.ToList();
            return View();
        }
        public async Task<IActionResult> SendMessage(string text, [FromServices] IHubContext<ChatHub> chat)
        {
            var sender = await _userManager.GetUserAsync(User);
            Message message = new Message
            {
                text = text,
                userName = User.Identity.Name,
                userId = sender.Id,
                DateTime = DateTime.Now
            };
            _context.Message.Add(message);
            _context.SaveChanges();
            //return RedirectToAction(nameof(Index));
            await chat.Clients.All.SendAsync("ReceiveMessage", message);
            return Ok();
        }
    }
}
