using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Interface
{
    public interface IUserService
    {
        Task <bool> UserExistsAsync(string userId);
    }
}
