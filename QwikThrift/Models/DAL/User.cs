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
                //generate a password salt to add to the hash
                PasswordSalt = User.GenerateSalt();

                //store the password in memory (will be discarded upon object deletion)
                _password = value;

                //create the pasword hasher object
                var passHash = new PasswordHasher(PasswordSalt + value);

                //save the newly salted and hashed password
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
        /// Salt used to secure password hash.
        /// </summary>
        public string PasswordSalt { get; set; } = string.Empty;

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
        /// Generate a random 256 character string to salt a password hash. What is wrong with 
        /// programmers and the way we name things! Seriously, the reason we "salt and hash" a
        /// password is to protect against something called a "rainbow table" Lol...
        /// </summary>
        /// <returns>Salt string</returns>
        public static string GenerateSalt()
        {
            var salt = string.Empty;
            var rand = new Random();

            for (var i = 0; i < 256; i++) 
            {
                salt += (char)rand.Next(35, 126);
            }

            return salt;
        }

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
        public bool VerifyLogin(string passwordProvided)
        {
            var passHasher = new PasswordHasher(PasswordSalt + passwordProvided);

            return passHasher.Validate(PasswordHash);
        }
    }
}
