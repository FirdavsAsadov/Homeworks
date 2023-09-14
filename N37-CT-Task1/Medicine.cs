using System;

namespace N37_CT_Task1
{
    public class Medicine
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public decimal Price    { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public DateTime createdDate { get; set;}
        public DateTime updatedDate { get; set;}
    }
}