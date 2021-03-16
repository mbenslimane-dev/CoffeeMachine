using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeUI.Utilities
{
    
    /// <summary>
    /// Http utilities.
    /// </summary>
    public static class HttpUtilities
    {
        /// <summary>
        /// Run web api.
        /// </summary>
        /// <param name="apiUrl">The web api url.</param>
        /// <param name="basicAuthUser">The web api user.</param>
        /// <param name="basicAuthPwd">The web api password.</param>
        public static HttpResponseMessage RunApi(string apiUrl, string basicAuthUser = null, string basicAuthPwd = null, double? secondsTimeout = null)
        {
            try
            {
                // We get the customer golden id
                HttpClient client = new HttpClient();

                // Authentication
                byte[] byteArray;

                if (basicAuthUser != null && basicAuthPwd != null)
                {
                    byteArray = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", basicAuthUser, basicAuthPwd));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                }

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (secondsTimeout != null)
                {
                    client.Timeout = TimeSpan.FromSeconds(secondsTimeout.Value);
                }

                // No cache
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true };

                // List data response.
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.

                client.Dispose();

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get request web api.
        /// </summary>
        /// <param name="url">The web api url.</param>
        public static async Task<HttpResponseMessage> GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                // Blocking call! Program will wait here until a response is received or a timeout occurs.
                var result = await client.GetAsync(url);
                return result;
            }
        }

        /// <summary>
        /// Post request web api (json).
        /// </summary>
        /// <param name="url">The web api url.</param>
        /// <param name="jsonParam">The web api json parameter.</param>
        public static async Task<HttpResponseMessage> PostJsonRequest(string url, JObject jsonParam)
        {
            var jsonString = JsonConvert.SerializeObject(jsonParam);
            return await PostJsonRequest(url, jsonString);
        }

        /// <summary>
        /// Post request web api (json string).
        /// </summary>
        /// <param name="url">The web api url.</param>
        /// <param name="jsonString">The web api json string parameter.</param>
        public static async Task<HttpResponseMessage> PostJsonRequest(string url, string jsonString)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                return await client.PostAsync(url, content);
            }
        }

       

    
    }
}
