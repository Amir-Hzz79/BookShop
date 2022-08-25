using BookShop.DataLayer.Models;
using BookShop.DataLayer.Services;
using BookShop.DataLayer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookShop.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {

        private readonly IJWTService _jWTManager;
        private readonly IUserService _userService;

        public AccountApiController( IJWTService jWTManager , IUserService userService)
        {
            _jWTManager = jWTManager;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("GenerateToken")]
        public async Task<IActionResult> Authenticate([FromHeader]User user)
        {
            if (ModelState.IsValid)
            {
                //user.Password = user.Password.GetHashCode().ToString();

                var users = _userService.GetByUserPass(user.Username,user.Password).ToList();
                if (users.Count()==0)
                {
                    return Unauthorized("Incorrect username or password!");
                }
                
                var token = _jWTManager.GenerateToken(users[0].Id.ToString());

                if (token == null)
                {
                    return Unauthorized("Invalid Attempt!");
                }

                //// saving refresh token to the db
                //RefreshToken refreshToken = new RefreshToken
                //{
                //    RefreshTokenString = token.RefreshToken,
                //    UserId = user.Id.ToString()
                //};

                //_userService.InsertUserRefreshToken(refreshToken);
                //_userService.Save();

                return Ok(token.AccessToken);
            }
            return BadRequest("User bad structure");
        }

        //[HttpPost]
        //[Route("refresh")]
        //public IActionResult Refresh(Token token)
        //{
        //    ClaimsPrincipal claims = _jWTManager.GetClaimsFromExpiredToken(token.AccessToken);
        //    string userId = claims.Identity?.Name;

        //    //retrieve the saved refresh token from database
        //    RefreshToken savedRefreshToken = _userService.GetUserRefreshToken(userId, token.RefreshToken);

        //    if (savedRefreshToken.RefreshTokenString != token.RefreshToken)
        //    {
        //        return Unauthorized("Invalid attempt!");
        //    }

        //    Token newJwtToken = _jWTManager.GenerateToken(userId);

        //    if (newJwtToken == null)
        //    {
        //        return Unauthorized("Invalid attempt!");
        //    }

        //    // saving refresh token to the db
        //    RefreshToken refreshToken = new RefreshToken
        //    {
        //        RefreshTokenString = newJwtToken.RefreshToken,
        //        UserId = userId
        //    };

        //    //Update refresh token in db
        //    //_userService.DeleteUserRefreshToken(userId, token.RefreshToken);
        //    _userService.UpdateUserRefreshToken(refreshToken);
        //    _userService.Save();

        //    return Ok(newJwtToken.AccessToken);
        //}


        //[HttpPost]
        //[Route("Login")]
        //public async Task<ActionResult<User>> Login([FromForm] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //Generate token
        //        var token = _jWTManager.Authenticate(user);
        //        if (token == null)
        //            return BadRequest("user did not authenticate!!");

        //        var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, true, false);

        //        if (result.Succeeded)
        //        {
        //            //User user = _userService.Get(loginUser.Id);
        //            return Ok(token);
        //        }

        //        ModelState.AddModelError("", "User not found!!");
        //    }

        //    return BadRequest("User not found");
        //}

        //[HttpPost]
        //[Route("Register")]
        //public async Task<ActionResult<User>> Register([FromForm] User registerUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new User()
        //        {
        //            Username = registerUser.Username,
        //            Email = registerUser.Email
        //        };

        //        var result = await _userManager.CreateAsync(user, registerUser.Password);

        //        if (result.Succeeded)
        //        {
        //            await _signInManager.SignInAsync(user, false);
        //            var token = _jWTManager.Authenticate(registerUser);
        //            return Ok(token);
        //        }
        //        else
        //        {
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error.Description);
        //            }

        //        }
        //    }
        //    return BadRequest("Register Failed!!");
        //}

        //[Route("Logout")]
        //public async Task<ActionResult<User>> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return Ok("Logout");
        //}
    }
}
