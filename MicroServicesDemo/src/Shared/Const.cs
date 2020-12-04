namespace Shared
{
  public class Const
  {
    public struct DAPR
    {
      public struct EventTopic
      {
        public static string NewOrderCheese = "newordercheese";
        public static string DeepData = "deepdata";
      }

      public struct EndPointsDAPR
      {
        public static string PublishSuffix = "/v1.0/publish/pubsub";
        public static string PublishDeepSuffix = "/v1.0/publish/pubsub";

        public static string InvokeNewOrderFromBSuffix = "/v1.0/invoke/appa/method";
      }

      public struct AppA
      {
        public static string PrefixFriendly = "[App A] - ";
      }

      public struct AppB
      {
        public static string PrefixFriendly = "[App B] - ";
      }

      public struct AppZ
      {
        public static string PrefixFriendly = "[App Z] - ";
      }
    }
  }
}