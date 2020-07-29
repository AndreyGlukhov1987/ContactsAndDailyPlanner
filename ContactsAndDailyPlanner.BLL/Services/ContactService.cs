using AutoMapper;
using ContactsAndDailyPlanner.BLL.DTOModels;
using ContactsAndDailyPlanner.BLL.Interfaces;
using ContactsAndDailyPlanner.DAL.Entities;
using ContactsAndDailyPlanner.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactsAndDailyPlanner.BLL.Services
{
    public class ContactService : IContactService
    {
        private readonly IDatabaseUnit _database;
        private readonly IMapper _mapper;
        public ContactService(IDatabaseUnit database)
        {
            _database = database;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ContactDTO, Contact>();
                cfg.CreateMap<EmailDTO, Email>();
                cfg.CreateMap<PhoneDTO, Phone>();
                cfg.CreateMap<SkypeDTO, Skype>();
                cfg.CreateMap<OtherContactInfoDTO, OtherContactInfo>();
                cfg.CreateMap<Contact, ContactDTO>();
                cfg.CreateMap<Email, EmailDTO>();
                cfg.CreateMap<Phone, PhoneDTO>();
                cfg.CreateMap<Skype, SkypeDTO>();
                cfg.CreateMap<OtherContactInfo, OtherContactInfoDTO>();
            }).CreateMapper();
        }

        public void Create(ContactDTO contactDto)
        {
            // валидация
            if (contactDto == null)
                throw new ValidationException("", "");

            _database.Contacts.Create(_mapper.Map<ContactDTO, Contact>(contactDto));
            _database.Save();
        }

        public void Update(ContactDTO contactDto)
        {
            if (contactDto == null)
                throw new ValidationException("", "");

            var prevContact = GetContact(contactDto.Id);

            //compare old and new lists in contact
            //and that was removed by editing
            var newEmailsIds = contactDto.Emails.Select(email => email.Id);
            var removedEmails = prevContact.Emails.Where(email => !newEmailsIds.Contains(email.Id));

            var newPhonesIds = contactDto.Phones.Select(phone => phone.Id);
            var removedPhones = prevContact.Phones.Where(phone => !newPhonesIds.Contains(phone.Id));

            var newSkypesIds = contactDto.Skypes.Select(skype => skype.Id);
            var removedSkypes = prevContact.Skypes.Where(skype => !newSkypesIds.Contains(skype.Id));

            var newOthersIds = contactDto.Others.Select(other => other.Id);
            var removedOthers = prevContact.Others.Where(other => !newOthersIds.Contains(other.Id));

            RemoveEmails(removedEmails);
            RemovePhones(removedPhones);
            RemoveSkypes(removedSkypes);
            RemoveOthers(removedOthers);

            _database.Contacts.Update(_mapper.Map<ContactDTO, Contact>(contactDto));

            _database.Save();
        }

        public ContactDTO GetContact(Guid id)
        {
            if (id == null || id == Guid.Empty)
                throw new ValidationException("", "");

            var contact = _database.Contacts.Get(id);
            if (contact == null)
                throw new ValidationException("", "");

            return _mapper.Map<Contact, ContactDTO>(contact);
        }

        public ContactDTO GetContactWithLinks(Guid id)
        {
            if (id == null || id == Guid.Empty)
                throw new ValidationException("", "");

            var contact = _database.Contacts.Get(id);
            if (contact == null)
                throw new ValidationException("", "");

            return _mapper.Map<Contact, ContactDTO>(contact);
        }

        public IEnumerable<ContactDTO> GetContacts()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            return _mapper.Map<IEnumerable<Contact>, List<ContactDTO>>(_database.Contacts.GetAll());
        }

        public IEnumerable<ContactDTO> Find(string query)
        {
            // применяем автомаппер для проекции одной коллекции на другую
            return _mapper.Map<IEnumerable<Contact>, List<ContactDTO>>(_database.Contacts.Find(val => val.FirstName.Contains(query, StringComparison.OrdinalIgnoreCase) 
                                                                                                      || val.LastName.Contains(query, StringComparison.OrdinalIgnoreCase)
                                                                                                      || (val.MiddleName != null ? val.MiddleName.Contains(query, StringComparison.OrdinalIgnoreCase) : false)
                                                                                                      || (val.Position != null ? val.Position.Contains(query, StringComparison.OrdinalIgnoreCase) : false)
                                                                                                      || (val.Organisation != null ? val.Organisation.Contains(query, StringComparison.OrdinalIgnoreCase) : false)
                                                                                                      || val.Phones.Any(p => p.PhoneType.Contains(query, StringComparison.OrdinalIgnoreCase)
                                                                                                                            || p.PhoneNumber.Contains(query, StringComparison.OrdinalIgnoreCase))
                                                                                                      || val.Skypes.Any(s => s.SkypeType.Contains(query, StringComparison.OrdinalIgnoreCase)
                                                                                                                            || s.Value.Contains(query, StringComparison.OrdinalIgnoreCase))
                                                                                                      || val.Emails.Any(e => e.EmailType.Contains(query, StringComparison.OrdinalIgnoreCase)
                                                                                                                            || e.Value.Contains(query, StringComparison.OrdinalIgnoreCase))
                                                                                                      || val.Others.Any(o => o.Value.Contains(query, StringComparison.OrdinalIgnoreCase))));
        }

        public void Delete(Guid id)
        {
            var contact = GetContact(id);
            if (contact == null)
                return;

            RemoveEmails(contact.Emails);
            RemovePhones(contact.Phones);
            RemoveSkypes(contact.Skypes);
            RemoveOthers(contact.Others);

            _database.Contacts.Delete(id);
            _database.Save();
        }

        public void Dispose()
        {
            _database.Dispose();
        }

        private void RemoveEmails(IEnumerable<EmailDTO> emails)
        {
            if (emails == null)
                return;

            foreach (var email in emails)
            {
                _database.Emails.Delete(email.Id);
            }
        }

        private void RemovePhones(IEnumerable<PhoneDTO> phones)
        {
            if (phones == null)
                return;

            foreach (var phone in phones)
            {
                _database.Phones.Delete(phone.Id);
            }
        }

        private void RemoveSkypes(IEnumerable<SkypeDTO> skypes)
        {
            if (skypes == null)
                return;

            foreach (var skype in skypes)
            {
                _database.Skypes.Delete(skype.Id);
            }
        }

        private void RemoveOthers(IEnumerable<OtherContactInfoDTO> others)
        {
            if (others == null)
                return;

            foreach (var other in others)
            {
                _database.Others.Delete(other.Id);
            }
        }

        private void UpdateEmails(IEnumerable<EmailDTO> emails)
        {
            if (emails == null)
                return;

            foreach (var email in emails)
            {
                _database.Emails.Update(_mapper.Map<EmailDTO, Email>(email));
            }
        }

        private void UpdatePhones(IEnumerable<PhoneDTO> phones)
        {
            if (phones == null)
                return;

            foreach (var phone in phones)
            {
                _database.Phones.Update(_mapper.Map<PhoneDTO, Phone>(phone));
            }
        }

        private void UpdateSkypes(IEnumerable<SkypeDTO> skypes)
        {
            if (skypes == null)
                return;

            foreach (var skype in skypes)
            {
                _database.Skypes.Update(_mapper.Map<SkypeDTO, Skype>(skype));
            }
        }

        private void UpdateOthers(IEnumerable<OtherContactInfoDTO> others)
        {
            if (others == null)
                return;

            foreach (var other in others)
            {
                _database.Others.Update(_mapper.Map<OtherContactInfoDTO, OtherContactInfo>(other));
            }
        }
    }
}
