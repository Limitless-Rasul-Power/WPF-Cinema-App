using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Cinema_App.Command;
using WPF_Cinema_App.Services;
using WPF_Cinema_App.Static_Classes;
using WPF_Cinema_App.Static_File_Helper_Classes;
using WPF_Cinema_App.Views.UserControls;

namespace WPF_Cinema_App.ViewModels
{
    public class LocationViewModel
    {        
        public LocationViewModel()
        {
            string APIKey = ConfigurationManager.AppSettings["BingMapAPIKEY"];
            BingMapServices.Provider = new ApplicationIdCredentialsProvider(APIKey);
            TotalBudget = BinaryFileHelper.BinaryDeserialization("Total Budget");
            Locations = JsonFileHelper.JsonDeserialization<Models.Location>("Cinema Locations/locations");    
            BackCommand = new RelayCommand(BackClick);
        }

        public BingMapServices BingMapServices { get; set; } = new BingMapServices();
        public decimal TotalBudget { get; set; }
        public ObservableCollection<Models.Location> Locations { get; set; }
        public RelayCommand BackCommand { get; set; }

        private void BackClick(object obj = null)
        {
            GuestOrAdminViewModel guestOrAdminViewModel = new GuestOrAdminViewModel();

            FirstViewGuestOrAdmin firstViewGuestOrAdmin = new FirstViewGuestOrAdmin
            {
                DataContext = guestOrAdminViewModel
            };

            ViewController.MainView.Content = firstViewGuestOrAdmin;
        }
    }
}