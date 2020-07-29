using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ContactsAndDailyPlanner.DAL.Entities
{
    public class Skype
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string SkypeType { get; set; }

        public string Value { get; set; }
    }
}
