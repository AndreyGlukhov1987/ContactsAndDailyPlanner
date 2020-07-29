using ContactsAndDailyPlanner.DAL.Entities;
using ContactsAndDailyPlanner.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactsAndDailyPlanner.DAL.Repositories
{
    public class DatabaseUnit : IDatabaseUnit
    {
        private DailyAndContactsContext _db;
        private ContactRepository _contactRepository;
        private EmailRepository _emailRepository;
        private PhoneRepository _phoneRepository;
        private SkypeRepository _skypeRepository;
        private OtherContactInfoRepository _otherContactInfoRepository;
        private bool _disposed = false;

        public DatabaseUnit(DbContextOptions<DailyAndContactsContext> options)
        {
            _db = new DailyAndContactsContext(options);
        }
        public IRepository<Contact> Contacts
        {
            get
            {
                if (_contactRepository == null)
                    _contactRepository = new ContactRepository(_db);

                return _contactRepository;
            }
        }

        public IRepository<Email> Emails
        {
            get
            {
                if (_emailRepository == null)
                    _emailRepository = new EmailRepository(_db);

                return _emailRepository;
            }
        }

        public IRepository<Skype> Skypes
        {
            get
            {
                if (_skypeRepository == null)
                    _skypeRepository = new SkypeRepository(_db);

                return _skypeRepository;
            }
        }

        public IRepository<Phone> Phones
        {
            get
            {
                if (_phoneRepository == null)
                    _phoneRepository = new PhoneRepository(_db);

                return _phoneRepository;
            }
        }

        public IRepository<OtherContactInfo> Others
        {
            get
            {
                if (_otherContactInfoRepository == null)
                    _otherContactInfoRepository = new OtherContactInfoRepository(_db);

                return _otherContactInfoRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
