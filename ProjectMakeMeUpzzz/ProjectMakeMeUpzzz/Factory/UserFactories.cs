using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Factory
{
    public class UserFactories

    {
        public static User Create(int userId, string username, string userEmail, DateTime userDOB, string userGender, string userRole,string userPassword)
        {

            User user = new User();
            user.UserID = userId;
            user.Username = username;
            user.UserEmail = userEmail;
            user.UserDOB = userDOB;
            user.UserGender = userGender;
            user.UserRole = userRole;
            user.UserPassword = userPassword;
            return user;
          
        }

   
    }
}