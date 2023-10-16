using System;

namespace N53_HT_Task1
{
    public class Order
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public int userId { get; set; }

        public Order(int id,string name, int userid)
        {
            Id = id;
            Name = name;
            userId = userid;
        }
    }
}