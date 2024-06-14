using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Handlers;
using ProjectMakeMeUpzzz.Helpers;
using ProjectMakeMeUpzzz.Models;
using ProjectMakeMeUpzzz.Repositories;

namespace ProjectMakeMeUpzzz.Controllers
{
    public class MakeupController
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

            if (!int.TryParse(id, out int idValue))
            {
                ErrorList.Add("ID must be a valid number");
                return;
            }

            if (MakeUpBrandRepositories.GetMakeupBrandById(idValue) == null)
            {
                ErrorList.Add("Brand ID cannot be found");
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

        private static void ValidatePrice(string price, List<string> ErrorList)
        {
            if (string.IsNullOrEmpty(price))
            {
                ErrorList.Add("Price cannot be empty or null");
                return;
            }

            if (int.TryParse(price, out int priceValue))
            {
                if (priceValue <= 0)
                {
                    ErrorList.Add("Price must be greater than 0");
                }
            }
            else
            {
                ErrorList.Add("Price must be a number");
            }
        }

        private static void ValidateWeight(string weight, List<string> ErrorList)
        {
            if (string.IsNullOrEmpty(weight))
            {
                ErrorList.Add("Weight cannot be empty or null");
                return;
            }

            if (int.TryParse(weight, out int weightValue))
            {
                if (weightValue > 1500)
                {
                    ErrorList.Add("Weight cannot be greater than 1500");
                }
            }
            else
            {
                ErrorList.Add("Weight must be a number");
            }
        }

        private static void ValidateTypeId(string typeId, List<string> ErrorList)
        {
            if (string.IsNullOrEmpty(typeId))
            {
                ErrorList.Add("Type ID cannot be empty or null");
                return;
            }

            if (!int.TryParse(typeId, out int typeIdValue))
            {
                ErrorList.Add("Type ID must be a valid number");
                return;
            }

            if (MakeUpTypeRepositories.GetMakeupTypeById(typeIdValue) == null)
            {
                ErrorList.Add("Type ID cannot be found");
            }
        }

        private static void ValidateBrandId(string brandId, List<string> ErrorList)
        {
            if (string.IsNullOrEmpty(brandId))
            {
                ErrorList.Add("Brand ID cannot be empty or null");
                return;
            }

            if (!int.TryParse(brandId, out int brandIdValue))
            {
                ErrorList.Add("Brand ID must be a valid number");
                return;
            }

            if (MakeUpBrandRepositories.GetMakeupBrandById(brandIdValue) == null)
            {
                ErrorList.Add("Brand ID cannot be found");
            }
        }

        public static Response<Makeup> GetMakeupById(int id)
        {
            return MakeupHandler.GetMakeupById(id);
        }

        public static Response<List<Makeup>> GetAllMakeups()
        {
            return MakeupHandler.GetAllMakeups();
        }

        public static Response<Makeup> InsertMakeup(string name, string price, string weight, string typeId, string brandId)
        {
            List<string> ErrorList = new List<string>();
            ValidateName(name, ErrorList);
            ValidatePrice(price, ErrorList);
            ValidateWeight(weight, ErrorList);
            ValidateTypeId(typeId, ErrorList);
            ValidateBrandId(brandId, ErrorList);

            if (ErrorList.Any())
            {
                return CreateErrorResponse<Makeup>(ErrorList);
            }

            return MakeupHandler.InsertMakeup(name, Convert.ToInt32(price), Convert.ToInt32(weight), Convert.ToInt32(typeId), Convert.ToInt32(brandId));
        }

        public static Response<Makeup> UpdateMakeup(string id, string name, string price, string weight, string typeId, string brandId)
        {
            List<string> ErrorList = new List<string>();
            ValidateId(id, ErrorList);
            ValidateName(name, ErrorList);
            ValidatePrice(price, ErrorList);
            ValidateWeight(weight, ErrorList);
            ValidateTypeId(typeId, ErrorList);
            ValidateBrandId(brandId, ErrorList);

            if (ErrorList.Any())
            {
                return CreateErrorResponse<Makeup>(ErrorList);
            }

            return MakeupHandler.UpdateMakeup(Convert.ToInt32(id), name, Convert.ToInt32(price), Convert.ToInt32(weight), Convert.ToInt32(typeId), Convert.ToInt32(brandId));
        }

        public static Response<Makeup> DeleteMakeup(int id)
        {
            List<string> ErrorList = new List<string>();
            ValidateId(id.ToString(), ErrorList);

            if (ErrorList.Any())
            {
                return CreateErrorResponse<Makeup>(ErrorList);
            }

            return MakeupHandler.DeleteMakeup(id);
        }
    }
}
