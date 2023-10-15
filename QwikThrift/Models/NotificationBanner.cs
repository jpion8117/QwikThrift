namespace QwikThrift.Models
{
    public static class NotificationBanner
    {
        private static bool _bannerVisible;
        private static int _nextSessionKey = 1;

        private static int NextSessionKey
        {
            get
            {
                var key = _nextSessionKey;
                _nextSessionKey++;
                return key;
            }
        }

        public static Dictionary<int, ISession> Sessions { get; set; } = new Dictionary<int, ISession>();

        public static void SetBanner(ISession session, string content, string classes = "", string style = "")
        {
            var key = NextSessionKey;
            Sessions[key] = session;
            session.SetString("DisplayBanner", "true");
            session.SetString("Content", content);
            session.SetString("Classes", classes);
            session.SetString("Style", style);
        }

        public static bool CheckForBanner(ISession session)
        {
            if (session.GetString("DisplayBanner") == null) return false;

            session.Remove("DisplayBanner");

            return true;
        }
    }
}
