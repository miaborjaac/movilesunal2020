using Reto8.Models;
using Reto8.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Reto8.Data
{
    class ContactSearchHandler : SearchHandler
    {
        protected override async void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                List<ContactModel> list = await App.DataBase.GetContactsAsync();
                ItemsSource = list
                    .Where(contact => 
                        contact.Name.ToLower().Contains(newValue.ToLower()) || 
                        contact.ContactType.ToLower().Contains(newValue.ToLower())
                    )
                    .ToList<ContactModel>();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            await App.Current.MainPage.Navigation.PushAsync(new EditContactPage
            {
                BindingContext = item as ContactModel
            });
        }
    }
}
