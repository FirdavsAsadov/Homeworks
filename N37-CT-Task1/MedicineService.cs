using System.Collections.Generic;

namespace N37_CT_Task1
{
    public abstract class IMedicineService
    {
        public List<Medicine> _medicines = new List<Medicine>();
        public abstract void Add(Medicine medicine);
        public abstract void Create(Medicine medicine);
        public abstract List<Medicine> GetAll();
        public abstract Medicine GetById(int id);
        public abstract void Update(Medicine medicine);
    }
}