using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBaseIdentiyProject.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Student { get; }

        void Save();
    }
}
