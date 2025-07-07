using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectService.Models;

public class Project
{
  [BsonId]
  public ObjectId Id { get; set; }
  public int UserId { get; set; }
  public string Name { get; set; }
  public List<Chart> Charts { get; set; }
}

public class Chart
{
  public string Symbol { get; set; }
  public string Timeframe { get; set; }
  public List<Indicator> Indicators { get; set; }
}

public class Indicator
{
  public string Name { get; set; } // MA, BB, etc.
  public string Parameters { get; set; }
}
