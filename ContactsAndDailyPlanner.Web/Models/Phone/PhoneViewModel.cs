using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAndDailyPlanner.Web.Models.Phone
{
    public class PhoneViewModel
    {
        public Guid Id { get; set; }

        public string PhoneType { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
