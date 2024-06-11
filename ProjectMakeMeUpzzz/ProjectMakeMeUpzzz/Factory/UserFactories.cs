using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Factory
{
    public class UserFactories
    {
        public static User CreateUser(int userId, string username, string userEmail, DateTime userDOB, string userGender, string userRole, string userPassword)
        {
            return new User
            {
                UserID = userId,
                Username = username,
                UserEmail = userEmail,
                UserDOB = userDOB,
                UserGender = userGender,
                UserRole = userRole,
            };
        }

        internal static User CreateUser(int v, string username, string email, DateTime dob, string gender, string password)
        {
            throw new NotImplementedException();
        }
    }
}