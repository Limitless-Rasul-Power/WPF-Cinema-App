using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WPF_Cinema_App.Command;
using WPF_Cinema_App.Models;
using WPF_Cinema_App.Static_Classes;
using WPF_Cinema_App.Static_File_Helper_Classes;
using WPF_Cinema_App.Views.UserControls;

namespace WPF_Cinema_App.ViewModels
{
    public class GuestSecondViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Brush _homeButtonColor;
        private Brush _theaterButtonColor;

        public GuestSecondViewModel()
        {
            HomeClick();
            BackCommand = new RelayCommand(BackClick);
            HomeCommand = new RelayCommand(HomeClick);
            CinemaCommand = new RelayCommand(CinemaClick);
        }

        public List<string> LikedMoviesImdbIdsForOneGuest { get; set; } = new List<string>();
        public RelayCommand BackCommand { get; set; }
        public RelayCommand HomeCommand { get; set; }
        public RelayCommand CinemaCommand { get; set; }

        public Brush HomeButtonColor
        {
            get { return _homeButtonColor; }
            set { _homeButtonColor = value; OnPropertyChanged(); }
        }
        public Brush TheaterButtonColor
        {
            get { return _theaterButtonColor; }
            set { _theaterButtonColor = value; OnPropertyChanged(); }
        }


        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void BackClick(object data = null)
        {
            GuestBuyTicketViewModel.IsAliGuidedGuest = false;
            ViewController.MainView.Content = new FirstViewGuestOrAdmin();
        }

        private void HomeClick(object data = null)
        {
            HomeButtonColor = Brushes.Green;
            TheaterButtonColor = Brushes.White;

            MovieSearchViewModel movieSearchViewModel = new MovieSearchViewModel(isGuestEntered:true);

            (movieSearchViewModel.ViewModel as MovieTemplateViewModel).LikedMoviesImdbIdsForOneGuest = this.LikedMoviesImdbIdsForOneGuest;

            MovieSearch movieSearch = new MovieSearch
            {
                DataContext = movieSearchViewModel
            };

            ViewController.SecondView.Content = movieSearch;
        }
        private void CinemaClick(object data = null)
        {           
            try
            {
                ObservableCollection<CinemaHall> cinemaHalls = JsonFileHelper.JsonDeserialization<CinemaHall>("Database of Cinemas/cinemas");

                GuestBuyTicketViewModel guestBuyTicketViewModel = new GuestBuyTicketViewModel(cinemaHalls);

                GuestBuyTicketView guestBuyTicketView = new GuestBuyTicketView
                {
                    DataContext = guestBuyTicketViewModel
                };

                ViewController.SecondView.Content = guestBuyTicketView;

                HomeButtonColor = Brushes.White;
                TheaterButtonColor = Brushes.Green;
            }
            catch (Exception)
            {
                MessageBox.Show("There is no cinema right now.");
            }

        }

    }
}