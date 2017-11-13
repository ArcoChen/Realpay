using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AppWebApi.App_Start
{
    public class DefaultHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.RequestUri = new Uri(request.RequestUri.ToString());

            MediaTypeHeaderValue contentType = request.Content.Headers.ContentType;

            if (contentType != null)
            {
                switch (contentType.MediaType)
                {
                    case "application/x-www-form-urlencoded":
                        {
                            NameValueCollection formData = await request.Content.ReadAsFormDataAsync(cancellationToken);
                            request.Content = new FormUrlEncodedContent(Correct(formData));
                            //TODO:在这里对formData进行业务处理
                        }
                        break;
                    case "multipart/form-data":
                        {
                            NameValueCollection formData = await request.Content.ReadAsFormDataAsync(cancellationToken);
                            request.Content = new FormUrlEncodedContent(Correct(formData));
                            //TODO:在这里对formData进行业务处理
                        }
                        break;
                    case "application/json":
                        {
                            HttpContentHeaders oldHeaders = request.Content.Headers;
                            string formData = await request.Content.ReadAsStringAsync();
                            request.Content = new StringContent(formData);
                            ReplaceHeaders(request.Content.Headers, oldHeaders);
                            //TODO:在这里对formData进行业务处理
                        }
                        break;
                    default:
                        throw new Exception("Implement It!");
                }
            }

            return await base.SendAsync(request, cancellationToken);
        }

        private static IEnumerable<KeyValuePair<string, string>> Correct(NameValueCollection formData)
        {
            return formData.Keys.Cast<string>().Select(key => new KeyValuePair<string, string>(key, formData[key])).ToList();
        }

        private static void ReplaceHeaders(HttpHeaders currentHeaders, HttpHeaders oldHeaders)
        {
            currentHeaders.Clear();
            foreach (var item in oldHeaders)
                currentHeaders.Add(item.Key, item.Value);
        }
    }
}