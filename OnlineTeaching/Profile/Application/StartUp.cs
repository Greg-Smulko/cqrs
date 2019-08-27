namespace Profile.Application
{
    public class StartUp
    {
        public static void Main()
        {
            var dispatcher = new ProfileEventDispatcher("TalkWithMe-Profile", "TalkWithMe", "Profile");
            var matchingSubscriber = new MatchingTopicSubscriber();
        }
    }
}
