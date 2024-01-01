using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atolla.ThirdPartyServices.Infrastructure
{
    public interface IRestClient
    {
        Task<R> ExecuteAsync<R>(DefinedHttpVerbs verb, string url, object data = null) where R : class;
    }
}
