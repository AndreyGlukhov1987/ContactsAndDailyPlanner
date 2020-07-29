using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsAndDailyPlanner.BLL.DTOModels
{
    public class SkypeDTO
    {
        public Guid Id { get; set; }

        public string SkypeType { get; set; }

        public string Value { get; set; }
    }
}
