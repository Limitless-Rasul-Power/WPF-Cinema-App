using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Cinema_App.Command;
using WPF_Cinema_App.Models;
using WPF_Cinema_App.Static_Classes;
using WPF_Cinema_App.Static_File_Helper_Classes;
using WPF_Cinema_App.Views.UserControls;

namespace WPF_Cinema_App.ViewModels
{
    public class AdminSideCinemaViewModel
    {

        public AdminSideCinemaViewModel()
        {
            try
            {
                CinemaHalls = JsonFileHelper.JsonDeserialization<CinemaHall>("Database of Cinemas/cinemas");
            }
            catch (Exception)
            {
                CinemaHalls = new ObservableCollection<CinemaHall>();
            }

            AddCinemaCommand = new RelayCommand(AddCinemaClick);
        }
        public ObservableCollection<CinemaHall> CinemaHalls { get; set; }
        public RelayCommand AddCinemaCommand { get; set; }

        private void AddCinemaClick(object data = null)
        {
            MovieSearchViewModel movieSearchViewModel = new MovieSearchViewModel(isGuestEntered:false);

            MovieSearch movieSearch = new MovieSearch()
            {
                DataContext = movieSearchViewModel
            };
            

            ViewController.SecondView.Content = movieSearch;
        }
    }
}
