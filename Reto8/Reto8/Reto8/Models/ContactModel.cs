using System;
using System.Collections.Generic;
using SQLite;

namespace Reto8.Models
{
    public class ContactModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string WebPageUrl { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Services { get; set; }
        public string ContactType { get; set; }
    }
}
