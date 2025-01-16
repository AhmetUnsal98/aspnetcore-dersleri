using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_basics.Models
{
    public class Repository
    {
        private static readonly List<Course> _courses= new List<Course>(); 

        static Repository(){
            _courses  =new List<Course>()
            {
                new Course() {Id=1,Title="React",Description="Açıklama react" , Image="1.png"},
                           new Course() {Id=2,Title="Asp",Description="Açıklama asp" , Image="2.png"},
                                       new Course() {Id=3,Title="Angular",Description="Açıklama angular" , Image="3.png"},
            };
        }

    public static List<Course> Courses {
        get {
            return _courses;
        }
    }


    public static Course? GetById(int id)
    {
        return _courses.FirstOrDefault(c => c.Id == id);
    }

    }
}