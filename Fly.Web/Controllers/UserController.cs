using Fly.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Fly.Web.Controllers
{
   
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly UserService userService;
        
        public UserController(IUserRepository userRepository, UserService userService)
        {
            this.userService= userService;
            this.userRepository = userRepository;
        }
        
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!User.IsInRole("Common"))
                {
                    if (User.IsInRole("Administrator"))
                    {
                        var model = userRepository.GetAll();
                        return View(model);
                    }
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult ChangeRole(int userId, int roleId)
        {
            userRepository.ChangeRole(userId, roleId);
            return RedirectToAction("Index", "User");
        }
        [HttpPost]
        public IActionResult TopUpBalance(int userId, long amountToTopUp)
        {
            userRepository.TopUpBalance(userId, amountToTopUp);
            return RedirectToAction("Index", "User");
        }
        [HttpGet]
        public IActionResult TopUpBalance(int userId)
        {
            var model = userRepository.GetById(userId);
            RedirectToAction("Logout", "Account");
            RedirectToAction("Login", "Account");
            return View(model);
        }
        public IActionResult WriteOffBalance(int userId, long amountToWriteOff)
        {
            userRepository.WriteOffBalance(userId, amountToWriteOff);
            return RedirectToAction("Index", "User");
        }
        public IActionResult DeleteUser(int userId)
        {
            userRepository.DeleteUserById(userId);
            return RedirectToAction("Index", "User");
        }



    }
}
