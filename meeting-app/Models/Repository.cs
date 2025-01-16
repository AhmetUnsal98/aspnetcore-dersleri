using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meeting_app.Models
{
    public static class Repository
    {
        private static  List<UserInfo> _users = new();

        static Repository(){
            _users.Add(new UserInfo() {Id=1,Name ="Ali",Email="abc@mail.com", Phone="11111", WillAttend=true}
            );
            _users.Add(new UserInfo() {Id=2,Name ="Veli",Email="abc@mail.com", Phone="2222", WillAttend=true}
            );
            _users.Add(new UserInfo() {Id=3,Name ="Mehmet",Email="abc@mail.com", Phone="3333", WillAttend=false}
            );

        }
        public static List<UserInfo> Users  {
            get {
                return _users;
            }
        }

        public static void CreateUser(UserInfo user){
            user.Id = _users.Count() + 1;
            _users.Add(user);
        }
        public static UserInfo? GetById(int id) {
            return _users.FirstOrDefault(i=> i.Id == id);
        }

    }
}