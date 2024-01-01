
namespace Atolla.Core
{
    public static class AtollaHttpDefaults
    {
        public static string DefaultHttpClient => "default";

        public static string IsPostBeingDoneRequestItem => "atolla.IsPOSTBeingDone";

        public static string HttpClusterHttpsHeader => "HTTP_CLUSTER_HTTPS";

        public static string HttpXForwardedProtoHeader => "X-Forwarded-Proto";

        public static string XForwardedForHeader => "X-FORWARDED-FOR";
    }
}