namespace QwikThrift.Models
{
    public static class NotificationBanner
    {
        /// <summary>
        /// Set a banner to display on the next page for a set period of time (milliseconds) with the
        /// default being 5000 (5 seconds)
        /// </summary>
        /// <param name="session">Session the banner is attached to. (Pass HttpContext.Session)</param>
        /// <param name="content">content displayed in the banner</param>
        /// <param name="classes">CSS classes to apply to the banner</param>
        /// <param name="displayTime">How long the banner should be displayed in 
        /// milliseconds (default 5000)</param>
        /// <param name="style">CSS inline styles to be applied to the banner</param>
        public static void SetBanner(ISession session, string content, string classes = "", int displayTime = 5000, string style = "")
        {
            session.SetInt32("DisplayTime", displayTime);
            session.SetString("DisplayBanner", "true");
            session.SetString("Content", content);
            session.SetString("Classes", classes);
            session.SetString("Style", style);
        }

        /// <summary>
        /// Checks a session to see if a banner is requested then removes the key that requested the banner.
        /// </summary>
        /// <param name="session">Session to check</param>
        /// <returns>true if a banner has been requested for the given session</returns>
        public static bool CheckForBanner(ISession session)
        {
            if (session.GetString("DisplayBanner") == null) return false;

            session.Remove("DisplayBanner");

            return true;
        }
    }
}
