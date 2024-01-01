using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Atolla.ThirdPartyServices.Infrastructure
{
    public class RestClient : IRestClient
    {
        ILogger<RestClient> _logger;

        Dictionary<string, string> additionalHeaders = new Dictionary<string, string>();
        public RestClient(ILogger<RestClient> logger)
        {
            this._logger = logger;
        }

        private void AddHeaders(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            //No additional headers to be added
            if (additionalHeaders == null)
                return;

            foreach (KeyValuePair<string, string> current in additionalHeaders)
            {
                httpClient.DefaultRequestHeaders.Add(current.Key, current.Value);
            }
        }

        public async Task<R> ExecuteAsync<R>(DefinedHttpVerbs verb, string url, object data = null) where R : class
        {
            try
            {
                R result = null;
                using (HttpClientHandler httpClientHandler = new HttpClientHandler())
                {
                    //https için gerekli olabilir.
                    //httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
                    using (HttpClient httpClient = new HttpClient(httpClientHandler))
                    {
                        AddHeaders(httpClient);
                        HttpResponseMessage message = null;
                        if (verb == DefinedHttpVerbs.GET)
                            message = await httpClient.GetAsync(new Uri(url));
                        else if (verb == DefinedHttpVerbs.POST)
                            message = await httpClient.PostAsync(new Uri(url), data, new JsonMediaTypeFormatter());


                        message.EnsureSuccessStatusCode();
                        await message.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                        {
                            if (x.IsFaulted)
                                throw x.Exception;

                            result = JsonConvert.DeserializeObject<R>(x.Result);
                        });
                    }
                }
                return result;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Request is not success");
                // write to log
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Request error");
                // write to log
                return null;
            }
        }

    }
}
