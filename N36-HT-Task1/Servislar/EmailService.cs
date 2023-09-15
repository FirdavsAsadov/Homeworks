using System.Collections;
using System.Collections.Generic;

namespace N36_HT_Task1.Servislar
{
    public class EmailService
    {
        public IEnumerable<EmailMessage> GetMessages(IEnumerable<EmailTemplate> templates, IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                foreach (var template in templates)
                {
                    var emailmessage = new EmailMessage
                    {
                        Subject = ReplaceHolders(template.Subject, user),
                        Body = ReplaceHolders(template.Body, user),
                        SenderAddress = "example@example.com",
                        ReceiverAddress = user.Email
                    };
                    yield return emailmessage;
                }
            }
        }

        private string ReplaceHolders(string template, User user)
        {
            template = template.Replace("Jonny", $"{user.FirstName} {user.LastName}");
            template = template.Replace("Garry","jony balance is great to me");
            return template;
        }
    }
}