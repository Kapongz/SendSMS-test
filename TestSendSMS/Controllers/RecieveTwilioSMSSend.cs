using Microsoft.AspNetCore.Mvc;
using TestSendSMS.Models;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace TestSendSMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecieveTwilioSMSSend : TwilioController
    {
        [HttpPost("SendReplay")]
        public TwiMLResult SendReplay([FromForm] TwilioSMS request)
        {
            var messagingResponse = new MessagingResponse();
            messagingResponse.Message("The copy cat says: " +
                                      request.Body);

            return TwiML(messagingResponse);
        }
    }
}
