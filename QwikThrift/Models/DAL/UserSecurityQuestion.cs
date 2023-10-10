#nullable disable

using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace QwikThrift.Models.DAL
{
    public class UserSecurityQuestion
    {
        private string _answer;

        public SelectList Questions { get; set; } = new SelectList(new List<string> 
        {
            "In what city were you born?",
            "What is your mother/father's last name before marage?",
            "What high school did you attend?",
            "What was the name of your elementary school?",
            "What was the make of your first car?",
            "What was your favorite food as a child?",
            "What was the name of your first family pet?",
            "Where did you meet your spouse/significant other?"
        });

        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Question { get; set; }

        [NotMapped]
        public string Answer
        {
            get => _answer;
            set
            {
                _answer = value;
                AnswerSalt = User.GenerateSalt();
                AnswerHash = new PasswordHasher(AnswerSalt + value.ToLower()).PasswordHash;            
            }
        }

        public string AnswerHash { get; set; }

        public string AnswerSalt { get; set; }

        public bool VerifyAnswer(string answer)
        {
            var answerHash
                = new PasswordHasher(AnswerSalt + answer.ToLower()).PasswordHash;
            return answerHash == AnswerHash;
        }
    }
}
