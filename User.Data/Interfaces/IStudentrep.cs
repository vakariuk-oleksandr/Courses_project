using Main_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main_Project.Interfaces
{
    public interface IStudentrep : IGenrep<User>
    {
        public Task<IEnumerable<User>> AllS();
        public Task<User> Login(string email, string password);

        public Task<User> GetByEmail(string email);
        Task<User> GetById(string studentID);
        Task<bool> Delete(User studentID);
        Task<bool> DeleteById(string id);
    }
}
