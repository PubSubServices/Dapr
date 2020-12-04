using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared;
using Shared.Models;
using System;
using System.Threading.Tasks;

namespace MicroServiceB.Controllers
{
  [ApiController]
  public class MessageZController : ControllerBase
  {
    private readonly ILogger<MessageZController> _logger;
    private readonly string _daprPort;

    public MessageZController(ILogger<MessageZController> logger)
    {
      _logger = logger;
      _daprPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT");
    }
    
    [Topic("pubsub", "deepdata")]
    [HttpPost]
    [Route("deepdata")]
    public async Task<IActionResult> ProcessDeepData([FromBody] string message)
    {
      _logger.LogInformation(Const.DAPR.AppZ.PrefixFriendly + "s) ProcessDeepData");
      _logger.LogInformation(Const.DAPR.AppZ.PrefixFriendly + "Data Received: ");
      _logger.LogInformation(JsonConvert.SerializeObject(message, Formatting.Indented));

      _logger.LogInformation(Const.DAPR.AppZ.PrefixFriendly + "e) ProcessDeepData");
      return Ok();
    }
  }
}