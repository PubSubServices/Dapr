using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dapr.PoC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Dapr.PoC.Controllers
{
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> _logger;
        public MessageController(ILogger<MessageController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("api/message")]
        public async Task<IActionResult> ReceiveMessage([FromBody] Message message)
        {
            _logger.LogInformation($"Message with id {message.Id} received!");

            //Validate message received
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.PostAsync(
                   "http://localhost:3500/v1.0/publish/pubsub/messagetopic",
                   new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json")
                   );

                _logger.LogInformation($"Message with id {message.Id} published with status {result.StatusCode}!");
            }

            return Ok();
        }

        [Topic("pubsub", "messagetopic")]
        [HttpPost]
        [Route("messagetopic")]
        public async Task<IActionResult> ProcessOrder([FromBody] DaprEvent<Message> message)
        {
            //Process message placeholder
            _logger.LogInformation($"Message with id {message.data.Id.ToString()} processed!");
            return Ok();
        }
    }
}
