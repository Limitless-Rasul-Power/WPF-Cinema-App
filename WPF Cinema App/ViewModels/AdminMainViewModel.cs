using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPF_Cinema_App.Command;
using WPF_Cinema_App.Static_Classes;
using WPF_Cinema_App.Views.UserControls;

namespace WPF_Cinema_App.ViewModels
{
    public class AdminMainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Brush _likeButtonBackgroundColor;
        private Brush _cinemaButtonBackgroundColor;
        private bool _isShowLikedMoviesClicked = true;

        public AdminMainViewModel()
        {
            LikeButtonBackgroundColor = Brushes.SpringGreen;
            CinemaButtonBackgroundColor = Brushes.White;


            BackCommand = new RelayCommand(BackClick);
            ShowLikedMoviesCommand = new RelayCommand(ShowLikedMoviesClick);
            ShowCinemasCommand = new RelayCommand(ShowCinemasClick);
        }

        public RelayCommand BackCommand { get; set; }
        public RelayCommand ShowLikedMoviesCommand { get; set; }
        public RelayCommand ShowCinemasCommand { get; set; }

        public Brush LikeButtonBackgroundColor
        {
            get { return _likeButtonBackgroundColor; }
            set { _likeButtonBackgroundColor = value; OnPropertyChanged(); }
        }

        public Brush CinemaButtonBackgroundColor
        {
            get { return _cinemaButtonBackgroundColor; }
            set { _cinemaButtonBackgroundColor = value; OnPropertyChanged(); }
        }

        private void BackClick(object data = null)
        {
            ViewController.MainView.Content = new FirstViewGuestOrAdmin();
        }

        private void ShowLikedMoviesClick(object data = null)
        {
            if (_isShowLikedMoviesClicked == false)
            {
                LikeButtonBackgroundColor = Brushes.SpringGreen;
                CinemaButtonBackgroundColor = Brushes.White;
                _isShowLikedMoviesClicked = true;
                
                LikedMovieViewModel likedMoviesViewModel = new LikedMovieViewModel();

                LikedMoviesView likedMoviesView = new LikedMoviesView
                {
                    DataContext = likedMoviesViewModel
                };

                ViewController.SecondView.Content = likedMoviesView;

            }

        }

        private void ShowCinemasClick(object data = null)
        {
            if (_isShowLikedMoviesClicked)
            {
                LikeButtonBackgroundColor = Brushes.White;
                CinemaButtonBackgroundColor = Brushes.SpringGreen;
                _isShowLikedMoviesClicked = false;

                AdminSideCinemaViewModel adminSideCinemaViewModel = new AdminSideCinemaViewModel();
                AdminSideCinemaView adminSideCinemaView = new AdminSideCinemaView
                {
                    DataContext = adminSideCinemaViewModel
                };

                ViewController.SecondView.Content = adminSideCinemaView;
            }

        }

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
