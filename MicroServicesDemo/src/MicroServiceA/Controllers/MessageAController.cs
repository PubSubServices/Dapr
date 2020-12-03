using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared;
using Shared.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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
      //_logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + $"Message with id {message.data.Id.ToString()} processed!");
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "Exiting ProcessOrderA");
      return Ok();
    }


    [Topic("pubsuba", "newordercheese")]
    [HttpGet]
    [Route("/dapr/subscribe")]
    public async Task<IActionResult> DogBone([FromBody] DaprEvent<MessageMicroA> message)
    {
      Debugger.Launch();
      Debugger.Break();

      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "s) ProcessOrderWithCheese");
      //_logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + $"Message with id {message.data.Id.ToString()} processed!");
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "e) ProcessOrderWithCheese");
    
      return Ok();
    }


    [Topic("pubsuba", "newordercheese")]
    [HttpPost]
    [Route("newordercheese")]
    public async Task<IActionResult> ProcessOrderWithCheese([FromBody] DaprEvent<MessageMicroA> message)
    {
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "s) ProcessOrderWithCheese");
      //_logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + $"Message with id {message.data.Id.ToString()} processed!");
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "e) ProcessOrderWithCheese");
      return Ok();
    }


    [Topic("pubsub", "messagetopicafromb")]
    [HttpPost]
    [Route("messagetopicafromb")]
    public async Task<IActionResult> ProcessOrderFromB([FromBody] DaprEvent<MessageB> message)
    {
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "s) ProcessOrderA");
      if (message?.data?.Id != null)
      {
        _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + $"Message with id {message.data.Id.ToString()} processed!");
      }
      else
      {
        _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "something was null");
        _logger.LogInformation(JsonConvert.SerializeObject(message));
      }
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "e) ProcessOrderA");
      return Ok();
    }

    

    [Topic("pubsub", "neworderfromb")]
    [HttpPost]
    [Route("neworderfromb")]
    public async Task<IActionResult> NewOrderFromB([FromBody] DaprEvent<MessageB> message)
    {
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "Entering NewOrderFromB");
      
      _logger.LogInformation(Const.EndPoints.EndPointA.PrefixFriendly + "Message:");

      _logger.LogInformation(JsonConvert.SerializeObject(message, Formatting.Indented));

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