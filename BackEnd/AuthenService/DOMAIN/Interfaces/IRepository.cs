using DOMAIN.DTO;
using DOMAIN.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Interfaces
{
    public interface IRepository
    {
        Task<Utilisateur> GetByEmailAsync(string email, string role);
        Task AddUserAsync(Utilisateur user);
        Task UpdateUserAsync(Utilisateur user);
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string inputPassword);
        string GenerateToken(Utilisateur user);
        Task SendEmailAsync(string toEmail, string subject, string body);
        Task AddEncadrant(Encadrant encadrant);
        Task AddRHAsync(RH rh);
        Task AddStagiaireAsync(Stagiaire stagiaire);

    }
}
