using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aventyrliga_Kontakter.Model;

namespace Aventyrliga_Kontakter
{
    public partial class Default : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service());}
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        public IEnumerable<Contact>ContactListView_GetData()
        {
            return Service.GetContacts();
        }
        
        public void ContactListView_InsertItem(Contact contact)
        {
            try
            {
                Service.SaveContact(contact);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "An unexpected error occured when a new contact was added!");
                return;
            }

            if (TryUpdateModel(contact))
            {
                Service.SaveContact(contact);
            }
        }

        public void ContactListView_DeleteItem(int contactId)
        {
            try
            {
                Service.DeleteContact(contactId);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "An unexpected error occured when a contact was removed!");
            }
        }
    }
}