using System;

namespace N53_HT_Task1
{
    public class Bonus
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }

        public Bonus(int id, decimal amount,int userId)
        {
            Id = id; 
            Amount = amount;
            UserId = userId;
        }
    }
}