using Bot.Data.Context;
using Bot.Data.Models.ContextModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Data.Repos
{
    public class UserRolesRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRolesRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ScriptUserRole> GetUserRolesAsync(int userId)
        {
            return (await _dbContext.ScriptUserRoles.FirstOrDefaultAsync(u => u.Id == userId))!;
        }

    }
}
