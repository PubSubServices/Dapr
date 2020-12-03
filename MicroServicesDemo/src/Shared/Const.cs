namespace Shared
{
  public class Const
  {
    public struct EndPoints
    {

      public struct EndPointsDAPR
      {
        public static string PublishSuffix = "/v1.0/publish/pubsub";
        public static string InvokeNewOrderFromBSuffix = "/v1.0/invoke/pubsub/method/neworderfromb";

      }

      public struct EndPointA
      {
        //public static string Message = "http://localhost:5010/api/message";
        public static string MessageTopicA = "http://localhost:3500/v1.0/publish/pubsub/messagetopica";   
        public static string MessageTopicAFromB = "http://localhost:3500/v1.0/publish/pubsub/messagetopicafromb";  

        public static string PrefixFriendly = "[Microservice A] - ";

        public struct EventTopic
        {
          public static string NewOrderCheese = "newordercheese";
        }

      }

      public struct EndPointB
      {
        //public static string Message = "http://localhost:5010/api/message";
        public static string MessageTopic = "http://localhost:3500/v1.0/publish/pubsub/messagetopicb";                                             
        public static string PrefixFriendly = "[Microservice B] - ";
      }

      public struct EndPointTutorial
      {
        //public static string Message = "http://localhost:5000/api/message";
        public static string PrefixFriendly = "[Microservice Tutorial] - ";
        public static string MessageTopic = "http://localhost:3500/v1.0/publish/messagetopic";         // "http://localhost:3500/v1.0/publish/messagetopic"
      }
    }
  }
}