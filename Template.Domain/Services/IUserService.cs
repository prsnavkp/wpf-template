using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Models;
using Template.Domain.Services.AuthenticationServices;

namespace Template.Domain.Services
{
    public interface IUserService : IDataService<User>
    {
      Task<User> GetByUsername(string username);
      Task<User> GetByEmail(string email);
    }
}
