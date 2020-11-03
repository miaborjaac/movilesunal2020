using Reto8.Models;
using Reto8.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reto8.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContactPage : ContentPage
    {
        private readonly ContactEntryViewModel _viewModel;
        private string contactType;

        public EditContactPage()
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
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var contact = (ContactModel)BindingContext;
            await App.DataBase.DeleteContactAsync(contact);
            await Navigation.PopAsync();
        }
        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var index = picker.SelectedIndex;
            contactType = _viewModel.ContactTypes[index];
        }
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayAlert("Eliminar contacto", "¿Estás seguro de eliminar este contacto?", "Eliminar", "Cancelar");
            if (action)
            {
                OnDeleteButtonClicked(sender, e);
            }
        }
    }
}