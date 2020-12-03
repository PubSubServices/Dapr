using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared;
using Shared.Models;
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

    [Topic("pubsub", "newordercheese")]
    [HttpPost]
    [Route("newordercheese")]
    public async Task<IActionResult> ProcessOrderWithCheese([FromBody] DaprEvent<MessageA> message)
    {
      _logger.LogInformation(Const.DAPR.AppA.PrefixFriendly + "s) ProcessOrderWithCheese");
      _logger.LogInformation(JsonConvert.SerializeObject(message, Formatting.Indented));
      _logger.LogInformation(Const.DAPR.AppA.PrefixFriendly + "e) ProcessOrderWithCheese");

      return Ok();
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