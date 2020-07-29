using ContactsAndDailyPlanner.DAL.Entities;
using ContactsAndDailyPlanner.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactsAndDailyPlanner.DAL.Repositories
{
    public class OtherContactInfoRepository : IRepository<OtherContactInfo>
    {
        private readonly DailyAndContactsContext _db;
        public OtherContactInfoRepository(DailyAndContactsContext db)
        {
            _db = db;
        }

        public IEnumerable<OtherContactInfo> GetAll()
        {
            return _db.Others;
        }

        public OtherContactInfo Get(Guid id)
        {
            return _db.Others.Find(id);
        }

        public IEnumerable<OtherContactInfo> Find(Func<OtherContactInfo, Boolean> predicate)
        {
            return _db.Others.Where(predicate).ToList();
        }

        public void Create(OtherContactInfo item)
        {
            _db.Others.Add(item);
        }

        public void Update(OtherContactInfo item)
        {
            _db.Others.Update(item);
        }

        public void Delete(Guid id)
        {
            OtherContactInfo otherContact = _db.Others.Find(id);
            if (otherContact != null)
                _db.Others.Remove(otherContact);
        }
    }
}
