using RoleBaseIdentiyProject.Models;
using RoleBaseIdentiyProject.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBaseIdentiyProject.Controllers
{
    public class StudentController : Controller
    {
        //private IServiceBase<Student> serviceBase;
        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        // GET: Student
        public ActionResult Index()
        {
            var studentList = studentRepository.GetAll().ToList();
            return View(studentList);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var student = studentRepository.GetById(id);
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
                studentRepository.Create(studentCollection);
                studentRepository.Save();
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
            var student = studentRepository.GetById(id);
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student studentCollection)
        {
            try
            {
                // TODO: Add update logic here
                studentRepository.Update(studentCollection);
                studentRepository.Save();
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
            var student = studentRepository.GetById(id);
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Student studentCollection)
        {
            try
            {
                // TODO: Add delete logic here
                studentRepository.Delete(id);
                studentRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
