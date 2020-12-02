using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared;

namespace MicroServiceB.Controllers
{
  [ApiController]
  public class MessageBController : ControllerBase
  {
    private readonly ILogger<MessageBController> _logger;
    public MessageBController(ILogger<MessageBController> logger)
    {
      _logger = logger;
    }

    [HttpPost]
    [Route("api/message")]
    public async Task<IActionResult> ReceiveMessage([FromBody] MessageMicroB message)
    {
      _logger.LogInformation(Const.EndPoints.EndPointB.PrefixFriendly + $"Message with id {message.Id.ToString()} received!");

      //Validate message received
      using (var httpClient = new HttpClient())
      {
        var result = await httpClient.PostAsync(
          Const.EndPoints.EndPointB.MessageTopic,
           new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json")
           );

        _logger.LogInformation(Const.EndPoints.EndPointB.PrefixFriendly + $"Message with id {message.Id.ToString()} published with status {result.StatusCode}!");
      }

      return Ok();
    }

    [Topic("messagetopic B")]
    [HttpPost]
    [Route("messagetopic")]
    public async Task<IActionResult> ProcessOrder([FromBody] MessageMicroB message)
    {
      //Process message placeholder
      _logger.LogInformation(Const.EndPoints.EndPointB.PrefixFriendly +  $"Message with id {message.Id.ToString()} processed!");
      return Ok();
    }
  }
}