using Atolla.Api.Framework.Models.Base;
using System.Collections.Generic;
using System.Linq;

namespace Atolla.Api.Framework.Extensions
{
    public static class ResponseModelExtensions
    {
        public static AtollaAppResponse<T> ToResponse<T>(this BaseModel model) where T : BaseModel
        {
            var response = new AtollaAppResponse<T>();
            response.ErrorMessage = string.Empty;
            response.HasError = false;
            response.Message = string.Empty;
            response.Model = (T)model;
            return response;
        }

        public static AtollaAppListResponse<T> ToResponse<T>(this IEnumerable<BaseModel> model) where T : BaseModel
        {
            var response = new AtollaAppListResponse<T>();
            response.ErrorMessage = string.Empty;
            response.HasError = false;
            response.Message = string.Empty;
            response.Model = (IEnumerable<T>)model.AsEnumerable();
            return response;
        }
    }
}
