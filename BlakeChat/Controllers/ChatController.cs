using BlakeChat.Data;
using BlakeChat.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlakeChat.Controllers
{
    public class ChatController : Controller
    {
        public readonly UserManager<AppUser> _userManager;
        public readonly Context _context;
        public ChatController(UserManager<AppUser> userManeger, Context context)
        {
            _userManager = userManeger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
