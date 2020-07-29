using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAndDailyPlanner.Web.Common
{
    public static class ContactTypes
    {
        public enum ContactType
        {
            Home,
            Work,
            Cell,
            Main,
            Fax
        }

        public static ContactType[] PhoneTypes = { ContactType.Home, ContactType.Work, ContactType.Cell, ContactType.Fax, ContactType.Main };
        public static ContactType[] EmailTypes = { ContactType.Home, ContactType.Work };
        public static ContactType[] SkypeTypes = { ContactType.Home, ContactType.Work };
    }
}
