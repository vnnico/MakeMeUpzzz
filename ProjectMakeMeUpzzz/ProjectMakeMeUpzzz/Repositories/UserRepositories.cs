﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Repositories
{
    public class UserRepositories
    {
        private static readonly DatabaseEntities1 db = new DatabaseEntities1();

        public static User GetLastUser()
        {
            return db.Users.ToList().LastOrDefault();
        }

        public static List<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public static User GetUserById(int id)
        {
            return db.Users.Find(id);
        }

        public static User GetUserByUsername(string username)
        {
            return db.Users.Where(u => u.Username == username).FirstOrDefault();
        }

        public static int InsertUser(User user)
        {
            db.Users.Add(user);
            return db.SaveChanges();
        }

        public static int UpdateUser(User user)
        {
            User oldUser = GetUserById(user.UserID);
            oldUser.Username = user.Username;
            oldUser.UserEmail = user.UserEmail;
            oldUser.UserGender = user.UserGender;
            oldUser.UserPassword = user.UserPassword;
            return db.SaveChanges();
        }
    }
}