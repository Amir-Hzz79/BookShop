using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create([Bind("Username,Email,Password,ConfirmPassword") RoleViewModel )
        //{
        //    return View();
        //}
    }
}
