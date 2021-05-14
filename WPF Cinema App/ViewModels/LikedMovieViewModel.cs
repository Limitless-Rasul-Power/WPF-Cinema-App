using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Cinema_App.Command;
using WPF_Cinema_App.Models;
using WPF_Cinema_App.Static_File_Helper_Classes;

namespace WPF_Cinema_App.ViewModels
{
    public class LikedMovieViewModel
    {
        public LikedMovieViewModel()
        {
            try
            {
                Movies = JsonFileHelper.JsonDeserialization<Movie>("Database of Liked Movies/movies");
                List<Movie> sortedMovies = Movies.OrderByDescending(movie => movie.LikeCount).ToList();

                Movies.Clear();

                for (int i = 0; i < sortedMovies.Count; i++)
                {
                    Movies.Add(sortedMovies[i]);
                }
            }
            catch (Exception)
            {
                Movies = new ObservableCollection<Movie>();
            }

            PutMovieToCinemaCommand = new RelayCommand(PutMovieToCinemaButtonClick);

        }
        public ObservableCollection<Movie> Movies { get; set; }
        public ObservableCollection<CinemaHall> CinemaHalls { get; set; }
        public RelayCommand PutMovieToCinemaCommand { get; set; }

        private void PutMovieToCinemaButtonClick(object data)
        {
            if (data is Movie movie)
            {
                System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show($"Do you want to add \"{movie.Title}\" to cinema ?", "Mosaviena", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question);

                if (result == System.Windows.MessageBoxResult.Yes)
                {
                    try
                    {
                        CinemaHalls = JsonFileHelper.JsonDeserialization<CinemaHall>("Database of Cinemas/cinemas");
                    }
                    catch (Exception)
                    {
                        CinemaHalls = new ObservableCollection<CinemaHall>();
                    }


                    if (CinemaHalls.FirstOrDefault(cm => cm.Movie.ImdbID == movie.ImdbID) != null)
                    {
                        System.Windows.MessageBox.Show($"You already add this movie to cinema.", "Mosaviena");

                        return;
                    }

                    CinemaHalls.Add(new CinemaHall { Movie = movie });
                    JsonFileHelper.JsonSerialization<CinemaHall>(CinemaHalls, "Database of Cinemas/cinemas");
                }

                System.Windows.MessageBox.Show($"Operation {result} done successfully.", "Mosaviena");
            }
        }

    }
}
