using LibraryManagementApp.Data;
using LibraryManagementApp.Model;
using LibraryManagementApp.Repositories.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryManagementApp.Repositories.Implementation
{
    public class AppUserRepository(AppDbContext context, IConfiguration configuration) : IAppUserRepository
    {
        private readonly AppDbContext _context=context;
        private readonly IConfiguration _configuration = configuration;       

        public async Task<string> Login(AppUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User object cannot be null.");
            }
            var dbUser = _context.Users.SingleOrDefault(u => u.Email == user.Email);

            if (dbUser == null || dbUser.Password != user.Password)
                throw new InvalidOperationException("Invalid credentials. Please check your email and password.");
           return GenerateJwtToken(user);           
        }

        public async Task<string> Register(AppUser user)
        {           
            if (_context.Users.Any(u => u.Email == user.Email))
                return "Email already registered!";
         
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return "User registered successfully!";
        }

        public string GenerateJwtToken(AppUser user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpireMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
