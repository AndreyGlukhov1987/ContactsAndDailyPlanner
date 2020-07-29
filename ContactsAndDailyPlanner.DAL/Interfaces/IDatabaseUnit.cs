using ContactsAndDailyPlanner.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsAndDailyPlanner.DAL.Interfaces
{
    public interface IDatabaseUnit : IDisposable
    {
        IRepository<Contact> Contacts { get; }

        IRepository<Phone> Phones { get; }

        IRepository<Skype> Skypes { get; }

        IRepository<Email> Emails { get; }

        IRepository<OtherContactInfo> Others { get; }

        void Save();
    }
}
