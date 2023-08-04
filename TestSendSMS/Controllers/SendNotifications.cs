using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;

namespace TestSendSMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SendNotifications : ControllerBase
    {

        [HttpPost]
        public IActionResult SendPushNotification()
        {
            try
            {
                var webRequest = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;
                webRequest.KeepAlive = true;
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json; charset=utf-8";
                webRequest.Headers.Add("authorization", $"Basic {ApiKey}");

                var obj = new
                {
                    app_id = AppId,
                    headings = new { en = "Web Push Notification Title" }, //this value can be change as per need, can be a value from db
                    contents = new { en = "Here it goes push notification content" }, //this value can be change as per need, can be a value from db
                    included_segments = new string[] { "All" },
                    url = ""
                };
                var param = JsonConvert.SerializeObject(obj);
                var byteArray = Encoding.UTF8.GetBytes(param);

                using (var writer = webRequest.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = webRequest.GetResponse() as HttpWebResponse)
                {
                    if (response != null)
                    {
                        using var reader = new StreamReader(response.GetResponseStream());
                        var responseContent = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            //return View("~/views/home/index.cshtml");
        }
    }
}
