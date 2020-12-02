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

namespace Tutorial.Controllers
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
      _logger.LogInformation($"Message with id {message.Id.ToString()} received! ccccccccccccccccccc");

      //Validate message received
      using (var httpClient = new HttpClient())
      {
        var result = await httpClient.PostAsync(
          Const.EndPoints.EndPointTutorial.MessageTopic,
           
           new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json")
           );

        _logger.LogInformation($"Message with id {message.Id.ToString()} published with status {result.StatusCode}! bbbbbbbbbbbbb");
      }

      return Ok();
    }

    [Topic("messagetopic tutorial")]
    [HttpPost]
    [Route("messagetopic")]
    public async Task<IActionResult> ProcessOrder([FromBody] Message message)
    {
      //Process message placeholder
      _logger.LogInformation(Const.EndPoints.EndPointTutorial.PrefixFriendly + $"Message with id {message.Id.ToString()} processed!");
      return Ok();
    }
  }
}