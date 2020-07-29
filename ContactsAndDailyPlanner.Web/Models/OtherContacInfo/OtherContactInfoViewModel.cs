using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAndDailyPlanner.Web.Models.OtherContacInfo
{
    public class OtherContactInfoViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
