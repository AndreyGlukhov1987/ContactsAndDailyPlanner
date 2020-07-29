using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsAndDailyPlanner.BLL.DTOModels
{
    public class PhoneDTO
    {
        public Guid Id { get; set; }

        public string PhoneType { get; set; }

        public string PhoneNumber { get; set; }
    }
}
