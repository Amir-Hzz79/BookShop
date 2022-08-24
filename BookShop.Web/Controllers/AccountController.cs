using BookShop.DataLayer.Models;
using BookShop.DataLayer.Services;
using BookShop.DataLayer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace BookShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        //private RegisterViewModel registerUser;
        //private LoginViewModel loginUser;

        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Username,Password,RememberMe")] LoginViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                var result=await _signInManager.PasswordSignInAsync(loginUser.Username, loginUser.Password, loginUser.RememberMe, false);

                if (result.Succeeded)
                {
                    return Redirect("/");
                }

                ModelState.AddModelError("","User not found!!");
            }

            return View(loginUser);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Username,Email,Password,ConfirmPassword")] RegisterViewModel registerUser)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = registerUser.Username,
                    Email = registerUser.Email
                };

                var result = await _userManager.CreateAsync(user, registerUser.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return Redirect("/");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                   
                }
            }

            return View(registerUser);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
