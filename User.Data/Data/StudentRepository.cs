using Main_Project.Models;
using Main_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Main_Project.Data
{
    public class StudentRepository : Basic<User>, IStudentrep
    {
        public UserManager<User> UserManager { get; set; }
        private readonly AplContext _context;
        public StudentRepository(AplContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> AllS()
        {
            var studts = await _context.Users.ToListAsync();
            return studts;
        }


        public async Task<bool> Delete(User entity)
        {
            var result = await UserManager.DeleteAsync(entity);
            await _context.SaveChangesAsync();
            return result.Succeeded;
        }

        public async Task<bool> DeleteById(string id)
        {
            var user = await _context.Users.FindAsync(id);
            return await this.Delete(user);
        }
        public Task<User> DeleteById(User id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByEmail(string email)
        {
            var users = await _context.Users.ToListAsync();
            return users.Where(u => u.Email == email).FirstOrDefault();
        }

        public async Task<User> Login(string email, string password)
        {
            var users = await _context.Users.ToListAsync();
            var user = users.Where(u => u.Email == email).FirstOrDefault();
            if (user != null)
                return user.PasswordHash == password ? user : null;
            else return null;

        }
    }
}
