using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsAndDailyPlanner.BLL.DTOModels
{
    public class ContactDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Organisation { get; set; }

        public string Position { get; set; }

        public ICollection<PhoneDTO> Phones { get; set; }

        public ICollection<SkypeDTO> Skypes { get; set; }

        public ICollection<EmailDTO> Emails { get; set; }

        public ICollection<OtherContactInfoDTO> Others { get; set; }
    }
}
