using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N45_HT_Task1.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public int UserID { get; set; }
        public Order(decimal amount, int userId)
        {
            Amount = amount;
            UserID = userId;
        }
    }
}
