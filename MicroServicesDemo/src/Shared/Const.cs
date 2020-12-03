namespace Shared
{
  public class Const
  {
    public struct DAPR
    {
      public struct EventTopic
      {
        public static string NewOrderCheese = "newordercheese";
      }

      public struct EndPointsDAPR
      {
        public static string PublishSuffix = "/v1.0/publish/pubsub";
        public static string InvokeNewOrderFromBSuffix = "/v1.0/invoke/pubsub/method";
      }

      public struct AppA
      {
        public static string PrefixFriendly = "[App A] - ";
      }

      public struct AppB
      {
        public static string PrefixFriendly = "[App B] - ";
      }
    }
  }
}