using ContactsAndDailyPlanner.BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsAndDailyPlanner.BLL.Interfaces
{
    public interface IContactService
    {
        void Create(ContactDTO contactDto);
        void Update(ContactDTO contactDto);
        ContactDTO GetContact(Guid id);
        IEnumerable<ContactDTO> GetContacts();
        IEnumerable<ContactDTO> Find(string query);
        void Delete(Guid id);
        void Dispose();
    }
}
