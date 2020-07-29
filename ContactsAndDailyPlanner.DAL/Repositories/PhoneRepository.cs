using ContactsAndDailyPlanner.DAL.Entities;
using ContactsAndDailyPlanner.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsAndDailyPlanner.DAL.Repositories
{
    public class PhoneRepository : IRepository<Phone>
    {
        private readonly DailyAndContactsContext _db;
        public PhoneRepository(DailyAndContactsContext db)
        {
            _db = db;
        }

        public IEnumerable<Phone> GetAll()
        {
            return _db.Phones;
        }

        public Phone Get(Guid id)
        {
            return _db.Phones.Find(id);
        }

        public IEnumerable<Phone> Find(Func<Phone, Boolean> predicate)
        {
            return _db.Phones.Where(predicate).ToList();
        }

        public void Create(Phone item)
        {
            _db.Phones.Add(item);
        }

        public void Update(Phone item)
        {
            _db.Phones.Update(item);
        }

        public void Delete(Guid id)
        {
            Phone phone = _db.Phones.Find(id);
            if (phone != null)
                _db.Phones.Remove(phone);
        }
    }
}
