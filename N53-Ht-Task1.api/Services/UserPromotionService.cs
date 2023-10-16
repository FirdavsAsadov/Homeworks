using N53_Ht_Task1.api.Interfeys;
using N53_Ht_Task1.api.Models;

namespace N53_Ht_Task1.api.Services
{
    public class UserPromotionService
    {
        private BonusAchievedEvent _eventStore;
        private IEnumerable<INotificationService> _notificationServices;

        public UserPromotionService(BonusAchievedEvent eventStore,
            IEnumerable<INotificationService> notificationServices)
        {
            _eventStore = eventStore;

            _notificationServices = notificationServices;


            _eventStore.BonusachievedEvent+= HandleAchievedBonusEventAsync;
        }

        public async ValueTask HandleAchievedBonusEventAsync(Bonus bonus)
        {
            foreach (var notificationService in _notificationServices)
            {
                await notificationService.SendAsync(bonus.UserId, "Yeah Congratulations Your Achieved Bonus!!!");
            }
        }
    }
}
