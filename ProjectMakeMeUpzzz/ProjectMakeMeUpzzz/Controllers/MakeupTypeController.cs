using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Handlers;
using ProjectMakeMeUpzzz.Helpers;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Controllers
{
    public class MakeupTypeController
    {
        private static Response<T> CreateErrorResponse<T>(List<string> ErrorList)
        {
            string errorMessage = string.Join(" | ", ErrorList);
            return new Response<T>
            {
                Message = errorMessage,
                IsSuccess = false,
                Payload = default
            };
        }

        private static void ValidateId(string id, List<string> ErrorList)
        {
            if (string.IsNullOrEmpty(id))
            {
                ErrorList.Add("ID cannot be empty or null");
                return;
            }

            if (!int.TryParse(id, out _))
            {
                ErrorList.Add("ID must be a valid number");
            }
        }

        private static void ValidateName(string name, List<string> ErrorList)
        {
            if (string.IsNullOrEmpty(name))
            {
                ErrorList.Add("Name cannot be empty or null");
            }
            else if (name.Length < 1 || name.Length > 99)
            {
                ErrorList.Add("Name length must be between 1 and 99 characters");
            }
        }

        private static Response<string> ValidateMakeupTypeRequest(string name)
        {
            List<string> ErrorList = new List<string>();
            ValidateName(name, ErrorList);

            if (ErrorList.Any())
            {
                return CreateErrorResponse<string>(ErrorList);
            }

            return new Response<string>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = null
            };
        }

        private static Response<string> ValidateUpdateMakeupTypeRequest(string id, string name)
        {
            List<string> ErrorList = new List<string>();
            ValidateId(id, ErrorList);
            ValidateName(name, ErrorList);

            if (ErrorList.Any())
            {
                return CreateErrorResponse<string>(ErrorList);
            }

            return new Response<string>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = null
            };
        }

        public static Response<MakeupType> GetMakeupTypeById(int id)
        {
            return MakeupTypeHandler.GetMakeupTypeById(id);
        }

        public static Response<List<MakeupType>> GetAllMakeupTypes()
        {
            return MakeupTypeHandler.GetAllMakeupTypes();
        }

        public static Response<MakeupType> InsertMakeupType(string name)
        {
            Response<string> response = ValidateMakeupTypeRequest(name);

            if (!response.IsSuccess)
            {
                return new Response<MakeupType>
                {
                    Message = response.Payload,
                    IsSuccess = false,
                    Payload = null
                };
            }

            return MakeupTypeHandler.InsertMakeupType(name);
        }

        public static Response<MakeupType> UpdateMakeupType(string id, string name)
        {
            Response<string> response = ValidateUpdateMakeupTypeRequest(id, name);

            if (!response.IsSuccess)
            {
                return new Response<MakeupType>
                {
                    Message = response.Payload,
                    IsSuccess = false,
                    Payload = null
                };
            }

            return MakeupTypeHandler.UpdateMakeupType(Convert.ToInt32(id), name);
        }

        public static Response<MakeupType> RemoveMakeupType(string id)
        {
            List<string> ErrorList = new List<string>();
            ValidateId(id, ErrorList);

            if (ErrorList.Any())
            {
                return CreateErrorResponse<MakeupType>(ErrorList);
            }

            return MakeupTypeHandler.RemoveMakeupType(Convert.ToInt32(id));
        }
    }
}
