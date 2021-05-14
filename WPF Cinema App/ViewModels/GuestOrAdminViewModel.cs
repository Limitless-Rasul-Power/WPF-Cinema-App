using System;
using WPF_Cinema_App.Command;
using WPF_Cinema_App.Static_Classes;
using WPF_Cinema_App.Views.UserControls;

namespace WPF_Cinema_App.ViewModels
{
    public class GuestOrAdminViewModel
    {       
        public GuestOrAdminViewModel()
        {
            GuestCommand = new RelayCommand(GuestClick);
            AdminCommand = new RelayCommand(AdminClick);
            LocationCommand = new RelayCommand(LocationClick);
        }

        public RelayCommand GuestCommand { get; set; }
        public RelayCommand AdminCommand { get; set; }
        public RelayCommand LocationCommand { get; set; }

        private void GuestClick(object data = null)
        {
            GuestSecondView guestSecondView = new GuestSecondView();

            GuestSecondViewModel guestSecondViewModel = new GuestSecondViewModel();

            guestSecondView.DataContext = guestSecondViewModel;


            ViewController.MainView.Content = guestSecondView;
        }

        private void AdminClick(object data = null)
        {
            AdminLoginViewModel adminLoginViewModel = new AdminLoginViewModel();

            AdminLoginView adminLoginView = new AdminLoginView
            { 
                DataContext = adminLoginViewModel
            };

            ViewController.MainView.Content = adminLoginView;
        }

        private void LocationClick(object obj = null)
        {
            LocationViewModel locationViewModel = new LocationViewModel();

            LocationView locationView = new LocationView
            {
                DataContext = locationViewModel
            };

            ViewController.MainView.Content = locationView;
        }


    }
}
