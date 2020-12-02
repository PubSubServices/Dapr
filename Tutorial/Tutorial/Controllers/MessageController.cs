using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
      _logger.LogInformation($"Message with id {message.Id.ToString()} received!");

      //Validate message received
      using (var httpClient = new HttpClient())
      {
        var result = await httpClient.PostAsync(
           "http://localhost:3500/v1.0/publish/messagetopic",
           new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json")
           );

        _logger.LogInformation($"Message with id {message.Id.ToString()} published with status {result.StatusCode}!");
      }

      return Ok();
    }
  }
