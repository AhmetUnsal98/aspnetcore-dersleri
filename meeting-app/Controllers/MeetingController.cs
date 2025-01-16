using meeting_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace meeting_app.Controllers
{
  
    public class MeetingController : Controller
    {
        [HttpGet("Meeting/Apply")]
         public IActionResult Apply()
        {
            return  View();
        }


        [HttpPost("Meeting/Apply")]
            public IActionResult Apply(UserInfo model)
        {

            if(ModelState.IsValid) {
            Repository.CreateUser(model);
            ViewBag.userCount = Repository.Users.Where(i => i.WillAttend == true ).Count(); 
            return View("Thanks",model); 
            }
            else {
            return View(model);
            }
   
        }

            public IActionResult List()
        {  
            return  View(Repository.Users);
        }
        

        public IActionResult Details(int id) {
            ViewBag.Title = "Basvuru Detayi";
            return View(Repository.GetById(id));
        }
    }
}