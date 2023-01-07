using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RoleBaseIdentiyProject.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Create(T objectToCreate);
        void Update(T objectToUpdate);
        void Delete(int id);
        bool Inactivate(long id, DateTime? inactiveDate);
        bool IsContinued(long id);
        void Save();
    }
}
