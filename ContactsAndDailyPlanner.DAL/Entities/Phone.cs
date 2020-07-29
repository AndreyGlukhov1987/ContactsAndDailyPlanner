using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ContactsAndDailyPlanner.DAL.Entities
{
    public class Phone
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string PhoneType { get; set; }

        public string PhoneNumber { get; set; }
    }
}
