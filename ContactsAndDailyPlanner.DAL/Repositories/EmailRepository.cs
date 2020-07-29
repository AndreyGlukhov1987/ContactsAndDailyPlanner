using ContactsAndDailyPlanner.DAL.Entities;
using ContactsAndDailyPlanner.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactsAndDailyPlanner.DAL.Repositories
{
    public class EmailRepository : IRepository<Email>
    {

        private readonly DailyAndContactsContext _db;
        public EmailRepository(DailyAndContactsContext db)
        {
            _db = db;
        }
        public IEnumerable<Email> GetAll()
        {
            return _db.Emails;
        }

        public Email Get(Guid id)
        {
            return _db.Emails.Find(id);
        }

        public IEnumerable<Email> Find(Func<Email, Boolean> predicate)
        {
            return _db.Emails.Where(predicate).ToList();
        }

        public void Create(Email item)
        {
            _db.Emails.Add(item);
        }

        public void Update(Email item)
        {
            _db.Emails.Update(item);
        }

        public void Delete(Guid id)
        {
            Email email = _db.Emails.Find(id);
            if (email != null)
                _db.Emails.Remove(email);
        }
    }
}
