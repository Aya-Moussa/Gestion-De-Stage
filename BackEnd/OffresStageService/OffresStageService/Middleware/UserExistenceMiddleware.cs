using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using DOMAIN.Interface;
using System;
using Microsoft.Extensions.Logging;

namespace API.Middleware
{
    public class UserExistenceMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserService _userService;

        public UserExistenceMiddleware(RequestDelegate next, IUserService userService)
        {
            _next = next;
            _userService = userService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"User ID from token: /////////////////////////////////////////////////////////////");
            // Debug: print all claims to the console
            foreach (var claim in context.User.Claims)
            {
                Console.WriteLine($"Claim Type: {claim.Type}, Value: {claim.Value}");
            }
            var path = context.Request.Path.Value;

            if (path.StartsWith("/swagger") || path.StartsWith("/api/Auth"))
            {
                await _next(context);
                return;
            }
            
            

            if (context.User.Identity.IsAuthenticated)
            {
                //var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userId = context.User.FindFirst("userId")?.Value;

                Console.WriteLine($"User ID from token: {userId}");

                if (string.IsNullOrWhiteSpace(userId) || !await _userService.UserExistsAsync(userId))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("User does not exist.");
                    return;
                }
            }

            await _next(context);
        }
    }


}