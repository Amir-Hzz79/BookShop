using BookShop.DataLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BookShop.DataLayer.Services
{
    public class JWTService : IJWTService
    {
        private readonly BookShopContext _context;
        private readonly IConfiguration _configuration;

        public JWTService(BookShopContext context , IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //public Token Authenticate(User user)
        //{
        //    bool isUserExist = _context.Users.Any(u => u.Username == user.Username && u.Password == user.Password);
        //    if (!isUserExist)
        //        return null;


        //    //Generate JWT
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, user.Id.ToString()) }),
        //        Expires = DateTime.UtcNow.AddMinutes(10),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return new Token { AccessToken = tokenHandler.WriteToken(token) };
        //}

		public Token GenerateToken(string userId)
		{
			try
			{
				var tokenHandler = new JwtSecurityTokenHandler();
				var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, userId) }),
					Expires = DateTime.Now.AddMinutes(1),
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
				};
				var token = tokenHandler.CreateToken(tokenDescriptor);
				var refreshToken = GenerateRefreshToken();
				return new Token { AccessToken = tokenHandler.WriteToken(token), RefreshToken = refreshToken };
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public string GenerateRefreshToken()
		{
			var randomNumber = new byte[32];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(randomNumber);
				return Convert.ToBase64String(randomNumber);
			}
		}

		public ClaimsPrincipal GetClaimsFromExpiredToken(string accessToken)
		{
			var Key = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);

			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = false,
				ValidateAudience = false,
				ValidateLifetime = false,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Key),
				ClockSkew = TimeSpan.Zero
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var claims = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out SecurityToken securityToken);
			JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
			if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
			{
				throw new SecurityTokenException("Invalid token");
			}


			return claims;
		}
	}
}
