#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QwikThrift.Models.DAL
{
    public class User
    {
        private string _password;
        private string _passwordHash;

        /// <summary>
        /// Database Id for user.
        /// </summary>
        public int UserId { get; set; }

        /****************************************************************************
         * TO DO
         * Impliment unique username validation so two users cannot have the 
         * same username.
         ***************************************************************************/

        /// <summary>
        /// Username chosen by user, must be unique (will impliment later)
        /// </summary>
        [Required]
        public string Username { get; set; }
        
        /// <summary>
        /// Used to set/calculate the hashed password value not saved to the database
        /// </summary>
        [NotMapped]
        public string Password 
        { 
            get => _password; 
            set
            {
                _password = value;

                var passHash = new PasswordHasher(value);

                _passwordHash = passHash.PasswordHash;
            }
        }

        /// <summary>
        /// SHA512 encrypted password stored to the database.
        /// </summary>
        [Required]
        public string PasswordHash 
        { 
            get => _passwordHash; 
            set => _passwordHash = value; 
        }

        /// <summary>
        /// User's email address
        /// </summary>
        [Required]
        public string Email { get; set; }
        
        /// <summary>
        /// Defines the user's role within the site. Default is user.
        /// </summary>
        public UserRoles Role { get; set; }

        virtual public List<Message> MessagesSent { get; set; }
        virtual public List<Message> MessagesRecieved { get; set; }

        virtual public List<Listing> Listings { get; set; }

        /// <summary>
        /// Check if user is a member of a given role
        /// </summary>
        /// <param name="role">Role to check for</param>
        /// <returns>True if user's privilages meet or exceed the tested role.</returns>
        public bool CheckRole(UserRoles role)
        {
            //roles with the highest privilage have the lowest values (0 = administrator)
            return Role <= role;
        }

        /// <summary>
        /// Verify user provided the correct password for the given user.
        /// </summary>
        /// <param name="passwordProvided">Password the user entered at the frontend.</param>
        /// <returns>True if password provided matches</returns>
        public bool verifyLogin(string passwordProvided)
        {
            var passHasher = new PasswordHasher(passwordProvided);

            return passHasher.Validate(PasswordHash);
        }
    }
}
