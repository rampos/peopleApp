using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsClutter.Models
{
    public class Contact
    {
        public string Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LateModifiedDateTime { get; set; }
        public string ChangeKey { get; set; }
        public List<string> Categories { get; set; }
        public string ParentFolderId { get; set; }
        public string Birthday { get; set; }
        public string FileAs { get; set; }
        public string DisplayName { get; set; }
        public string GivenName { get; set; }
        public string Initials { get; set; }
        public string MiddleName { get; set; }        
        public string NickName { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string YomiGivenName { get; set; }
        public string YomiSurname { get; set; }
        public string YomiCompanyName { get; set; }
        public string Generation { get; set; }
        public List<EmailAddress> EmailAddresses { get; set; }
        public List<string> ImAddresses { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string Department { get; set; }
        public string OfficeLocation { get; set; }
        public string Profession { get; set; }
        public string BusinessHomePage { get; set; }
        public string AssistantName { get; set; }
        public string Manager { get; set; }
        public List<string> HomePhones { get; set; }
        public string MobilePhone { get; set; }
        public List<string> BusinessPhones { get; set; }
        public Address HomeAddress { get; set; }
        public Address BusinessAddress { get; set; }
        public Address OtherAddress { get; set; }
        public string SpouseName { get; set; }
        public string PersonalNotes { get; set; }
        public List<string> Children { get; set; }

        public Contact()
        {
            //this.DisplayName = displayName;
            //this.EmailAddresses = emailAddresses.ToList();
            //this.MobilePhone = mobilePhone;
        }

    }
}
