﻿using System;

namespace Shared.Models
{
  public class DaprEvent<T>
  {
    public Guid id { get; set; }
    public string datacontenttype { get; set; }
    public string pubsubname { get; set; }
    public string source { get; set; }
    public string specversion { get; set; }
    public string subject { get; set; }
    public string topic { get; set; }
    public string type { get; set; }
    public T data { get; set; }
  }
}