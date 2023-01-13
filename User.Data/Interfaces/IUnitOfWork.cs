using Main_Project.Interfaces;
using Main_Project.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Main_Project.Interfaces
{
    public interface IUnitOfWork
    {
        IStudentrep Students { get; }
        Task SaveChangesAsync();
    }
}
