using N53_Ht_Task1.api.Interfeys;
using N53_Ht_Task1.api.Models;

namespace N53_Ht_Task1.api.Services
{
    public class UserBonusService
    {
        private OrderCreatedEvent _orderEventStore;
        private IUserService _userService;
        private IBonusService _bonusService;
        private BonusAchievedEvent _bonusEventStore;
        private IEnumerable<INotificationService> _notificationServices;

        public UserBonusService(OrderCreatedEvent orderEventStore,
             IUserService userService, IBonusService bonusService, BonusAchievedEvent bonusEventStore,
            IEnumerable<INotificationService> notificationServices)
        {
            _orderEventStore = orderEventStore;


            _userService = userService;

            _bonusService = bonusService;

            _bonusEventStore = bonusEventStore;

            _notificationServices = notificationServices;


            _orderEventStore.OnOrderCreated += HandleOrderCreatedEventAsync;
        }

        public async ValueTask HandleOrderCreatedEventAsync(Order order)
        {
            var user = _userService.Get(user => user.Id == order.UserId).FirstOrDefault();
            var bonus = _bonusService.Get(x => x.UserId == user.Id).FirstOrDefault();

 
            var oldBonusLength = bonus.Amount.ToString().Length;
            var newBonusLenght = (bonus.Amount + order.Amount).ToString().Length;

          
            var updatedBonus = new Bonus(bonus.Id, bonus.Amount + order.Amount, bonus.UserId);
            await _bonusService.UpdateAsync(updatedBonus);


            if (oldBonusLength < newBonusLenght)
            {
                await _bonusEventStore.CreateBonusAchievedEventAsync(bonus);
                return;
            }


            var stringNum = "1";
            for (int _ = 0; _ < oldBonusLength; _++)
            {
                stringNum += "0";
            }

            var num = int.Parse(stringNum);

            foreach (var service in _notificationServices)
            {
                await service.SendAsync(user.Id, $"Bonus olish {num - bonus.Amount}");
            }

        }
    }
}
