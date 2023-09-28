using QwikThrift.Models.DAL;

namespace QwikThrift.Models
{
    public class UserManager
    {
        private QwikThriftDbContext _dbContext;
        private ISession _session;

        /// <summary>
        /// Used to retrieve the userId from the session.
        /// </summary>
        private string SessionUserKey
        {
            get => "________SESSION_USER_KEY________";
        }

        /// <summary>
        /// Returns true if a user session is active
        /// </summary>
        public bool UserLoggedIn
        {
            get
            {
                if (_session == null)
                    return false;

                if (_session.GetInt32(SessionUserKey) == null)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// Retrieves the currently logged in user
        /// </summary>
        public User? User
        {
            get
            {
                if (!UserLoggedIn)
                    return null;

                int? userId = _session.GetInt32(SessionUserKey);

                if (userId == null)
                    return null;

                return _dbContext.Users.First<User>(u => u.UserId == userId);
            }
        }

        public UserManager(ISession session, QwikThriftDbContext dbContext) 
        {
            _session = session;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Saves the userId to the current session so it can be retrived for later.
        /// </summary>
        /// <param name="user">User to save to the session</param>
        public void SaveUserSession(User user) 
        {
            _session.SetInt32(SessionUserKey, user.UserId);
        }

        /// <summary>
        /// Removes the user session key logging the user out.
        /// </summary>
        public void DeleteUserSession() 
        {
            _session.Remove(SessionUserKey);
        }
    }
}
