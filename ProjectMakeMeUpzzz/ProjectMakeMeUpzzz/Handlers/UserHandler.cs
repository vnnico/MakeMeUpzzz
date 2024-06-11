﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Factory;
using ProjectMakeMeUpzzz.Helpers;
using ProjectMakeMeUpzzz.Models;
using ProjectMakeMeUpzzz.Repositories;

namespace ProjectMakeMeUpzzz.Handlers
{
    public class UserHandler
    {
        public static Response<User> UpdateUserData(int userId, string userName, string userEmail, DateTime userDOB, string userGender)
        {
            User user = UserRepositories.GetUserById(userId);
            user.Username = userName;
            user.UserEmail = userEmail;
            user.UserDOB = userDOB;
            user.UserGender = userGender;
            if (UserRepositories.UpdateUser(user) == 0)
            {
                return new Response<User>
                {
                    Message = "Failed to update user",
                    IsSuccess = false,
                    Payload = null
                };
            }
            return new Response<User>
            {
                Message = "Successfuly update user",
                IsSuccess = true,
                Payload = user
            };
        }

        public static Response<User> UpdateUserPassword(int userId, string newPassword)
        {
            User user = UserRepositories.GetUserById(userId);
            user.UserPassword = newPassword;
            if (UserRepositories.UpdateUser(user) == 0)
            {
                return new Response<User>
                {
                    Message = "Failed to update user",
                    IsSuccess = false,
                    Payload = null
                };
            }
            return new Response<User>
            {
                Message = "Successfuly update user",
                IsSuccess = true,
                Payload = user
            };
        }
        public static int GenerateID()
        {
            User user = UserRepositories.GetLastUser();

            if (user == null)
            {
                return 1;
            }
            return user.UserID + 1;
        }

        public static Response<List<User>> GetAllUsers()
        {
            List<User> users = UserRepositories.GetAllUsers();
            if (users.Count > 0)
            {
                return new Response<List<User>>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = users
                };
            }
            return new Response<List<User>>
            {
                Message = "No users found",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<User> GetUserById(int id)
        {
            User user = UserRepositories.GetUserById(id);
            if (user != null)
            {
                return new Response<User>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = user
                };
            }
            return new Response<User>
            {
                Message = "User not found",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<User> Login(string username, string password)
        {
            User user = UserRepositories.GetUserByUsername(username);
            if (user != null && user.UserPassword == password)
            {
                return new Response<User>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = user
                };
            }
            return new Response<User>
            {
                Message = "Invalid user credentials",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<User> Register(string username, string email, DateTime dob, string gender, string password)
        {
            if (UserRepositories.GetUserByUsername(username) != null)
            {
                return new Response<User>
                {
                    Message = "User already exist",
                    IsSuccess = false,
                    Payload = null
                };
            }

            User user = UserFactories.CreateUser(GenerateID(), username, email, dob, gender, password);

            if (UserRepositories.InsertUser(user) == 0)
            {
                return new Response<User>
                {
                    Message = "Something went wrong",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<User>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = user
            };
        }
    }
}