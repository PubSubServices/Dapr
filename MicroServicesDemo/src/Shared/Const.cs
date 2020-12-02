namespace Shared
{
  public class Const
  {
    public struct EndPoints
    {
      public struct EndPointA
      {
        public static string Message = "http://localhost:5010/api/message";
        public static string MessageTopic = "http://localhost:3510/v1.0/publish/messagetopic";   //"http://localhost:3500/v1.0/publish/messagetopic"
        public static string PrefixFriendly = "[Microservice A] - ";
      }

      public struct EndPointB
      {
        public static string Message = "http://localhost:5020/api/message";
        public static string MessageTopic = "http://localhost:3520/v1.0/publish/messagetopic";
        public static string PrefixFriendly = "[Microservice B] - ";
      }

      public struct EndPointTutorial
      {
        public static string Message = "http://localhost:5000/api/message";
        public static string PrefixFriendly = "[Microservice Tutorial] - ";
        public static string MessageTopic = "http://localhost:3500/v1.0/publish/messagetopic";         // "http://localhost:3500/v1.0/publish/messagetopic"
      }
    }
  }
}