using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared;
using Shared.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
    [Route("api/neworder")]
    public async Task<IActionResult> Neworder([FromBody] MessageB message)
    {
      _logger.LogInformation(Const.EndPoints.EndPointB.PrefixFriendly + "Entering Neworder");
      _logger.LogInformation(Const.EndPoints.EndPointB.PrefixFriendly + $"Message with id {message.Id.ToString()} received!");

      _logger.LogInformation(Const.EndPoints.EndPointB.PrefixFriendly + "Exiting Neworder");
      return Ok();
    }

    [HttpPost]
    [Route("api/messageb")]
    public async Task<IActionResult> ReceiveMessageB([FromBody] MessageB message)
    {
      _logger.LogInformation(Const.EndPoints.EndPointB.PrefixFriendly + "Entering ReceiveMessageB");
      _logger.LogInformation(Const.EndPoints.EndPointB.PrefixFriendly + $"Message with id {message.Id.ToString()} received!");

      //Validate message received
      //using (var httpClientB = new HttpClient())
      //{
      //  var result = await httpClientB.PostAsync(
      //    Const.EndPoints.EndPointB.MessageTopic,
      //     new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json")
      //     );

      //  _logger.LogInformation(Const.EndPoints.EndPointB.PrefixFriendly + $"Message with id {message.Id.ToString()} published with status {result.StatusCode}!");
      //}

      using (var httpClientA = new HttpClient())
      {
        if (message != null)
        {
          message.Content = "bunnies are fuzzy";
        }



        var daprPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT");
        var endPointA = $"http://localhost:{daprPort}/v1.0/invoke/pubsuba/method/neworderfromb";
      
        _logger.LogInformation(Const.EndPoints.EndPointB.PrefixFriendly + "Using endpointa : " + endPointA);


        var invokeResponse = await httpClientA.PostAsync(endPointA, 
          new StringContent(JsonConvert.SerializeObject(message), 
          Encoding.UTF8, "application/json"));

        _logger.LogInformation(Const.EndPoints.EndPointB.PrefixFriendly + $"Message with id {message.Id.ToString()} published with status {invokeResponse.StatusCode}!");
      }

      _logger.LogInformation(Const.EndPoints.EndPointB.PrefixFriendly + "Exiting ReceiveMessageB");
      return Ok();
    }

    [Topic("pubsub", "messagetopicb")]
    [HttpPost]
    [Route("messagetopicb")]
    public async Task<IActionResult> ProcessOrderB([FromBody] DaprEvent<MessageB> message)
    {
      _logger.LogInformation(Const.EndPoints.EndPointB.PrefixFriendly + "Entering ProcessOrderB");
      _logger.LogInformation(Const.EndPoints.EndPointB.PrefixFriendly + $"Message with id {message.data.Id.ToString()} processed!");
      _logger.LogInformation(Const.EndPoints.EndPointB.PrefixFriendly + "Exiting ProcessOrderB");
      return Ok();
    }
  }
}