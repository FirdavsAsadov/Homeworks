using N52_ht_Task_1.Models;
using N52_ht_Task_1.Services.Interfeys;

namespace N52_ht_Task_1.Services
{
    public class AccountService : IAccountService
    {

        private AccountEventstore _eventStore;
        private IEmailSenderService _emailSender;

        public AccountService(AccountEventstore eventStore, IEmailSenderService emailSender)
        {
            _eventStore = eventStore;
            _emailSender = emailSender;

            _eventStore.OnUserCreated += HandleUserCreatedEventAsync;
        }

        public async ValueTask HandleUserCreatedEventAsync(User user)
        {
            await _emailSender.SendEmailAsync(user);
        }
    }
}
