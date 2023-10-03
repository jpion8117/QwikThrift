namespace QwikThrift.Models
{
    public static class NotificationBanner
    {
        private static bool _bannerVisible;

        /// <summary>
        /// Content displayed in banner
        /// </summary>
        public static string Content { get; set; } = "";

        /// <summary>
        /// Classes to apply to banner
        /// </summary>
        public static string Classes { get; set; } = "";

        /// <summary>
        /// Custom CSS inline-styles to apply
        /// </summary>
        public static string Style { get; set; } = "";

        /// <summary>
        /// Self-resets to false when read.
        /// </summary>
        public static bool BannerVisible
        { 
            get
            {
                var currentState = _bannerVisible;

                _bannerVisible = false;

                return currentState;
            }

            set => _bannerVisible = value; 
        }


        public static void SetBanner(string content, string classes = "", string style = "")
        {
            BannerVisible = true;
            Content = content;
            Classes = classes;
            Style = style;
        }
    }
}
