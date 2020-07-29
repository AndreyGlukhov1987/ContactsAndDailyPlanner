using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsAndDailyPlanner.BLL.DTOModels
{
    public class EmailDTO
    {
        public Guid Id { get; set; }

        public string Value { get; set; }

        public string EmailType { get; set; }
    }
}
