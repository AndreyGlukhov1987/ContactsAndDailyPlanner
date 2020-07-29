using ContactsAndDailyPlanner.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactsAndDailyPlanner.DAL
{
    public class DailyAndContactsContext : DbContext
    {
        public DailyAndContactsContext(DbContextOptions<DailyAndContactsContext> options) :
            base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<Email> Emails { get; set; }

        public DbSet<Skype> Skypes { get; set; }

        public DbSet<OtherContactInfo> Others { get; set; }
    }
}
