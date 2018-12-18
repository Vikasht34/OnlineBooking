using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UtilityProject.ApiConnection
{
    public class ApiConnection : IApiConnection
    {
        private readonly HttpClient _httpClient;
        private readonly string _webServiceRootAddress;

        public ApiConnection()
        {
            _httpClient = new HttpClient();
            _webServiceRootAddress = "http://localhost:16377/api/";
        }

        /// <summary>
        /// Calls a GET request to the API to return data from the method provided.
        /// </summary>
        /// <typeparam name="T">Type of object for the JSON to convert into</typeparam>
        /// <param name="apiMethodName">Name of the method called in the API</param>
        /// <param name="pathParameters">List of optional path parameters to pass</param>
        /// <returns>An object converted from JSON by the API</returns>
        public async Task<T> RequestGet<T>(string apiMethodName, params string[] pathParameters)
        {
            string jsonPath = GetJsonPath(apiMethodName);
            AddPathParameters(ref jsonPath, pathParameters);
            string jsonData = await GetJsonFromGet(jsonPath);
            return ConvertFromJson<T>(jsonData);
        }

        /// <summary>
        /// Calls a POST request to the API to send data to the API and return data from the method provided
        /// </summary>
        /// <typeparam name="T">Type of object for the JSON to convert into</typeparam>
        /// <param name="apiMethodName">Name of the method called in the API</param>
        /// <param name="objectToPost">An object that will be converted into JSON to use in the API method</param>
        /// <returns>An object converted from JSON by the API</returns>
        public async Task<T> RequestPost<T>(string apiMethodName, object objectToPost)
        {
            string jsonPath = GetJsonPath(apiMethodName);
            string jsonData = await GetJsonFromPost(jsonPath, objectToPost);
            return ConvertFromJson<T>(jsonData);
        }

        /// <summary>
        /// Calls a GET request to the API to return a response from the server. Should only be used for quick ping-like requests.
        /// </summary>
        /// <param name="apiMethodName">Name of the method called in the API</param>
        /// <returns>An HTTP request from the API</returns>
        public async Task<HttpResponseMessage> RequestGetResponse(string apiMethodName)
        {
            string jsonPath = GetJsonPath(apiMethodName);
            return await GetResponseMessageFromGet(jsonPath);
        }

        /// <summary>
        /// Calls a POST request to the API to return response from the server.
        /// </summary>
        /// <param name="apiMethodName">Name of the method called in the API</param>
        /// <param name="objectToPost">An object that will be converted into JSON to use in the API method</param>
        /// <returns>An HTTP request from the API</returns>
        public async Task<HttpResponseMessage> RequestPostResponse(string apiMethodName, object objectToPost)
        {
            string jsonPath = GetJsonPath(apiMethodName);
            return await GetResponseMessageFromPost(jsonPath, objectToPost);
        }

        /// <summary>
        /// Retrieves a JSON string from a GET call to the API
        /// </summary>
        /// <param name="requestUrl">The complete JSON path to the method call</param>
        /// <returns>the JSON content response string</returns>
        private async Task<string> GetJsonFromGet(string requestUrl)
        {
            HttpResponseMessage response = await GetResponseMessageFromGet(requestUrl);
            return await GetReponseContent(response);
        }

        /// <summary>
        /// Retrieves a JSON string from a POST call to the API
        /// </summary>
        /// <param name="requestUrl">The complete JSON path to the method call</param>
        /// <param name="objectToPost">The object passed in for the POST call</param>
        /// <returns>the JSON content response string</returns>
        private async Task<string> GetJsonFromPost(string requestUrl, object objectToPost)
        {
            HttpResponseMessage response = await GetResponseMessageFromPost(requestUrl, objectToPost);
            return await GetReponseContent(response);
        }

        /// <summary>
        /// Retrieves the response message from a GET call to the API
        /// </summary>
        /// <param name="requestUrl">The complete JSON path to the method call</param>
        /// <returns>The response message with the content</returns>
        private async Task<HttpResponseMessage> GetResponseMessageFromGet(string requestUrl)
        {
            AddJsonHeader();

            try
            {
                return await _httpClient.GetAsync(requestUrl);
            }

            catch (HttpRequestException e)
            {
                throw new HttpRequestException("Http", e);
            }

            catch (Exception e)
            {
                throw new Exception("Genral", e);
            }
        }

        /// <summary>
        /// Retrieves the response message from a POST call to the API
        /// </summary>
        /// <param name="requestUrl">The complete JSON path to the method call</param>
        /// <param name="objectToPost">The object passed in for the POST call</param>
        /// <returns>The response message with the content</returns>
        private async Task<HttpResponseMessage> GetResponseMessageFromPost(string requestUrl, object objectToPost)
        {
            AddJsonHeader();
            StringContent content = GetStringContent(objectToPost);

            try
            {
                return await _httpClient.PostAsync(requestUrl, content);
            }

            catch (HttpRequestException e)
            {
                throw new HttpRequestException("Http", e);
            }

            catch (Exception e)
            {
                throw new Exception("Exception", e);
            }
        }

        /// <summary>
        /// Returns the API path to get the Json data
        /// </summary>
        /// <param name="methodName">Json Method Name</param>
        /// <returns>Full URL path to the API</returns>
        private string GetJsonPath(string methodName)
        {
            return $"{_webServiceRootAddress}{methodName}";
        }

        /// <summary>
        /// Adds optional path parameters into the json path
        /// </summary>
        /// <param name="pathParameters">optional list of parameters passed in the path</param>
        private void AddPathParameters(ref string jsonPath, string[] pathParameters)
        {
            if (pathParameters != null && pathParameters.Length > 0)
                jsonPath += "/" + string.Join("/", pathParameters.Where(p => p != null));
        }

        /// <summary>
        /// Converts an object from Json into a fitting object with the same member variable names
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="json">Json pulled from REST</param>
        /// <returns>A new object of the type from Json</returns>
        private T ConvertFromJson<T>(string json)
        {
            if (json == null)
                return default(T);
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// Adds the header necessary for retrieving json data
        /// </summary>
        private void AddJsonHeader()
        {
            _httpClient.DefaultRequestHeaders.Remove("Authorization");
            string token = "$5632565434";
            var header = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(header);
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
        }

        /// <summary>
        /// Retrieves the content as a JSON string from a response message if the message was successful.
        /// </summary>
        /// <param name="response">The response message to get content from</param>
        /// <returns>If the message was successful it returns the content as a JSON string. Otherwise it returns null</returns>
        private async Task<string> GetReponseContent(HttpResponseMessage response)
        {
            return response.IsSuccessStatusCode ?
                await response.Content.ReadAsStringAsync() :
                null;
        }

        /// <summary>
        /// Returns a String Content object used to send json data to the API
        /// </summary>
        /// <param name="content">The object to be converted into a string</param>
        /// <returns>An HttpContent object to pass through to the API</returns>
        private StringContent GetStringContent(object content)
        {
            string serializedContent = JsonConvert.SerializeObject(content);
            return new StringContent(serializedContent, Encoding.UTF8, "application/json");
        }

    }
}
