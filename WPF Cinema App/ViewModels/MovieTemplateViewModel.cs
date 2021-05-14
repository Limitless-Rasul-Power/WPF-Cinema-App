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
    public class MovieTemplateViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Movie _movie;

        public MovieTemplateViewModel()
        {
            try
            {
                Movies = JsonFileHelper.JsonDeserialization<Movie>("Database of Liked Movies/movies");
            }
            catch (Exception)
            {
                Movies = new ObservableCollection<Movie>();
            }

            LikeCommand = new RelayCommand(LikeClick);
            ImageMouseLeftCommand = new RelayCommand(ImageMouseLeftClick);
        }

        public RelayCommand LikeCommand { get; set; }
        public RelayCommand ImageMouseLeftCommand { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }
        public List<string> LikedMoviesImdbIdsForOneGuest { get; set; }

        public Movie Movie
        {
            get { return _movie; }
            set { _movie = value; OnPropertyChanged(); }
        }

        private void LikeClick(object data = null)
        {
            if (Movie != null && LikedMoviesImdbIdsForOneGuest?.Contains(Movie.ImdbID) == false)
            {
                Movie movie = Movies.FirstOrDefault(m => m.ImdbID == Movie.ImdbID);

                if (movie != null)
                {
                    movie.LikeCount = movie.LikeCount + 1;
                    Movie.LikeCount = movie.LikeCount;
                }
                else
                {
                    Movie.LikeCount = Movie.LikeCount + 1;
                    Movies.Add(Movie);
                }

                JsonFileHelper.JsonSerialization<Movie>(Movies, "Database of Liked Movies/movies");
                LikedMoviesImdbIdsForOneGuest?.Add(Movie.ImdbID);
            }
        }


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

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}