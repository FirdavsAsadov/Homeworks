﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N45_HT_Task1.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Count { get; set; }
        public OrderProduct(int id,int productId,int orderId, int count)
        {
            Id = id;
            ProductId = productId;
            OrderId = orderId;
            Count = count;
        }
    }
}
