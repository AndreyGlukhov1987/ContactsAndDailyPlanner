using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAndDailyPlanner.Web.Models.Email
{
    public class EmailViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [EmailAddress]
        public string Value { get; set; }

        public string EmailType { get; set; }
    }
}
