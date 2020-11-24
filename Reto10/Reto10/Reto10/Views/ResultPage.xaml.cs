using Reto10.Models;
using Reto10.ViewModels;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reto10.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {
        private readonly MassiveTransportVm _viewModel;

        public ResultPage(ObservableCollection<MassiveTransport> response)
        {
            BindingContext = _viewModel = new MassiveTransportVm();
            _viewModel.Title = response.Count > 1 ? response.Count + " Resultados" : response.Count + " Resultado";
            _viewModel.Response = response;

            InitializeComponent();
        }
    }
}