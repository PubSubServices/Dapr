using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared;
using Shared.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceA.Controllers
{
  [ApiController]
  public class MessageAController : ControllerBase
  {
    private readonly ILogger<MessageAController> _logger;

    public MessageAController(ILogger<MessageAController> logger)
    {
      _logger = logger;
    }

    [HttpPost]
    [Route("api/messagea")]
    public async Task<IActionResult> ReceiveMessageA([FromBody] MessageMicroA message)
    {
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "Entering ReceiveMessageA");
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + $"Message with id {message.Id.ToString()} received!");

      //Validate message received
      using (var httpClient = new HttpClient())
      {
        var result = await httpClient.PostAsync(
          Const.EndPoints.EndPointA.MessageTopicA,
           new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json")
           );

        _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + $"Message with id {message.Id.ToString()} published with status {result.StatusCode}!");
      }

      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "Exiting ReceiveMessageA");
      return Ok();
    }

    [Topic("pubsub", "messagetopica")]
    [HttpPost]
    [Route("messagetopica")]
    public async Task<IActionResult> ProcessOrderFromA([FromBody] DaprEvent<MessageMicroA> message)
    {
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "Entering ProcessOrderA");
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + $"Message with id {message.data.Id.ToString()} processed!");
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "Exiting ProcessOrderA");
      return Ok();
    }

    [Topic("pubsub", "messagetopicafromb")]
    [HttpPost]
    [Route("messagetopicafromb")]
    public async Task<IActionResult> ProcessOrderFromB([FromBody] DaprEvent<MessageB> message)
    {
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "Entering ProcessOrderA");
      if (message?.data?.Id != null)
      {
        _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + $"Message with id {message.data.Id.ToString()} processed!");
      }
      else
      {
        _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "something was null");
        _logger.LogInformation(JsonConvert.SerializeObject(message));
      }
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "Exiting ProcessOrderA");
      return Ok();
    }

    //  app.UseAuthorization();
    //    app.UseEndpoints(endpoints =>
    //    {
    //      endpoints.MapGet("/dapr/subscribe", async context =>
    //      {
    //        var subscribedTopics = new List<string>() { "neworder" };
    //  await context.Response.WriteAsync(JsonConvert.SerializeObject(subscribedTopics));
    //});

    [Topic("pubsub", "neworderfromb")]
    [HttpPost]
    [Route("neworderfromb")]
    public async Task<IActionResult> NewOrderFromB([FromBody] DaprEvent<MessageB> message)
    {
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "Entering NewOrderFromB");
      if (message?.data?.Id != null)
      {
        _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + $"Message with id {message.data.Id.ToString()} processed!");
      }
      else
      {
        _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "something was null");
        _logger.LogInformation(JsonConvert.SerializeObject(message));
      }
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "Exiting NewOrderFromB");
      return Ok();
    }
  }
}