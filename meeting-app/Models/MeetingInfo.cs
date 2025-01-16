using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meeting_app.Models
{
    public class MeetingInfo
    {
        public int Id {get;set;}
        
        public string? Location {get;set;}

        public DateTime Date  {get;set;}

        public int NumberOfPeople {get;set;}
    }
}