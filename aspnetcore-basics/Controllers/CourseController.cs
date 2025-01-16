using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcore_basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_basics.Controllers
{
    public class CourseController:Controller
    {
        public IActionResult Index(){
            return View();
        }
        public IActionResult List(){

            var courses = Repository.Courses;

            return View("CourseList",courses);
        }
        public IActionResult Details(int id){

            var course = Repository.GetById(id);


            return View(course);
        }
    }
}