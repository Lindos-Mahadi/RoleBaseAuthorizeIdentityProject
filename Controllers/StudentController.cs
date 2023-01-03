using RoleBaseIdentiyProject.Models;
using RoleBaseIdentiyProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBaseIdentiyProject.Controllers
{
    public class StudentController : Controller
    {
        private IServiceBase<Student> serviceBase;

        public StudentController()
        {
            this.serviceBase = new ServiceBase<Student>();
        }

        // GET: Student
        public ActionResult Index()
        {
            var studentList = serviceBase.GetAll().ToList();
            return View(studentList);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var student = serviceBase.GetById(id);
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student studentCollection)
        {
            try
            {
                // TODO: Add insert logic here
                serviceBase.Create(studentCollection);
                serviceBase.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var student = serviceBase.GetById(id);
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student studentCollection)
        {
            try
            {
                // TODO: Add update logic here
                serviceBase.Update(studentCollection);
                serviceBase.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var student = serviceBase.GetById(id);
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Student studentCollection)
        {
            try
            {
                // TODO: Add delete logic here
                serviceBase.Delete(id);
                serviceBase.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
