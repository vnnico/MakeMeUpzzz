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
    public class MakeupBrandController
    {
        private static Response<T> CreateErrorResponse<T>(List<string> ErrorList)
        {
            string errorMessage = string.Join(" | ", ErrorList);
            return new Response<T>
            {
                Message = errorMessage,
                IsSuccess = false,
                Payload = default,
            };
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

        private static void ValidateRating(string rating, List<string> ErrorList)
        {
            if (string.IsNullOrEmpty(rating))
            {
                ErrorList.Add("Rating cannot be empty or null");
            }
            else if (int.TryParse(rating, out int ratingValue))
            {
                if (ratingValue < 0 || ratingValue > 100)
                {
                    ErrorList.Add("Rating must be between 0 and 100");
                }
            }
            else
            {
                ErrorList.Add("Rating must be a number");
            }
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

        public static Response<MakeupBrand> GetMakeupBrandById(int id)
        {
            return MakeupBrandHandler.GetMakeupBrandById(id);
        }

        public static Response<List<MakeupBrand>> GetAllMakeupBrands()
        {
            return MakeupBrandHandler.GetAllMakeupBrands();
        }

        public static Response<MakeupBrand> InsertMakeupBrand(string name, string rating)
        {
            List<string> ErrorList = new List<string>();
            ValidateName(name, ErrorList);
            ValidateRating(rating, ErrorList);

            if (ErrorList.Any())
            {
                return CreateErrorResponse<MakeupBrand>(ErrorList);
            }

            return MakeupBrandHandler.InsertMakeupBrand(name, Convert.ToInt32(rating));
        }

        public static Response<MakeupBrand> RemoveMakeupBrandById(string id)
        {
            List<string> ErrorList = new List<string>();
            ValidateId(id, ErrorList);

            if (ErrorList.Any())
            {
                return CreateErrorResponse<MakeupBrand>(ErrorList);
            }

            return MakeupBrandHandler.RemoveMakeupBrandById(Convert.ToInt32(id));
        }

        public static Response<MakeupBrand> UpdateMakeupBrand(string id, string name, string rating)
        {
            List<string> ErrorList = new List<string>();
            ValidateId(id, ErrorList);
            ValidateName(name, ErrorList);
            ValidateRating(rating, ErrorList);

            if (ErrorList.Any())
            {
                return CreateErrorResponse<MakeupBrand>(ErrorList);
            }

            return MakeupBrandHandler.UpdateMakeupBrand(Convert.ToInt32(id), name, Convert.ToInt32(rating));
        }
    }
}
