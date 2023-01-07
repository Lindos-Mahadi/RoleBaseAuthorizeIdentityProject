using RoleBaseIdentiyProject.Models;
using RoleBaseIdentiyProject.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RoleBaseIdentiyProject.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> _dbEntity;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbEntity = _context.Set<T>();
        }

        public T Create(T objectToCreate)
        {
            _dbEntity.Add(objectToCreate);
            Save();
            return objectToCreate;
        }

        public void Delete(int id)
        {
            T model = _dbEntity.Find(id);
            _dbEntity.Remove(model);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbEntity.ToList();
        }

        public T GetById(int id)
        {
            return _dbEntity.Find(id);
        }

        public bool Inactivate(long id, DateTime? inactiveDate)
        {
            throw new NotImplementedException();
        }

        public bool IsContinued(long id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T objectToUpdate)
        {
            _context.Entry(objectToUpdate).State = EntityState.Modified;
        }
    }
}
