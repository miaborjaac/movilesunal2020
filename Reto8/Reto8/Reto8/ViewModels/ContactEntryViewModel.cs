using System;
using System.Collections.Generic;
using System.Text;

namespace Reto8.ViewModels
{
    class ContactEntryViewModel : BaseViewModel
    {
        private List<String> _contactTypes;
        public List<string> ContactTypes
        {
            get => _contactTypes;
            set
            {
                _contactTypes = value;
                OnPropertyChanged();
            }
        }
        public ContactEntryViewModel()
        {
            List<string> contactTypes = new List<string>();
            contactTypes.Add("Consultoría");
            contactTypes.Add("Desarrollo a la medida");
            contactTypes.Add("Fábrica de software");

            ContactTypes = contactTypes;
        }
    }
}
