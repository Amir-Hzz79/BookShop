using BookShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataLayer.Services
{
    public interface IJWTService 
    {
        //Token Authenticate(User user);
        public Token GenerateToken(string userId);
        public string GenerateRefreshToken();
        public ClaimsPrincipal GetClaimsFromExpiredToken(string accessToken);
    }
}
