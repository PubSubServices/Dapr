using System;

namespace MicroServiceB.Models
{
  public class MessageB
  {
    public Guid Id { get; set; }
    public string Content { get; set; }
    public string Subject { get; set; }
  }
}