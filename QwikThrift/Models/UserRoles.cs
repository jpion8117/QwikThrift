
namespace QwikThrift.Models
{
    public enum UserRoles
    {
        /// <summary>
        /// Roll assigned to users with the highest access privilages
        /// administrators can change core settings of the site.
        /// </summary>
        Administrator,

        /// <summary>
        /// Roll assigned to users tasked with moderating site content, moderators can 
        /// remove or hide posts that go against the rules of the site. Moderators may 
        /// also suspend abusive users.
        /// </summary>
        Moderator,

        /// <summary>
        /// No special privilages, user may post listings and message other users
        /// </summary>
        User,

        /// <summary>
        /// User may not post or message other users while suspended.
        /// </summary>
        SuspendedUser
    }
}
