using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceA.Controllers
{
  public class MessageMicroA
  {
    public string EndPointFriendly { get; set; } = "Microservice Endpoint A";
    public Guid Id { get; set; }
    public string Content { get; set; }
    public string Subject { get; set; }
  }
}
