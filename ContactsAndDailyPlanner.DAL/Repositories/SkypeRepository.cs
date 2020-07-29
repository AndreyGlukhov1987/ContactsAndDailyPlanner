using ContactsAndDailyPlanner.DAL.Entities;
using ContactsAndDailyPlanner.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsAndDailyPlanner.DAL.Repositories
{
    public class SkypeRepository : IRepository<Skype>
    {
        private readonly DailyAndContactsContext _db;
        public SkypeRepository(DailyAndContactsContext db)
        {
            _db = db;
        }
        public IEnumerable<Skype> GetAll()
        {
            return _db.Skypes;
        }

        public Skype Get(Guid id)
        {
            return _db.Skypes.Find(id);
        }

        public IEnumerable<Skype> Find(Func<Skype, Boolean> predicate)
        {
            return _db.Skypes.Where(predicate).ToList();
        }

        public void Create(Skype item)
        {
            _db.Skypes.Add(item);
        }

        public void Update(Skype item)
        {
            _db.Skypes.Update(item);
        }

        public void Delete(Guid id)
        {
            Skype skype = _db.Skypes.Find(id);
            if (skype != null)
                _db.Skypes.Remove(skype);
        }
    }
}
