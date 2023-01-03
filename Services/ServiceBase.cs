using RoleBaseIdentiyProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RoleBaseIdentiyProject.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private ApplicationDbContext context;
        private IDbSet<T> dbEntity;

        public ServiceBase()
        {
            this.context = new ApplicationDbContext();
            this.dbEntity = context.Set<T>();
        }

        public T Create(T objectToCreate)
        {
            dbEntity.Add(objectToCreate);
            Save();
            return objectToCreate;
        }

        public void Delete(int id)
        {
            T model = dbEntity.Find(id);
            dbEntity.Remove(model);
        }

        public IEnumerable<T> GetAll()
        {
            return dbEntity.ToList();
        }

        public T GetById(int id)
        {
            return dbEntity.Find(id);
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
            context.SaveChanges();
        }

        public void Update(T objectToUpdate)
        {
            context.Entry(objectToUpdate).State= EntityState.Modified;
        }
    }
}