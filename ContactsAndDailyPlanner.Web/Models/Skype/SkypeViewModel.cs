using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAndDailyPlanner.Web.Models.Skype
{
    public class SkypeViewModel
    {
        public Guid Id { get; set; }

        public string SkypeType { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
