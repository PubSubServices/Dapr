using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceA.Controllers
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
    public async Task<IActionResult> ReceiveMessage([FromBody] MessageMicroA message)
    {
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + $"Message with id {message.Id.ToString()} received!");

      //Validate message received
      using (var httpClient = new HttpClient())
      {
        var result = await httpClient.PostAsync(
          Const.EndPoints.EndPointA.MessageTopic,
           new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json")
           );

        _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + $"Message with id {message.Id.ToString()} published with status {result.StatusCode}!");
      }

      return Ok();
    }

    [Topic("messagetopic A")]
    [HttpPost]
    [Route("messagetopic")]
    public async Task<IActionResult> ProcessOrder([FromBody] MessageMicroA message)
    {
      //Process message placeholder
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + $"Message with id {message.Id.ToString()} processed!");
      return Ok();
    }
  }
}