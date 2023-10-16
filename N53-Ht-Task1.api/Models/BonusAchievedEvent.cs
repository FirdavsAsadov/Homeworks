namespace N53_Ht_Task1.api.Models
{
    public class BonusAchievedEvent
    {
        public event Func<Bonus, ValueTask>? BonusachievedEvent;
        public async ValueTask CreateBonusAchievedEventAsync(Bonus bonus)
        {
            if(BonusachievedEvent != null)
            {
                BonusachievedEvent?.Invoke(bonus);
            }
        }
    }
}
