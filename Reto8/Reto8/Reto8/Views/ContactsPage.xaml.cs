using System;
using Xamarin.Forms;
using Reto8.Models;
using Xamarin.Forms.Xaml;
using Reto8.ViewModels;

namespace Reto8.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        private readonly ContactsViewModel _viewModel;
        public ContactsPage()
        {
            BindingContext = _viewModel = new ContactsViewModel();
            _viewModel.Title = "Contactos";

            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.ContactsList = await App.DataBase.GetContactsAsync();
        }

        async void AddItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactEntryPage
            {
                BindingContext = new ContactModel()
            });
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new EditContactPage
                {
                    BindingContext = e.SelectedItem as ContactModel
                });
            }
        }
    }
}