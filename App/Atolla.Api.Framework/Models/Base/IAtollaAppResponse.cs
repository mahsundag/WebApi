using System.Collections;
using System.Collections.Generic;

namespace Atolla.Api.Framework.Models.Base
{
    public interface IAtollaAppResponse
    {
        string Message { get; set; }

        bool HasError { get; set; }
        string ErrorMessage { get; set; }
    }

    public interface IAtollaAppResponse<T> : IAtollaAppResponse
    {
        T Model { get; set; }
    }

    public interface IAtollaListResponse<T> : IAtollaAppResponse
    {
        IEnumerable<T> Model { get; set; }
    }
}
