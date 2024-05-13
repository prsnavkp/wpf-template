using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Models;
using Template.Domain.Services;
using Template.EntityFramework.Services.Common;

namespace Template.EntityFramework.Services
{
    public class UserDataService : IUserService
    {
        private readonly TemplateDbContextFactory _contextFactory;
        private readonly NonQueryDataService<User> _nonQueryDataService;

        public UserDataService(TemplateDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<User>(contextFactory);
        }

        public async Task<User> Create(User entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByEmail(string email)
        {
            using (TemplateDbContext context = _contextFactory.CreateDbContext())
            {
                User entity = await context.Set<User>().FirstOrDefaultAsync((e) => e.Email == email);
                return entity;
            }
        }

        public async Task<User> GetByUsername(string username)
        {
            using (TemplateDbContext context = _contextFactory.CreateDbContext())
            {
                User entity = await context.Set<User>().FirstOrDefaultAsync((e) => e.Username == username);
                return entity;
            }
        }

        public async Task<User> Update(int id, User entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}