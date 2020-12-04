using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceA.Controllers
{
  [ApiController]
  public class MessageAController : ControllerBase
  {
    private readonly ILogger<MessageAController> _logger;
    private readonly string _daprPort;

    public MessageAController(ILogger<MessageAController> logger)
    {
      _logger = logger;
      _daprPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT");
    }

    [Topic("pubsub", "newordercheese")]
    [HttpPost]
    [Route("newordercheese")]
    public async Task<IActionResult> ProcessOrderWithCheese([FromBody] MessageA message)
    {
      _logger.LogInformation(Const.DAPR.AppA.PrefixFriendly + "s) ProcessOrderWithCheese");
      _logger.LogInformation(JsonConvert.SerializeObject(message, Formatting.Indented));

      var taskList = new List<Task>();
      for (int idx = 0; idx < 10; idx++)
      {
        taskList.Add(HandOffDeepData("deep data: " +  idx));
      }

      Task.WaitAll(taskList.ToArray());
      
      //await HandOffDeepData(message);

      _logger.LogInformation(Const.DAPR.AppA.PrefixFriendly + "e) ProcessOrderWithCheese");

      return Ok();
    }


    private async Task HandOffDeepData(string message)
    {
      _logger.LogInformation(Const.DAPR.AppA.PrefixFriendly + "s) " + "HandOffDeepData");

      using (var httpClient = new HttpClient())
      {
        var endPoint = $"http://localhost:{_daprPort}" + Const.DAPR.EndPointsDAPR.PublishSuffix + "/" + Const.DAPR.EventTopic.DeepData;

        _logger.LogInformation(Const.DAPR.AppA.PrefixFriendly + "Using endpoint : " + endPoint);

        var response = await httpClient.PostAsync(endPoint,
          new StringContent(JsonConvert.SerializeObject(message),
          Encoding.UTF8, "application/json"));

        _logger.LogInformation(Const.DAPR.AppA.PrefixFriendly + $"Response {response.StatusCode}!");
      }

      _logger.LogInformation(Const.DAPR.AppA.PrefixFriendly + "e) " + "HandOffDeepData");
    }




    [Topic("pubsub", "neworderfromb")]
    [HttpPost]
    [Route("neworderfromb")]
    public async Task<IActionResult> NewOrderFromB([FromBody] DaprEvent<MessageB> message)
    {
      _logger.LogInformation(Const.DAPR.AppA.PrefixFriendly + "Entering NewOrderFromB");

      _logger.LogInformation(Const.DAPR.AppA.PrefixFriendly + "Message:");

      _logger.LogInformation(JsonConvert.SerializeObject(message, Formatting.Indented));

      if (message?.data?.Id != null)
      {
        _logger.LogInformation(Const.DAPR.AppA.PrefixFriendly + $"Message with id {message.data.Id.ToString()} processed!");
      }
      else
      {
        _logger.LogInformation(Const.DAPR.AppA.PrefixFriendly + "something was null");
        _logger.LogInformation(JsonConvert.SerializeObject(message));
      }
      _logger.LogInformation(Const.DAPR.AppA.PrefixFriendly + "Exiting NewOrderFromB");
      return Ok();
    }
  }
}