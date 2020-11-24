using Reto10.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reto10.ViewModels
{
    class MassiveTransportVm : BaseVm
    {
        private string _date = "";
        private string _city = "";
        private string _system = "";
        private string _weekDay = "";
        private string _url = string.Empty;
        private ObservableCollection<MassiveTransport> _response = new ObservableCollection<MassiveTransport>();
        private List<string> _citiesList = new List<string>();
        private List<string> _transportList = new List<string>();
        private List<string> _weekDays = new List<string>();

        public MassiveTransportVm()
        {

            List<string> cities = new List<string>();
            cities.Add("Bogotá y Soacha");
            cities.Add("Medellin");
            cities.Add("Cartagena");
            cities.Add("Cali/Valle");
            cities.Add("Pereira");
            cities.Add("Barranquilla");
            cities.Add("Bucaramanga");
            cities.Add("Bogotá");
            CitiesList = cities;

            List<string> transportList = new List<string>();
            transportList.Add("SITVA");
            transportList.Add("TRANSCARIBE");
            transportList.Add("MEGABUS");
            transportList.Add("METROLINEA");
            transportList.Add("TRANSMETRO");
            transportList.Add("TRANSMILENIO/SITP");
            transportList.Add("MIO");
            transportList.Add("TRONCAL");
            transportList.Add("ZONAL Y DUAL");
            TransportList = transportList;

            List<string> weekDays = new List<string>();
            weekDays.Add("Lunes");
            weekDays.Add("Martes");
            weekDays.Add("Miércoles");
            weekDays.Add("Jueves");
            weekDays.Add("Viernes");
            weekDays.Add("Sábado");
            weekDays.Add("Domingo");
            WeekDays = weekDays;
        }

        public string Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }
        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged();
            }
        }
        public string System
        {
            get => _system;
            set
            {
                _system = value;
                OnPropertyChanged();
            }
        }
        public string WeekDay
        {
            get => _weekDay;
            set
            {
                _weekDay = value;
                OnPropertyChanged();
            }
        }
        public string Url
        {
            get => _url;
            set
            {
                _url = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<MassiveTransport> Response
        {
            get => _response;
            set
            {
                _response = value;
                OnPropertyChanged();
            }
        }
        public List<string> CitiesList
        {
            get => _citiesList;
            set
            {
                _citiesList = value;
                OnPropertyChanged();
            }
        }
        public List<string> TransportList
        {
            get => _transportList;
            set
            {
                _transportList = value;
                OnPropertyChanged();
            }
        }
        public List<string> WeekDays
        {
            get => _weekDays;
            set
            {
                _weekDays = value;
                OnPropertyChanged();
            }
        }
    }
}
