using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAndDailyPlanner.Web.Models.Contact
{
    public class ContactIndexViewModel
    {
        public IEnumerable<ContactViewModel> Contacts { get; set; }
        [Required]
        public string Search { get; set; }
    }
}
