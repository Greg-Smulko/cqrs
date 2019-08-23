namespace Profile.Application
{
    public class StartUp
    {
        public static void Main()
        {
            var dispatcher = new ProfileEventDispatcher("TalkWithMe-Matching", "TalkWithMe", "Matching");
            var matchingSubscriber = new MatchingTopicSubscriber();
        }
    }
}
