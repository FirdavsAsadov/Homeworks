using System.Collections;
using System.Threading.Tasks;

namespace N36_HT_Task1.Servislar
{
    public class NotificationManagementService
    {
        private readonly UserService _userService;
        private readonly EmailService _emailService;
        private readonly EmailTemplateService   _emailTemplateService;
        private readonly EmailSenderService _emailSenderService;

        public NotificationManagementService(UserService userService, 
            EmailService emailService, 
            EmailTemplateService emailTemplateService,
            EmailSenderService emailSenderService)
        {
            _userService = userService;
            _emailService = emailService;
            _emailTemplateService = emailTemplateService;
            _emailSenderService = emailSenderService;
        }

        public async Task NotifiyUserAsync()
        {
            var users = _userService.GetUsers();
            var templates = _emailTemplateService.GetTemplates(users);
            var messages = _emailService.GetMessages(templates, users);
            await _emailSenderService.SendEmailAsync(messages);
        }
    }
}