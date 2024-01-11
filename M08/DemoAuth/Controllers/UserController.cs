using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoAuth.Controllers
{
    [Authorize(Roles ="admin")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public UserController(UserManager<IdentityUser>userManager) { 

            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            List<IdentityUser> users =userManager.Users.ToList();
            return View(users);
        }
    }
}
