using Microsoft.AspNetCore.Http;

namespace Atolla.Core.Helpers
{
    public interface IWebHelper
    {
        bool IsRequestBeingRedirected { get; }
        bool IsPostBeingDone { get; set; }
        string CurrentRequestProtocol { get; }

        string GetUrlReferrer();
        string GetCurrentIpAddress();
        string GetThisPageUrl(bool includeQueryString, bool? useSsl = null, bool lowercaseUrl = false);
        bool IsCurrentConnectionSecured();
        string GetStoreHost(bool useSsl);
        string GetStoreLocation(bool? useSsl = null);
        bool IsStaticResource();
        string ModifyQueryString(string url, string key, params string[] values);
        string RemoveQueryString(string url, string key, string value = null);
        T QueryString<T>(string name);
        void RestartAppDomain(bool makeRedirect = false);
        bool IsLocalRequest(HttpRequest req);
        string GetRawUrl(HttpRequest request);
        bool IsAjaxRequest(HttpRequest request);
    }
}
