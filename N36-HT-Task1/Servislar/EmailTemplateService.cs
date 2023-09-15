using System.Collections;
using System.Collections.Generic;

namespace N36_HT_Task1.Servislar
{
    public class EmailTemplateService
    {
        private readonly Dictionary<Status, EmailTemplate> _emailTemplates = new Dictionary<Status, EmailTemplate>()
        {
            {
                Status.Registered,
                new EmailTemplate
                {
                    Subject = "Kayıt Olunmaya Devam Edildi",
                    Body = "Kayıt olunmaya devam edildi"
                }
            },
            {
                Status.Active,
                new EmailTemplate
                {
                    Subject = "Kayıt Olunmaya Devam Edildi",
                    Body = "Kayıt olunmaya devam edildi"
                }
            },
            {
                Status.Deleted,
                new EmailTemplate
                {
                    Subject = "Kayıt Olunmaya Devam Edildi",
                    Body = "Kayıt olunmaya devam edildi"
                }
            }
        };

        public IEnumerable<EmailTemplate> GetTemplates(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                if (_emailTemplates.TryGetValue(user.Status, out var emailTemplate))
                {
                    var emailtemplates = new EmailTemplate()
                    {
                        Subject = ReplacePlaceholders(emailTemplate.Subject, user),
                        Body = ReplacePlaceholders(emailTemplate.Body, user)
                    };
                    yield return emailtemplates;
                }
            }
        }

        private string ReplacePlaceholders(string emailTemplateSubject, User user)
        {
            emailTemplateSubject = emailTemplateSubject.Replace("Firdavs", $"{user.FirstName} {user.LastName}");
            emailTemplateSubject = emailTemplateSubject.Replace("Provide", "Provide a reason here if applicable");
            return emailTemplateSubject;
        }
    }
}