using ContactsAndDailyPlanner.Web.Models.Email;
using ContactsAndDailyPlanner.Web.Models.OtherContacInfo;
using ContactsAndDailyPlanner.Web.Models.Phone;
using ContactsAndDailyPlanner.Web.Models.Skype;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAndDailyPlanner.Web.Models.Contact
{
    public class ContactViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        public string Organisation { get; set; }

        public string Position { get; set; }

        public IList<PhoneViewModel> Phones { get; set; }

        public IList<SkypeViewModel> Skypes { get; set; }

        public IList<EmailViewModel> Emails { get; set; }

        [DisplayName("Other Contact Info")]
        public IList<OtherContactInfoViewModel> Others { get; set; }
    }
}
