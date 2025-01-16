using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using meeting_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace meeting_app.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var userCount = Repository.Users.Count();

            var meetingInfo = new MeetingInfo(){
                Id=1,
                Location="İstanbul,Abc Kongre Merkez",
                Date = new DateTime(2024,01,20,12,0,0),
                NumberOfPeople = userCount,

            };

            return  View(model: meetingInfo);
        }


    }
}