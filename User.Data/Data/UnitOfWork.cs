using Main_Project.Interfaces;
using Main_Project.Models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Main_Project.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AplContext aplContext;

        public UnitOfWork(AplContext aplContext, IStudentrep student)
        {
            this.aplContext = aplContext;

            Students = student;


        }
        public IStudentrep Students { get; }
        public async Task SaveChangesAsync()
        {
            await aplContext.SaveChangesAsync();
        }

    }
}
