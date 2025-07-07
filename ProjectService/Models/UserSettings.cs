using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectService.Models;

public class UserSetting
{
  [BsonId]
  public ObjectId Id { get; set; }
  public int UserId { get; set; }
  public string Language { get; set; } // English, Spanish
  public string Theme { get; set; } // light, dark
}
