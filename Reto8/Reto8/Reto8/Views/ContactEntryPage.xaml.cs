using Reto8.Models;
using Reto8.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reto8.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactEntryPage : ContentPage
    {
        private readonly ContactEntryViewModel _viewModel;
        private string contactType;

        public ContactEntryPage()
        {
            BindingContext = _viewModel = new ContactEntryViewModel();
            _viewModel.Title = "Agregar contacto";

            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var contact = (ContactModel)BindingContext;
            contact.ContactType = contactType;
            await App.DataBase.SaveContactAsync(contact);
            await Navigation.PopAsync();
        }
        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var index = picker.SelectedIndex;
            contactType = _viewModel.ContactTypes[index];
        }
    }
}