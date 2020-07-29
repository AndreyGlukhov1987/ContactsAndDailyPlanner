using ContactsAndDailyPlanner.DAL.Entities;
using ContactsAndDailyPlanner.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactsAndDailyPlanner.DAL.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        private readonly DailyAndContactsContext _db;
        public ContactRepository(DailyAndContactsContext db)
        {
            _db = db;
        }

        public IEnumerable<Contact> GetAll()
        {
            return _db.Contacts.AsNoTracking();
        }

        public Contact Get(Guid id)
        {
            var contact = _db.Contacts
                .Include(c => c.Emails)
                .Include(c => c.Phones)
                .Include(c => c.Skypes)
                .Include(c => c.Others)
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);

            return contact;
        }

        public IEnumerable<Contact> Find(Func<Contact, Boolean> predicate)
        {
            var contacts = _db.Contacts
                .Include(c => c.Emails)
                .Include(c => c.Phones)
                .Include(c => c.Skypes)
                .Include(c => c.Others)
                .AsNoTracking();
            return contacts.Where(predicate).ToList();
        }

        public void Create(Contact item)
        {
            _db.Contacts.Add(item);
        }

        public void Update(Contact item)
        {
            _db.Contacts.Update(item);
        }

        public void Delete(Guid id)
        {
            Contact contact = _db.Contacts.Find(id);
            if (contact != null)
                _db.Contacts.Remove(contact);
        }
    }
}
