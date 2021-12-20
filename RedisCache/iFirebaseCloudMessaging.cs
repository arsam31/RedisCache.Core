using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RedisCache
{
    public static class iFirebaseCloudMessaging
    {
        static string _pushNotificationsURL = ConfigurationManager.AppSettings["FireBasePushNotificationsURL"];
        static string _serverApiKey = ConfigurationManager.AppSettings["FirebaseserverApiKey"];

        public static async Task<HttpResponseMessage> SendFireBaseNotificationAsync(IList<string> deviceTokens, string title, string body, object data)
        {
            HttpResponseMessage result = null;
            try
            {
                var messageInformation = new
                {
                    notification = new
                    {
                        title = title,
                        text = body,
                    },
                    data = data,
                    registration_ids = deviceTokens //device token
                };
                //Object to JSON STRUCTURE => using Newtonsoft.Json;
                string jsonMessage = JsonConvert.SerializeObject(messageInformation);
                // Create request to Firebase API
                var request = new HttpRequestMessage(HttpMethod.Post, _pushNotificationsURL); //FireBase Url 
                request.Headers.TryAddWithoutValidation("Authorization", "key=" + _serverApiKey); //server key 
                request.Content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    result = await client.SendAsync(request);

                }
                //if (result.IsSuccessStatusCode)
                //{
                //    requestMessage = true;
                //}

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

    }
}
