using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aventyrliga_Kontakter.Model
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}