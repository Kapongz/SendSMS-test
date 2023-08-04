using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace TestSendSMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TwilioSMSSend : ControllerBase
    {
        string accountSid = "AC59314e427d14ebd0e6c07d774374cfc1";
        string authToken = "1bf2e64aefefecb1ecff5ca86edacfcb";



        [HttpPost("sendText")]
        public ActionResult Sendtext(string phonenumber)
        {
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "ບັກແປັບ ຫົວຄວຍຍຍຍຍຍຍຍນ້ອງຊາຍ.",
                from: new Twilio.Types.PhoneNumber("+17623004628"),
                to: new Twilio.Types.PhoneNumber("+856" + phonenumber)
            );

            return StatusCode(200,new {message = message.Sid});
        }
    }
}
