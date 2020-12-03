using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared;
using Shared.Models;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceB.Controllers
{
  [ApiController]
  public class MessageBController : ControllerBase
  {
    private readonly ILogger<MessageBController> _logger;
    private readonly StackTrace _stackTrace;
    private readonly string _daprPort;

    public MessageBController(ILogger<MessageBController> logger)
    {
      _logger = logger;
      _stackTrace = new StackTrace();
      _daprPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT");
    }

    [HttpPost]
    [Route("api/publishCheese")]
    public async Task<IActionResult> ReceiveMessageNewFoodOrder([FromBody] MessageB message)
    {
      _logger.LogInformation(Const.DAPR.AppB.PrefixFriendly + "Entering ReceiveMessageNewFoodOrder");
      _logger.LogInformation(Const.DAPR.AppB.PrefixFriendly + "Data Received: ");
      _logger.LogInformation(JsonConvert.SerializeObject(message, Formatting.Indented));

      await PublishEvent(message);

      _logger.LogInformation(Const.DAPR.AppB.PrefixFriendly + "Exiting ReceiveMessageNewFoodOrder");
      return Ok();
    }

    [HttpPost]
    [Route("api/invoke-cheese")]
    public async Task<IActionResult> InvokeCheese([FromBody] MessageB message)
    {
      _logger.LogInformation(Const.DAPR.AppB.PrefixFriendly + "s) InvokeCheese");
      _logger.LogInformation(Const.DAPR.AppB.PrefixFriendly + "Data Received: ");
      _logger.LogInformation(JsonConvert.SerializeObject(message, Formatting.Indented));

      await InvokeMethod(message);

      _logger.LogInformation(Const.DAPR.AppB.PrefixFriendly + "e) InvokeCheese");
      return Ok();
    }

    private async Task InvokeMethod(MessageB message)
    {
      _logger.LogInformation(Const.DAPR.AppB.PrefixFriendly + "s) " + "InvokeMethodOnA");

      using (var httpClient = new HttpClient())
      {
        var endPointA = $"http://localhost:{_daprPort}" + Const.DAPR.EndPointsDAPR.InvokeNewOrderFromBSuffix;

        _logger.LogInformation(Const.DAPR.AppB.PrefixFriendly + "Using endpoint : " + endPointA);

        var invokeResponse = await httpClient.PostAsync(endPointA,
          new StringContent(JsonConvert.SerializeObject(message),
          Encoding.UTF8, "application/json"));

        _logger.LogInformation(Const.DAPR.AppB.PrefixFriendly + $"Message with id {message.Id.ToString()} Invoked with status {invokeResponse.StatusCode}!");
      }

      _logger.LogInformation(Const.DAPR.AppB.PrefixFriendly + "e) " + "InvokeMethodOnA");
    }

    private async Task PublishEvent(MessageB message)
    {
      _logger.LogInformation(Const.DAPR.AppB.PrefixFriendly + "s) " + "PublishEvent");

      using (var httpClient = new HttpClient())
      {
        var endPoint = $"http://localhost:{_daprPort}" + Const.DAPR.EndPointsDAPR.PublishSuffix + "/" + Const.DAPR.EventTopic.NewOrderCheese;

        _logger.LogInformation(Const.DAPR.AppB.PrefixFriendly + "Using endpoint : " + endPoint);

        var response = await httpClient.PostAsync(endPoint,
          new StringContent(JsonConvert.SerializeObject(message),
          Encoding.UTF8, "application/json"));

        _logger.LogInformation(Const.DAPR.AppB.PrefixFriendly + $"Response {response.StatusCode}!");
      }

      _logger.LogInformation(Const.DAPR.AppB.PrefixFriendly + "e) " + "PublishEvent");
    }

    //[Topic("pubsub", "messagetopicb")]
    //[HttpPost]
    //[Route("messagetopicb")]
    //public async Task<IActionResult> ProcessOrderB([FromBody] DaprEvent<MessageB> message)
    //{
    //  _logger.LogInformation(Const.DAPR.AppB.PrefixFriendly + "Entering ProcessOrderB");
    //  _logger.LogInformation(Const.DAPR.AppB.PrefixFriendly + $"Message with id {message.data.Id.ToString()} processed!");
    //  _logger.LogInformation(Const.DAPR.AppB.PrefixFriendly + "Exiting ProcessOrderB");
    //  return Ok();
    //}
  }
}