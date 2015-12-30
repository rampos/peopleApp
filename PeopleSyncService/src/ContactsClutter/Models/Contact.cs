using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsClutter.Models
{
    public class Contact
    {
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }

        public Contact(string displayName, IList<string> emailAddresses, string mobilePhone)
        {
            this.DisplayName = displayName;
            this.EmailAddress = emailAddresses[0] == null ? "" : emailAddresses[0];
            this.MobilePhone = mobilePhone;
        }

    }
}
