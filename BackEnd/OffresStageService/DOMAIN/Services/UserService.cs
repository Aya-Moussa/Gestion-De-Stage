using DOMAIN.Interface;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DOMAIN.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> UserExistsAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return false;

            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:9001/api/User/{userId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }
    }
}