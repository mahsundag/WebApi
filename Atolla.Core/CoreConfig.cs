namespace Atolla.Core
{
    public class Config
    {
        public bool DisplayFullErrorStack { get; set; }
        public string UserAgentStringsPath { get; set; }
        public bool UseRowNumberForPaging { get; set; }

        public bool UseSessionStateTempDataProvider { get; set; }

        public string ForwardedHttpHeader { get; set; }

        public bool UseHttpClusterHttps { get; set; }

        public bool UseHttpXForwardedProto { get; set; }
        public string KeycloakAuthority { get; set; }
        public string KeycloakClientId { get; set; }
        public string KeycloakClientSecret { get; set; }
    }

    public static class HttpDefaults
    {
        public static string DefaultHttpClient => "default";

        public static string IsPostBeingDoneRequestItem => "Atolla.IsPOSTBeingDone";

        public static string HttpClusterHttpsHeader => "HTTP_CLUSTER_HTTPS";

        public static string HttpXForwardedProtoHeader => "X-Forwarded-Proto";

        public static string XForwardedForHeader => "X-FORWARDED-FOR";

    }
}
