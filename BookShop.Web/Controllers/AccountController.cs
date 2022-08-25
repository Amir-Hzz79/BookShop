using BookShop.DataLayer.Models;
using BookShop.DataLayer.Services;
using BookShop.DataLayer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace BookShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] User user/*, [FromQuery] string returnUrl="/"*/)
        {
            if (ModelState.IsValid)
            {
                //var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, true, false);

                //if (result.Succeeded)
                //{
                //    return Redirect("/");
                //}

                //ModelState.AddModelError("", "User not found!!");
            }

            return View(user);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] User user)
        {
            if (ModelState.IsValid)
            {
                //var user = new User()
                //{
                //    Username = registerUser.Username,
                //    Password = registerUser.Password
                //};

                bool isSecceed = _userService.Insert(user);

                if (isSecceed)
                {
                    //await _signInManager.SignInAsync(user, false);
                    //SignIn(user);
                    return Redirect("/");
                }
                else
                {
                    //foreach (var error in isSecceed.Errors)
                    //{
                    //    ModelState.AddModelError("", error.Description);
                    //}

                }
            }

            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            //await _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
