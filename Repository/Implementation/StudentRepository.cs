using RoleBaseIdentiyProject.Models;
using RoleBaseIdentiyProject.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBaseIdentiyProject.Repository.Implementation
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _db;

        public StudentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}