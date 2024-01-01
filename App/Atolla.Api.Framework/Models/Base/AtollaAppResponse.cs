using System.Collections.Generic;

namespace Atolla.Api.Framework.Models.Base
{
    public class AtollaAppResponse : IAtollaAppResponse
    {
        public string Message { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class AtollaAppResponse<T> : IAtollaAppResponse<T>
    {
        public T Model { get; set; }
        public string Message { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class AtollaAppListResponse<T> : IAtollaListResponse<T>
    {
        public IEnumerable<T> Model { get; set; }
        public string Message { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
