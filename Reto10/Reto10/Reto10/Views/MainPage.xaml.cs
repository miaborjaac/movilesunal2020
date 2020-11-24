using Newtonsoft.Json;
using Reto10.Models;
using Reto10.ViewModels;
using Reto10.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using Xamarin.Forms;

namespace Reto10
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly MassiveTransportVm _viewModel;
        private readonly HttpClient client = new HttpClient();

        public MainPage()
        {
            BindingContext = _viewModel = new MassiveTransportVm();
            _viewModel.Title = "Información Pasajeros Transporte Masivo";
            _viewModel.Url = "https://www.datos.gov.co/resource/2h8t-2zik.json";
            var date = DateTime.Now;
            _viewModel.Date = DateFormatString(date);

            InitializeComponent();
        }
        protected override void OnAppearing()
        {            
            base.OnAppearing();
        }
        async void getResponse()
        {
            _viewModel.IsLoading = true;
            homeContent.IsVisible = !_viewModel.IsLoading;

            _viewModel.Url = "https://www.datos.gov.co/resource/2h8t-2zik.json?";
            if (_viewModel.Date != "")
            {
                _viewModel.Url = _viewModel.Url + "fecha=" + _viewModel.Date;
            }
            if (_viewModel.City != "")
            {
                _viewModel.Url = _viewModel.Url + "&ciudad=" + _viewModel.City;
            }
            if (_viewModel.System != "")
            {
                _viewModel.Url = _viewModel.Url + "&sistema=" + _viewModel.System;
            }
            if (_viewModel.WeekDay != "")
            {
                _viewModel.Url = _viewModel.Url + "&d_asemana=" + _viewModel.WeekDay;
            }

            string content = await client.GetStringAsync(_viewModel.Url);
            List<MassiveTransport> response = JsonConvert.DeserializeObject<List<MassiveTransport>>(content);
            _viewModel.Response = new ObservableCollection<MassiveTransport>(response);

            _viewModel.IsLoading = false;
            homeContent.IsVisible = !_viewModel.IsLoading;

            if (_viewModel.Response.Count == 0)
            {
                await DisplayAlert("Sin registros", "No se encontraron registros con los valores seleccionados.", "Entendido");
            }
            else
            {
                await Navigation.PushAsync(new ResultPage(_viewModel.Response));
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            getResponse();
        }
        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            DatePicker datePicker = (DatePicker)sender;
            _viewModel.Date = DateFormatString(datePicker.Date);
        }
        private void OnChangeCity(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            if (picker.SelectedIndex >= 0)
            {
                _viewModel.City = _viewModel.CitiesList[picker.SelectedIndex];
            }
        }
        private void OnChangeSystem(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            if (picker.SelectedIndex >= 0)
            {
                _viewModel.System = _viewModel.TransportList[picker.SelectedIndex];
            }
        }
        private void OnChangeDay(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            if (picker.SelectedIndex >= 0)
            {
                _viewModel.WeekDay = (picker.SelectedIndex + 1).ToString();
                _viewModel.Date = "";
                datePicker.IsEnabled = false;
            }
        }
        string DateFormatString(DateTime date)
        {
            var day = date.Day < 10 ? $"0{date.Day}" : $"{date.Day}";
            var month = date.Month < 10 ? $"0{date.Month}" : $"{date.Month}";
            return day + "/" + month + "/" + date.Year;
        }
        private void ClearValues(object sender, EventArgs e)
        {
            _viewModel.City = "";
            cityPicker.SelectedItem = null;
            _viewModel.System = "";
            systemPicker.SelectedItem = null;
            _viewModel.WeekDay = "";
            dayPicker.SelectedItem = null;
            datePicker.IsEnabled = true;
            var date = DateTime.Now;
            datePicker.Date = date;
            _viewModel.Date = DateFormatString(date);
        }
    }
}
