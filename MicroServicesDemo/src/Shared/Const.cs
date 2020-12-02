namespace Shared
{
  public class Const
  {
    public struct EndPoints
    {
      
      public struct EndPointA
      {
        public static string PrefixFriendly = "[Microservice A] - ";
        public static string Message = "http://localhost:6000/api/message";
        public static string MessageTopic = "http://localhost:6500/v1.0/publish/messagetopic";
      }

      public struct EndPointB
      {
        public static string PrefixFriendly = "[Microservice B] - ";
        public static string MessageTopic = "http://localhost:7500/v1.0/publish/messagetopic";
        public static string Message = "http://localhost:7000/api/message";
      }

      public struct EndPointTutorial
      {
        public static string PrefixFriendly = "[Microservice Tutorial] - ";
        public static string Message = "http://localhost:5000/api/message";
        public static string MessageTopic = "http://localhost:5500/v1.0/publish/messagetopic";
      }
    }
  }
}