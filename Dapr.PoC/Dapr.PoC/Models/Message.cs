using System;

namespace Dapr.PoC.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
    }
}
