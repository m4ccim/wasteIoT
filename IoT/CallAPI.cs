using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace IoT
{


    public static class CallApi
    {
        public enum Roles
        {
            guest,
            user,
            admin
        }
        public static Roles Role;
        public static string UserName;
        public static int StockNumber;
        public static Dictionary<string, string> dic = new Dictionary<string, string>();

        public static void Alert(HttpResponseMessage response)
        {
            if (dic.ContainsKey("ErrorMessage"))
                return;
            dic.Clear();
            if (response.IsSuccessStatusCode)
            {
                dic.Add("SuccessMessage", response.StatusCode.ToString());
            }
            else dic.Add("ErrorMessage", response.StatusCode.ToString());
        }

        public static HttpClient GetClient(string token)
        {
            HttpClient WebApiClient = new HttpClient();
            WebApiClient.BaseAddress = new Uri("http://localhost:56270/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //WebApiClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            return WebApiClient;
        }

        public static HttpResponseMessage Get(string token, string route)
        {
            HttpClient WebApiClient = GetClient(token);
            HttpResponseMessage response = WebApiClient.GetAsync(route).Result;
            return response;
        }

        public static HttpResponseMessage Get(string token, string route, string id)
        {
            HttpClient WebApiClient = GetClient(token);
            HttpResponseMessage response = WebApiClient.GetAsync(route + "/" + id).Result;
            return response;
        }

        public static HttpResponseMessage Post(string token, string route, object body)
        {
            HttpClient WebApiClient = GetClient(token);
            HttpResponseMessage response = WebApiClient.PostAsync(route, new StringContent(
                JsonConvert.SerializeObject(body, Formatting.Indented, new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                        }), 
                        Encoding.UTF8, "application/json")).Result;
            Alert(response);
            return response;
        }

        public static HttpResponseMessage Put(string token, string route, object body, string id)
        {
            HttpClient WebApiClient = GetClient(token);
            var response = WebApiClient.PostAsync(route + "/" + id,
                new ByteArrayContent(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(body))));
            Alert(response.Result);
            return response.Result;
        }
        public static async Task<HttpResponseMessage> DeleteAsync(string token, string route, string id)
        {
            HttpClient WebApiClient = GetClient(token);
            HttpResponseMessage response = await WebApiClient.DeleteAsync(route + "/" + id);
            Alert(response);
            return response;
        }

    }
}
