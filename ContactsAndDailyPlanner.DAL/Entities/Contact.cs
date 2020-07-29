using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ContactsAndDailyPlanner.DAL.Entities
{
    public class Contact
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? BirthDate { get; set; }

        public string Organisation { get; set; }

        public string Position { get; set; }

        public ICollection<Phone> Phones { get; set; }

        public ICollection<Skype> Skypes { get; set; }

        public ICollection<Email> Emails { get; set; }

        public ICollection<OtherContactInfo> Others { get; set; }

    }
}
