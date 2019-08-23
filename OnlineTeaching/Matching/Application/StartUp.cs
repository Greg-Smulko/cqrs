namespace Matching.Application
{
    public static class StartUp
    {
        public static void Main()
        {
            var publisher = new MatchingEventDispatcher("TalkWithMe-Matching", "TalkWithMe", "Matching");
            var subscriber = new ProfileTopicSubscriber();
        }
    }
}
