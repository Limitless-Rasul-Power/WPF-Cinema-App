using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPF_Cinema_App.Command;
using WPF_Cinema_App.Models;
using WPF_Cinema_App.Services;
using WPF_Cinema_App.Static_File_Helper_Classes;
using WPF_Cinema_App.Views;

namespace WPF_Cinema_App.ViewModels
{
    public class CinemaTemplateViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Movie _movie;

        public CinemaTemplateViewModel()
        {
            AddMovieCommand = new RelayCommand(AddMovieClick);
            ImageMouseLeftCommand = new RelayCommand(ImageMouseLeftClick);
        }
        public Movie Movie
        {
            get { return _movie; }
            set { _movie = value; OnPropertyChanged(); }
        }

        public RelayCommand AddMovieCommand { get; set; }
        public RelayCommand ImageMouseLeftCommand { get; set; }
        private void ImageMouseLeftClick(object data = null)
        {
            if (Movie != null)
            {
                TrailerViewModel trailerViewModel = new TrailerViewModel
                {
                    VideoSource = $@"https://www.youtube.com/results?search_query={YoutubeServices.ConvertDataToYoutubeSearchableData(Movie.Title)}+trailer"
                };

                TrailerWindow trailerWindow = new TrailerWindow
                {
                    DataContext = trailerViewModel
                };

                trailerWindow.ShowDialog();
                trailerViewModel.VideoSource = @"https://www.youtube.com/";
            }
        }

        private void AddMovieClick(object data = null)
        {
            ObservableCollection<CinemaHall> cinemaHalls;
            try
            {
                cinemaHalls = JsonFileHelper.JsonDeserialization<CinemaHall>("Database of Cinemas/cinemas");
            }
            catch (Exception)
            {
                cinemaHalls = new ObservableCollection<CinemaHall>();
            }

            if (cinemaHalls.FirstOrDefault(ch => ch.Movie.ImdbID == Movie.ImdbID) != null)
            {
                System.Windows.MessageBox.Show("This movie already exists.", "Mosaviena");

                return;
            }

            cinemaHalls.Add(new CinemaHall { Movie = this.Movie });

            JsonFileHelper.JsonSerialization(cinemaHalls, "Database of Cinemas/cinemas");
            System.Windows.MessageBox.Show($"Movie \"{Movie.Title}\" added to cinema successfully.", "Mosaviena");
        }


        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
