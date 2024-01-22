using Autorization.Exceptions;
using Autorization.Interfaces;
using Autorization.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NarkoCenter.Service.Abstractions.DataAccess;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Autorization.Services
{
    public class AuthService : IAuthService
    {
        private readonly IApplicationDbContext _context;

        public AuthService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async ValueTask<string> GenerateToken(Login login)
        {
            var admins = await _context.Admins.AsNoTracking().ToListAsync();

            var admin = admins.FirstOrDefault(x => x.Email == login.Email && x.PasswordHash == PasswordHash.ComputeSHA512HashFromString(login.Password));

            if (admin == null)
                throw new UserNotFound();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mana-shu-security-key"));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, admin.Email),
                new Claim(ClaimTypes.Role, admin.Role.ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}