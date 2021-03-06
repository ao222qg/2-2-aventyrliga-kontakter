﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aventyrliga_Kontakter.Model.DAL;

namespace Aventyrliga_Kontakter.Model
{
    public class Service
    {
        private ContactDAL  _contactDAL;

        private ContactDAL ContactDAL
        {
            get { return _contactDAL ?? (_contactDAL = new ContactDAL()); }
        }

        public void DeleteContact(int contactId)
        {
            ContactDAL.DeleteContact(contactId);
        }

        public Contact GetContact(int contactId)
        {
            return ContactDAL.GetContactById(contactId);
        }

        public IEnumerable<Contact>GetContacts()
        {
            return ContactDAL.GetContacts();
        }

        public void SaveContact(Contact contact)
        {
            if(contact.ContactId == 0)
            {
                ContactDAL.InsertContact(contact);
            }
            else
            {
                ContactDAL.UpdateContact(contact);
            }
        }
    }
}