using System;
using System.Collections.Generic;
using System.Linq;

namespace N37_CT_Task1
{
    public class MedicineServicee : IMedicineService
    {
        public List<Medicine> _medicines;
        public override void Add(Medicine medicine)
        {
            var result = _medicines.FirstOrDefault(x => x.Id == medicine.Id);
            if (result != null)
            {
                result.Count += 1;
                _medicines.Add(result);
            }
                throw new ArgumentException("This servicee has already been added");
            
        }

        public override void Create(Medicine medicine)
        {
            var result = _medicines.FirstOrDefault(x => x.Name == medicine.Name);
            if (result!= null)
            {
                throw new ArgumentException("This servicee has already been added");
            }
            _medicines.Add(medicine);
        }

        public override List<Medicine> GetAll()
        {
            return _medicines.ToList();
        }

        public override Medicine GetById(int id)
        {
            return _medicines.FirstOrDefault(x => Equals(x.Id, id));
        }

        public override void Update(Medicine medicine)
        {
            var result = _medicines.FirstOrDefault(x => x.Id == medicine.Id);
            if (result!= null)
            {
                _medicines.Remove(result);
                _medicines.Add(medicine);
            }
        }
    }
}