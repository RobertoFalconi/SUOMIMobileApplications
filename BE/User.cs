﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string FacebookID { get; set; }
        public static User CurrentUser { get; set; }

        public User()
        {

        }

        public User(String nickname, String password)
        {
            this.Nickname = nickname;
            this.Password = password;
        }

        public User(int id, String nickname, String password) {
            this.Id = id;
            this.Nickname = nickname;
            this.Password = password;
        }

        public User(String nickname, String password, String facebookID)
        {
            this.Nickname = nickname;
            this.Password = password;
            this.FacebookID = facebookID;
        }

        public User(int id, String nickname, String password, String facebookID)
        {
            this.Id = id;
            this.Nickname = nickname;
            this.Password = password;
            this.FacebookID = facebookID;
        }
    }
}
