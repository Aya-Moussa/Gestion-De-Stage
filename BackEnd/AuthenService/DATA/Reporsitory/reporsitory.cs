using DATA.ContextDb;
using DOMAIN.DTO;
using DOMAIN.Interfaces;
using DOMAIN.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Repository
{
    public class repository : IRepository

    {
        private readonly AuthenContext _context;
        private readonly IConfiguration _config;

        public repository(AuthenContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public async Task AddUserAsync(Utilisateur user)
        {
            await _context.Utilisateurs.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task AddStagiaireAsync(Stagiaire stagiaire)
        {
            await _context.stagiaires.AddAsync(stagiaire);
            await _context.SaveChangesAsync();
        }
        public async Task AddRHAsync(RH rh)
        {
            await _context.RHs.AddAsync(rh);
            await _context.SaveChangesAsync();
        }
        public async Task AddEncadrant(Encadrant en)
        {
            await _context.encadrants.AddAsync(en);
            await _context.SaveChangesAsync();
        }
        //public Task<Utilisateur> GetByEmailAsync(string email)
        //{
        //    throw new NotImplementedException();
        //}

        public string HashPassword(string password)
        {
            {
                return BCrypt.Net.BCrypt.HashPassword(password);
            }
        }

        public Task SendEmailAsync(string toEmail, string subject, string body)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(LoginDTO user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(Utilisateur user)
        {
            throw new NotImplementedException();
        }

        public bool VerifyPassword(string hashedPassword, string inputPassword)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
        }

        Task IRepository.AddUserAsync(Utilisateur user)
        {
            return AddUserAsync(user);
        }

        string IRepository.GenerateToken(Utilisateur user)
        {
            var secretKey = _config["Jwt:Key"];
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                //new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                new Claim("userId", user.Id.ToString())  // custom claim type for user ID
  
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<Utilisateur> GetByEmailAsync(string email, string role)
        {
           
                // Search in all tables
                var user = await _context.Utilisateurs.FirstOrDefaultAsync(u => u.Email == email);
                if (user != null) return user;

                user = await _context.RHs.FirstOrDefaultAsync(u => u.Email == email);
                if (user != null) return user;

                user = await _context.stagiaires.FirstOrDefaultAsync(u => u.Email == email);
                if (user != null) return user;

                user = await _context.encadrants.FirstOrDefaultAsync(u => u.Email == email);
                return user;
            

            // Search by role explicitly
            //switch (role)
            //{
            //    case "RH":
            //        return await _context.RHs.FirstOrDefaultAsync(u => u.Email == email);
            //    case "Stagiaire":
            //        return await _context.stagiaires.FirstOrDefaultAsync(u => u.Email == email);
            //    case "Encadrant":
            //        return await _context.encadrants.FirstOrDefaultAsync(u => u.Email == email);
            //    default:
            //        return null;
            //}
        }





        Task IRepository.SendEmailAsync(string toEmail, string subject, string body)
        {
            throw new NotImplementedException();
        }

        Task IRepository.UpdateUserAsync(Utilisateur user)
        {
            throw new NotImplementedException();
        }
        public async Task<Utilisateur> GetUserByIdAsync(Guid id)
        {
            // Try to find the user by ID in all derived tables
            var user = await _context.Utilisateurs.FindAsync(id);
            if (user != null) return user;

            user = await _context.RHs.FindAsync(id);
            if (user != null) return user;

            user = await _context.stagiaires.FindAsync(id);
            if (user != null) return user;

            user = await _context.encadrants.FindAsync(id);
            return user;
        }

    }
}

