using Reto8.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Reto8.ViewModels
{
    class ContactsViewModel : BaseViewModel
    {
        private List<ContactModel> _contactsList;
        public List<ContactModel> ContactsList
        {
            get => _contactsList;
            set
            {
                _contactsList = value;
                OnPropertyChanged();
            }
        }
    }
}
