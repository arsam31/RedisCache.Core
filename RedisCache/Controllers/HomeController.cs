using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Quaestor.Bot.PushNotifications;
using RedisCache.Models;

namespace RedisCache.Controllers
{
    public class HomeController : Controller
    {
        private IDistributedCache _cache;
        public HomeController(IDistributedCache cache)
        {
            this._cache = cache;
        }
        public async Task<IActionResult> Index()
        {
            IList<string> oListTokens = new List<string>();
            //FirebaseCloudMessaging oFirebaseCloudMessaging = new FirebaseCloudMessaging();
            oListTokens.Add("f9hKFFSl0Kw:APA91bFKyY7RAaN1RPP330HWCcchA67Ugk64hVJ9KKeGxUls0KC5Ko6sk5Ya5cMtWQ_WVsH_PzntqMrjgaZJv8Nu1p2TjUJTaAYXeUR1OsJ6HvgIe2bycBdzZv8pFZm_3Evo92FNHSS5");
            var data = new
            {
                Url = "",
                Name = "Arsam",
            };
            HttpResponseMessage Result =await FirebaseCloudMessaging.SendFireBaseNotificationAsync(oListTokens, "Hello", "This is Test Notification", data);
            //const string key = "message";
            //const string message = "hello";

            //var cachedData = await _cache.GetAsync(key);
            //var cachedMessage = cachedData!=null? Encoding.UTF8.GetString(cachedData):string.Empty;
            //if (string.IsNullOrEmpty(cachedMessage))
            //{
            //      var data = Encoding.UTF8.GetBytes(message);
            //     await _cache.SetAsync(key, data);
            //}



            return View();
        }
        //public static async Task<HttpResponseMessage> SendFireBaseNotificationAsync(IList<string> deviceTokens, string title, string body, object data)
        //{
        //     string _pushNotificationsURL = "https://fcm.googleapis.com/fcm/send";
        //     string _serverApiKey = "AAAALv8PWB0:APA91bHTaIHfelzvj7kh-F8UXJ8eNW6_Mxy5p5dHm2XQoTvxebPCkor5Hv0STXmnCiVSivp9IFTkItEj2NYqnEzaOVH8CuvSJAkBtzFMQg92u8PENCOd6HzO0DUHsKy8n7gozj6KQFJO";
        //    HttpResponseMessage result = null;
        //    try
        //    {
        //        var messageInformation = new
        //        {
        //            notification = new
        //            {
        //                title = title,
        //                text = body,
        //            },
        //            data = data,
        //            registration_ids = deviceTokens //device token
        //        };
        //        //Object to JSON STRUCTURE => using Newtonsoft.Json;
        //        string jsonMessage = JsonConvert.SerializeObject(messageInformation);
        //        // Create request to Firebase API
        //        var request = new HttpRequestMessage(HttpMethod.Post, _pushNotificationsURL); //FireBase Url 
        //        request.Headers.TryAddWithoutValidation("Authorization", "key=" + _serverApiKey); //server key 
        //        request.Content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");

        //        using (var client = new HttpClient())
        //        {
        //            result = await client.SendAsync(request);

        //        }
        //        //if (result.IsSuccessStatusCode)
        //        //{
        //        //    requestMessage = true;
        //        //}

        //    }
        //    catch (Exception ex)
        //    {
        //        result = new HttpResponseMessage();
        //        //throw;
        //    }

        //    return result;
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
