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
    public class RolesRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public RolesRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ScriptRole>> GetAllRoles()
        {
            return await _dbContext.ScriptRoles.ToListAsync();
        }

        public async Task<ScriptRole> GetRoleById(int id)
        {
            return (await _dbContext.ScriptRoles.Where(r => r.Id == id).FirstOrDefaultAsync())!;
        }

        public async Task<ScriptRole> Add(ScriptRole role)
        {
            await _dbContext.ScriptRoles.AddAsync(role);
            await _dbContext.SaveChangesAsync();
            return role;
        }

        public async Task Delete(int id)
        {
            var role = await _dbContext.ScriptRoles.Where(r => r.Id == id).FirstOrDefaultAsync();
            if (role != null)
            {
                _dbContext.ScriptRoles.Remove(role);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
