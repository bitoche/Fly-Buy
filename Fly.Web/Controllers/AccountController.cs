using Fly.Services;
using Fly.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fly.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService userService;
        public AccountController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string name, string login, string password)
        {
            //if (ModelState.IsValid)
            //{
                var response = userService.Register(name, password, login);
                if(response.StatusCode == Fly.Services.StatusCode.OK)
                {
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(response.Data));

                    return RedirectToAction("Index", "Home");
                }
                //НАДО ПОЗЖЕ ДОДЕЛАТЬ МОДЕЛЬ
                //ModelState.AddModelError("", response.Description);

            //}
            return View();
        }
        [HttpGet]
        public IActionResult Login() 
        { 
            return View();
        }

        [HttpPost]      
        public async Task<IActionResult> Login(string login, string password)
        {
            //if(ModelState.IsValid)
            //{
                var response = userService.Login(login, password);
                if (response.StatusCode == Fly.Services.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(response.Data));

                    return RedirectToAction("Index", "Home");
                }
                //НАДО ПОЗЖЕ ДОДЕЛАТЬ МОДЕЛЬ
                //ModelState.AddModelError("", response.Description);
           // }
            return View();
        }

        
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
