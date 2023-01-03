using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBaseIdentiyProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentClass { get; set; }
        public bool? IsActive { get; set; }
        
    }
}