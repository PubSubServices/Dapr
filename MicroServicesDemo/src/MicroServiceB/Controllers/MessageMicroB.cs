using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceB.Controllers
{
  public class MessageMicroB
  {
    public string EndPointFriendly { get; set; } = "Microservice Endpoint B";
    public Guid Id { get; set; }
    public string Content { get; set; }
    public string Subject { get; set; }
  }
}
